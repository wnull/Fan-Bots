using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAUNCHER_FANBOT
{
    public class EngineWork
    {
        public readonly Random random = new Random(Environment.TickCount);
        private bool one_start = false;
        public List<string> prms = new List<string>()
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
            "Светло-синий",
        };
        public void MSB_Information(string text, string caption) => MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void MSB_Error(string er) => MessageBox.Show(er, "Ошибка..", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            if (control.Text.Length > 0)
            {
                if (write) iniFile.Write(control.Name, control.Text, name);
                else if (iniFile.Read(control.Name, name).Length > 0) control.Text = iniFile.Read(control.Name, name);
            }
            foreach (Control tmp_control in control.Controls) GetAllControls(tmp_control, iniFile, name, write);
        }
        public void GetAllPrms(Menu menu, IniFile iniFile, string name)
        {
            string tmp = string.Empty;

            tmp = iniFile.Read(">prms_autocommand", name);
            if (tmp.Length > 0) prms[0] = tmp;
            tmp = iniFile.Read(">prms_nickname", name);
            if (tmp.Length > 0) prms[1] = tmp;
            tmp = iniFile.Read(">prms_login", name);
            if (tmp.Length > 0) prms[2] = tmp;
            tmp = iniFile.Read(">prms_password", name);
            if (tmp.Length > 0) prms[3] = tmp;
            tmp = iniFile.Read(">prms_command", name);
            if (tmp.Length > 0) prms[4] = tmp;
            //
            tmp = iniFile.Read(">prms_servers_0", name);
            if (tmp.Length > 0) prms[5] = tmp;
            tmp = iniFile.Read(">prms_servers_1", name);
            if (tmp.Length > 0) prms[6] = tmp;
            tmp = iniFile.Read(">prms_servers_2", name);
            if (tmp.Length > 0) prms[7] = tmp;
            tmp = iniFile.Read(">prms_servers_3", name);
            if (tmp.Length > 0) prms[8] = tmp;
            tmp = iniFile.Read(">prms_servers_4", name);
            if (tmp.Length > 0) prms[9] = tmp;
            tmp = iniFile.Read(">prms_servers_5", name);
            if (tmp.Length > 0) prms[10] = tmp;
            tmp = iniFile.Read(">prms_servers_6", name);
            if (tmp.Length > 0) prms[11] = tmp;

            tmp = iniFile.Read(">prms_colors_text_0", name);
            if (tmp.Length > 0) prms[12] = tmp;
            tmp = iniFile.Read(">prms_colors_text_1", name);
            if (tmp.Length > 0) prms[13] = tmp;
            tmp = iniFile.Read(">prms_colors_text_2", name);
            if (tmp.Length > 0) prms[14] = tmp;
            tmp = iniFile.Read(">prms_colors_text_3", name);
            if (tmp.Length > 0) prms[15] = tmp;
            tmp = iniFile.Read(">prms_colors_text_4", name);
            if (tmp.Length > 0) prms[16] = tmp;
            tmp = iniFile.Read(">prms_colors_text_5", name);
            if (tmp.Length > 0) prms[17] = tmp;
            tmp = iniFile.Read(">prms_colors_text_6", name);
            if (tmp.Length > 0) prms[18] = tmp;
            tmp = iniFile.Read(">prms_colors_text_7", name);
            if (tmp.Length > 0) prms[19] = tmp;
            tmp = iniFile.Read(">prms_colors_text_8", name);
            if (tmp.Length > 0) prms[20] = tmp;
            tmp = iniFile.Read(">prms_colors_text_9", name);
            if (tmp.Length > 0) prms[21] = tmp;
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
                new IniFile(menu.files_names[2]).Write(menu.comboBox_languages.Name, "default (russian)", menu.sect);
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
