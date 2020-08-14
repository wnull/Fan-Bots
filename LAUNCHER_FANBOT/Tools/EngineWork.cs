using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LAUNCHER_FANBOT
{
    public class EngineWork
    {
        public readonly Random random = new Random(Environment.TickCount);
        private bool one_start = false;
        public string[] prms = new string[]
        {
            "Введите автоматическую команду",
            "Введите ник",
            "Введите логин",
            "Введите пароль",
            "Введите команду",

            "MY.COM - ЕВРОПА",
            "MY.COM - АМЕРИКА",
            "GOPLAY - ВЬЕТНАМ",
            "RU - АЛЬФА",
            "RU - БРАВО",
            "RU - ЧАРЛИ",
            "RU - ПТС",

            "Случайный",
            "Синий",
            "Зеленый",
            "Голубой",
            "Красный",
            "Лиловый",
            "Желтый",
            "Белый",
            "Серый",
            "Светло-синий"
        };

        public void MSB_Information(string text, string caption) => MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void MSB_Error(string er) => MessageBox.Show(er, "Ошибка..", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void SetValue(string value, ref string set) { if (!string.IsNullOrWhiteSpace(value)) set = value; }

        public static string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string res = reader.ReadToEnd();
            reader.Close();

            return res;
        }
        public void GetAllControls(Control control, IniFile iniFile, string name, bool write)
        {
            if (!string.IsNullOrWhiteSpace(control.Text))
            {
                if (write) iniFile.Write(control.Name, control.Text, name);
                else
                {
                    string tmp = iniFile.Read(control.Name, name);
                    if (!string.IsNullOrWhiteSpace(tmp)) control.Text = tmp;
                }
            }
            foreach (Control tmp_control in control.Controls) GetAllControls(tmp_control, iniFile, name, write);
        }

        private void GetAllPrms(Menu menu, IniFile iniFile, string name)
        {
#if DEBUG
            string tmp = string.Empty;
            for (int i = 0; i < prms.Length; i++) tmp += $"{$">prms_{i}"} = {prms[i]}\n";
            Clipboard.SetText(tmp); 
#else
            for (int i = 0; i < prms.Length; i++) SetValue(iniFile.Read($">prms_{i}", name), ref prms[i]);
#endif
        }
        public void GetAllControls_ForSettings(List<Control> get_controls_list, Control control, Type type)
        {
            if (control.GetType() == type) get_controls_list.Add(control);
            foreach (Control ctrlChild in control.Controls) GetAllControls_ForSettings(get_controls_list, ctrlChild, type);
        }
        public void Translation(Control control_cont, bool translation, string file, string name)
        {
            Menu menu = (Menu)control_cont;
            if (translation == true)
            {
                GetAllControls(control_cont, new IniFile(file), name, false);
                GetAllPrms(menu, new IniFile(file), name);
                menu.LoadPrms();
            }
            else if (one_start == true)
            {
                new IniFile(menu.files_names[3]).Write(menu.comboBox_languages.Name, "default (russian)", menu.sect);
                Process.Start(Application.ProductName + ".exe");
                Environment.Exit(0);
            }
            else one_start = true;
        }

        public static class TextBoxWatermarkExtensionMethod
        {
            private const uint ECM_FIRST = 0x1500;
            private const uint EM_SETCUEBANNER = ECM_FIRST + 1;

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
            private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
            public static void SetWatermark(TextBox textBox, string watermarkText) => SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermarkText);
        }
    }
}
