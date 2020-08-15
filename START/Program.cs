using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace START
{
    internal class Program
    {
        public static void MSB_Error(string text) => MessageBox.Show(text, "Fan-Bot's", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static readonly string[] files = { "launcher.exe", "wb.exe" };
        public static readonly string dir = @"bin\";
        public static string one_message = $"{dir}one_message";

        [STAThread]
        private static void Main()
        {
            if (!File.Exists("NO_CHECK.fanbot") && Process.GetProcessesByName("Game").Length > 0 || Process.GetProcessesByName("GameCenter").Length > 0)
                Environment.Exit(0);

            if (File.Exists(one_message))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new One_Message());
            }
            else new One_Message().Start();
        }
    }
}