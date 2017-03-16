namespace Kopstt.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Win32;
    using System.Windows.Controls;
    using System.Reflection;

    public class SetOnStartup
    {
        private readonly string _app_name;
        private RegistryKey _registry;
        private Assembly _executable_path;
        public SetOnStartup()
        {
            _registry = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            _executable_path = Assembly.GetEntryAssembly();
            _app_name = _executable_path.FullName;
        }

        public void setAppOnStartup(CheckBox startup_box)
        {
            if (startup_box.IsChecked == true)
            {
                _registry.SetValue(_app_name, _executable_path.Location);
            }
            else
            {
                _registry.DeleteValue(_app_name, false);
            }
        }

    }
}
