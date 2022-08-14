using System.Threading;

namespace SharpClipboard
{
    public static class Clipboard
    {
        public static string GetText()
        {
            var returnValue = string.Empty;
            var staThread = new Thread(delegate() { returnValue = System.Windows.Forms.Clipboard.GetText(); });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
            return returnValue;
        }
    }
}