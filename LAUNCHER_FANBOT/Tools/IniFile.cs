using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace LAUNCHER_FANBOT
{
    public class IniFile
    {
        private readonly string Path;
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);
        [DllImport("kernel32", CharSet = CharSet.Unicode)]

        private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
        public IniFile(string IniPath = null) => Path = new FileInfo(IniPath).FullName.ToString();

        public string Read(string Key, string Section = null)
        {
            StringBuilder RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }
        public void Write(string Key, string Value, string Section = null) => WritePrivateProfileString(Section, Key, Value, Path);
        public void DeleteKey(string Key, string Section = null) => Write(Key, null, Section);
        public void DeleteSection(string Section = null) => Write(null, null, Section);
        public bool KeyExists(string Key, string Section = null) => Read(Key, Section).Length > 0;
    }
}