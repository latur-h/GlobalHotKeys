using GlobalHotKeys.Core;
using GlobalHotKeys.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHotKeys
{
    public class GlobalHotKeys : IDisposable
    {
        private readonly HookLifecycle _hookLifecycle;
        private readonly HotkeyRegistry _registry = new();
        private readonly Dictionary<string, ActiveCombination> _active = new();

        private readonly HashSet<KeyCode> _pressedInputs = new();

        public GlobalHotKeys()
        {
            _hookLifecycle = new HookLifecycle(KeyboardProc, MouseProc);
        }

        public void Start() => _hookLifecycle.Start();
        public void Stop() => _hookLifecycle.Stop();

        public void Register(string id, HotkeyCombination combo, Func<Task> action) => _registry.Register(id, combo, action);
        public void Register(Bind bind, Func<Task> action) => _registry.Register(bind, action);

        public void Change(string id, HotkeyCombination newCombo) => _registry.Change(id, newCombo);
        public void Change(Bind bind, HotkeyCombination newCombo) => _registry.Change(bind, newCombo);

        public void Unregister(string id) => _registry.Unregister(id);
        public void Unregister(Bind bind) => _registry.Unregister(bind);

        private IntPtr KeyboardProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = System.Runtime.InteropServices.Marshal.ReadInt32(lParam);
                KeyCode key = (KeyCode)vkCode;

                if (wParam == (IntPtr)Interop.WindowsMessages.WM_KEYDOWN ||
                    wParam == (IntPtr)Interop.WindowsMessages.WM_SYSKEYDOWN)
                {
                    _pressedInputs.Add(key);
                    _ = CheckHotkeys();
                }
                else if (wParam == (IntPtr)Interop.WindowsMessages.WM_KEYUP ||
                         wParam == (IntPtr)Interop.WindowsMessages.WM_SYSKEYUP)
                {
                    _pressedInputs.Remove(key);
                    OnRelease(key);
                }
            }

            return Interop.NativeMethods.CallNextHookEx(_hookLifecycle.KeyboardHookId, nCode, wParam, lParam);
        }
        private IntPtr MouseProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var hs = System.Runtime.InteropServices.Marshal.PtrToStructure<Interop.MSLLHOOKSTRUCT>(lParam);
                bool isDown = false, isUp = false;
                KeyCode button = KeyCode.LButton;

                switch ((int)wParam)
                {
                    case Interop.WindowsMessages.WM_LBUTTONDOWN: isDown = true; button = KeyCode.LButton; break;
                    case Interop.WindowsMessages.WM_RBUTTONDOWN: isDown = true; button = KeyCode.RButton; break;
                    case Interop.WindowsMessages.WM_MBUTTONDOWN: isDown = true; button = KeyCode.MButton; break;
                    case Interop.WindowsMessages.WM_XBUTTONDOWN:
                        isDown = true;
                        button = ((hs.mouseData >> 16) & 0xFFFF) == 1 ? KeyCode.XButton1 : KeyCode.XButton2;
                        break;
                    case Interop.WindowsMessages.WM_LBUTTONUP: isUp = true; button = KeyCode.LButton; break;
                    case Interop.WindowsMessages.WM_RBUTTONUP: isUp = true; button = KeyCode.RButton; break;
                    case Interop.WindowsMessages.WM_MBUTTONUP: isUp = true; button = KeyCode.MButton; break;
                    case Interop.WindowsMessages.WM_XBUTTONUP:
                        isUp = true;
                        button = ((hs.mouseData >> 16) & 0xFFFF) == 1 ? KeyCode.XButton1 : KeyCode.XButton2;
                        break;
                }

                if (isDown)
                {
                    _pressedInputs.Add(button);
                    _ = CheckHotkeys();
                }
                else if (isUp)
                {
                    _pressedInputs.Remove(button);
                    OnRelease(button);
                }
            }

            return Interop.NativeMethods.CallNextHookEx(_hookLifecycle.MouseHookId, nCode, wParam, lParam);
        }

        private async Task CheckHotkeys()
        {
            if (_registry.TryGetAction(_pressedInputs, out var action))
            {
                string key = action!.Method.Name;
                if (!_active.ContainsKey(key))
                {
                    _active[key] = new ActiveCombination(_pressedInputs);
                    await action();

                    _active[key].IsFinished = true;
                }
            }
        }

        private void OnRelease(KeyCode released)
        {
            var toRemove = new List<string>();

            foreach (var kvp in _active)
            {
                if (kvp.Value.PressedInputs.Contains(released))
                {
                    kvp.Value.IsReleased = true;
                    kvp.Value.IsExecuting = false;
                    toRemove.Add(kvp.Key);
                }
            }

            foreach (var id in toRemove)
                _active.Remove(id);
        }

        public void Dispose()
        {
            Stop();
            _pressedInputs.Clear();
            _active.Clear();
        }
    }
}
