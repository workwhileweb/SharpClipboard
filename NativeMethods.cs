using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpClipboard
{
    /// <summary>
    /// https://stackoverflow.com/questions/621577/clipboard-event-c-sharp
    /// https://stackoverflow.com/questions/17762037/error-while-trying-to-copy-string-to-clipboard
    /// https://gist.github.com/glombard/7986317
    /// </summary>
    public static class NativeMethods
    {
        //Reference https://docs.microsoft.com/en-us/windows/desktop/dataxchg/wm-clipboardupdate
        public const int WmClipboardUpdate = 0x031D;
        //Reference https://www.pinvoke.net/default.aspx/Constants.HWND
        public static IntPtr HwndMessage = new IntPtr(-3);

        //Reference https://www.pinvoke.net/default.aspx/user32/AddClipboardFormatListener.html
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);

        //Reference https://www.pinvoke.net/default.aspx/user32.setparent
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        //Reference https://www.pinvoke.net/default.aspx/user32/getwindowtext.html
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        //Reference https://www.pinvoke.net/default.aspx/user32.getwindowtextlength
        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        //Reference https://www.pinvoke.net/default.aspx/user32.getforegroundwindow
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
    }
}