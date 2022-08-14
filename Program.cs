using System.Windows.Forms;

namespace SharpClipboard
{
    public sealed class Program
    {
        private static void Main(string[] args)
        {
            //starts a message loop on current thread and displays specified form
            Application.Run(new NotificationForm());
        }
    }
}