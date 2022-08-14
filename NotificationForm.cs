using System;
using System.Text;
using System.Windows.Forms;

namespace SharpClipboard
{
    public class NotificationForm : Form
    {
        public NotificationForm()
        {
            //Turn the child window into a message-only window (refer to Microsoft docs)
            NativeMethods.SetParent(Handle, NativeMethods.HwndMessage);
            //Place window in the system-maintained clipboard format listener list
            NativeMethods.AddClipboardFormatListener(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            //Listen for operating system messages
            if (m.Msg == NativeMethods.WmClipboardUpdate)
            {
                //Get the date and time for the current moment expressed as coordinated universal time (UTC).
                var saveUtcNow = DateTime.UtcNow;
                Console.WriteLine("Copy event detected at {0} (UTC)!", saveUtcNow);

                //Write to stdout active window
                var activeWindow = NativeMethods.GetForegroundWindow();
                var length = NativeMethods.GetWindowTextLength(activeWindow);
                var sb = new StringBuilder(length + 1);
                NativeMethods.GetWindowText(activeWindow, sb, sb.Capacity);
                Console.WriteLine("Clipboard Active Window: " + sb.ToString());

                //Write to stdout clipboard contents
                Console.WriteLine("Clipboard Content: " + Clipboard.GetText());
            }
            //Called for any unhandled messages
            base.WndProc(ref m);
        }
    }
}