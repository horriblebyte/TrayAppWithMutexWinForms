using System;
using System.Runtime.InteropServices;

namespace TrayAppWithMutex.Classes {
    internal class NativeMethods {

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MINIMIZE = 0xf020;

        public const int HWND_BROADCAST = 0xffff;

        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
}