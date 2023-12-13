using System.Diagnostics.Contracts;
using System.IO;
using System.Windows.Forms;

namespace PeerSoftware.Utils
{
    internal static class Logger
    {
        private static object _lock = new object();
        private static CustomMessageBoxOK _customMessageBox = new CustomMessageBoxOK();

        public static void e(string message)
        {
            SaveToFile("error", message);
        }

        public static void w(string message)
        {
            SaveToFile("warn", message);
        }

        public static void d(string message)
        {
            SaveToFile("debug", message);
        }

        public static void i(string message)
        {
            SaveToFile("info", message);
        }

        private static void SaveToFile(string msgType, string message)
        {
            string logFilePath = "logger.log";
            string logInformation = $"[{DateTime.Now}][{msgType.ToUpper()}] -> {message}\n";

            lock (_lock)
            {
                try
                {
                    File.AppendAllText(logFilePath, logInformation);
                }
                catch (Exception ex)
                {
                    _customMessageBox.SetTitle("Error");
                    _customMessageBox.SetMessageText($"An error occurred: {ex.Message}");
                    _customMessageBox.ShowDialog();
                } 
            }
        }

        public static void ClearLogFile()
        {
            File.WriteAllText("logger.log", string.Empty);
        }

    }
}
