using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHotKeys
{
    internal class Interop
    {
        internal static class NativeMethods
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern IntPtr SetWindowsHookEx(int idHook, LowLevelProc lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern IntPtr GetModuleHandle(string lpModuleName);
        }
        internal static class HookTypes
        {
            public const int WH_KEYBOARD_LL = 13;
            public const int WH_MOUSE_LL = 14;
        }
        internal static class WindowsMessages
        {
            public const int WM_KEYDOWN = 0x0100;
            public const int WM_KEYUP = 0x0101;
            public const int WM_SYSKEYDOWN = 0x0104;
            public const int WM_SYSKEYUP = 0x0105;

            public const int WM_LBUTTONDOWN = 0x0201;
            public const int WM_LBUTTONUP = 0x0202;
            public const int WM_RBUTTONDOWN = 0x0204;
            public const int WM_RBUTTONUP = 0x0205;
            public const int WM_MBUTTONDOWN = 0x0207;
            public const int WM_MBUTTONUP = 0x0208;
            public const int WM_XBUTTONDOWN = 0x020B;
            public const int WM_XBUTTONUP = 0x020C;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        internal delegate IntPtr LowLevelProc(int nCode, IntPtr wParam, IntPtr lParam);
    }
}
