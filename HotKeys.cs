using GlobalHotKeys.Core;
using GlobalHotKeys.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHotKeys
{
    /// <summary>
    /// A universal hotkey manager for registering and handling global keyboard and mouse combinations.
    /// Uses low-level Win32 hooks to detect input across the system.
    /// </summary>
    public class HotKeys : IDisposable
    {
        private readonly HookLifecycle _hookLifecycle;
        private readonly HotkeyRegistry _registry = new HotkeyRegistry();
        private readonly Dictionary<string, ActiveCombination> _active = new Dictionary<string, ActiveCombination>();

        private readonly HashSet<KeyCode> _pressedInputs = new HashSet<KeyCode>();

        /// <summary>
        /// Initializes a new instance of the <see cref="HotKeys"/> class.
        /// Sets up the low-level keyboard and mouse hook callbacks,
        /// but does not start listening until <see cref="Start"/> is called.
        /// </summary>
        public HotKeys()
        {
            _hookLifecycle = new HookLifecycle(KeyboardProc, MouseProc);
        }

        /// <summary>
        /// Starts the global keyboard and mouse hook.
        /// Hotkeys will begin triggering after this is called.
        /// </summary>
        public void Start() => _hookLifecycle.Start();
        /// <summary>
        /// Stops the global keyboard and mouse hook.
        /// No hotkeys will be triggered after this is called.
        /// </summary>
        public void Stop() => _hookLifecycle.Stop();

        /// <summary>
        /// Registers a new hotkey combination with a unique identifier and action.
        /// </summary>
        /// <param name="id">A unique string identifier for the hotkey binding.</param>
        /// <param name="combo">The key combination to associate with the action.</param>
        /// <param name="action">The async function to execute when the combination is pressed.</param>
        public void Register(string id, HotkeyCombination combo, Func<Task> action) => _registry.Register(id, combo, action);
        /// <summary>
        /// Registers a new hotkey binding using a preconfigured <see cref="Bind"/> object.
        /// </summary>
        /// <param name="bind">The bind object that includes an ID and key combination.</param>
        /// <param name="action">The async function to execute when the combination is pressed.</param>
        public void Register(Bind bind, Func<Task> action) => _registry.Register(bind, action);

        /// <summary>
        /// Changes an existing hotkey combination using the specified identifier.
        /// </summary>
        /// <param name="id">The ID of the binding to modify.</param>
        /// <param name="newCombo">The new key combination to assign.</param>
        public void Change(string id, HotkeyCombination newCombo) => _registry.Change(id, newCombo);
        /// <summary>
        /// Changes an existing hotkey combination using a <see cref="Bind"/> instance.
        /// </summary>
        /// <param name="bind">The existing binding to modify.</param>
        /// <param name="newCombo">The new key combination to assign.</param>
        public void Change(Bind bind, HotkeyCombination newCombo) => _registry.Change(bind, newCombo);

        /// <summary>
        /// Unregisters a hotkey binding using its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the binding to remove.</param>
        public void Unregister(string id) => _registry.Unregister(id);
        /// <summary>
        /// Unregisters a hotkey binding using a <see cref="Bind"/> object.
        /// </summary>
        /// <param name="bind">The bind object that identifies the combination to remove.</param>
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

        private async Task CheckHotkeys(bool isKeyUp = false, KeyCode? releasedKey = null)
        {
            var checkSet = new HashSet<KeyCode>(_pressedInputs);

            if (isKeyUp && releasedKey.HasValue)
            {
                if (TryGetUpVariant(releasedKey.Value, out var upKey))
                    checkSet.Add(upKey);
            }

            if (_registry.TryGetAction(checkSet, out var action))
            {
                string key = action!.Method.Name;
                if (!_active.ContainsKey(key))
                {
                    _active[key] = new ActiveCombination(_pressedInputs);
                    await Task.Run(action);
                    _active[key].IsFinished = true;
                }
            }
        }

        private bool TryGetUpVariant(KeyCode key, out KeyCode upKey)
        {
            upKey = (KeyCode)((ushort)key + 0x1000);
            return Enum.IsDefined(typeof(KeyCode), upKey);
        }
        private void OnRelease(KeyCode released)
        {
            _ = CheckHotkeys(isKeyUp: true, releasedKey: released);

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

        /// <summary>
        /// Disposes the hotkey manager by stopping hooks and clearing internal state.
        /// Call this when the application is shutting down or the manager is no longer needed.
        /// </summary>
        public void Dispose()
        {
            Stop();
            _pressedInputs.Clear();
            _active.Clear();
        }
    }
}
