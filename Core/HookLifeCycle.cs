﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static GlobalHotKeys.Core.Interop;

namespace GlobalHotKeys.Core
{
    internal class HookLifecycle : IDisposable
    {
        private readonly LowLevelProc _keyboardProc;
        private readonly LowLevelProc _mouseProc;

        private IntPtr _keyboardHookID = IntPtr.Zero;
        private IntPtr _mouseHookID = IntPtr.Zero;

        private CancellationTokenSource? _cts;
        private Task? _hookTask;

        public bool IsRunning { get; private set; }

        public IntPtr KeyboardHookId => _keyboardHookID;
        public IntPtr MouseHookId => _mouseHookID;

        public HookLifecycle(LowLevelProc keyboardCallback, LowLevelProc mouseCallback)
        {
            _keyboardProc = keyboardCallback ?? throw new ArgumentNullException(nameof(keyboardCallback));
            _mouseProc = mouseCallback ?? throw new ArgumentNullException(nameof(mouseCallback));
        }

        public void Start()
        {
            if (IsRunning)
                return;

            _keyboardHookID = SetHook(_keyboardProc, HookTypes.WH_KEYBOARD_LL);
            _mouseHookID = SetHook(_mouseProc, HookTypes.WH_MOUSE_LL);

            _cts = new CancellationTokenSource();
            _hookTask = Task.Run(() => HookLoop(_cts.Token));

            IsRunning = true;
        }

        private async Task HookLoop(CancellationToken token)
        {
            try
            {
                await Task.Delay(Timeout.Infinite, token);
            }
            catch (TaskCanceledException) { }
        }

        public void Stop()
        {
            if (!IsRunning)
                return;

            _cts?.Cancel();

            try
            {
                _hookTask?.Wait();
            }
            catch (AggregateException) { }

            Dispose();
            _cts?.Dispose();
            _hookTask = null;
            _cts = null;
            IsRunning = false;
        }

        public void Dispose()
        {
            if (_keyboardHookID != IntPtr.Zero)
            {
                NativeMethods.UnhookWindowsHookEx(_keyboardHookID);
                _keyboardHookID = IntPtr.Zero;
            }

            if (_mouseHookID != IntPtr.Zero)
            {
                NativeMethods.UnhookWindowsHookEx(_mouseHookID);
                _mouseHookID = IntPtr.Zero;
            }
        }

        private static IntPtr SetHook(LowLevelProc proc, int hookType)
        {
            using var curProcess = Process.GetCurrentProcess();
            using var curModule = curProcess.MainModule!;

            return NativeMethods.SetWindowsHookEx(hookType, proc, NativeMethods.GetModuleHandle(curModule.ModuleName), 0);
        }
    }
}
