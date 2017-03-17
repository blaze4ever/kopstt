using System;
using Microsoft.Win32;

namespace Kopstt.Core
{
    public class WndowsRegistry : IWndowsRegistry
    {
        private RegistryKey _registry;

        public WndowsRegistry()
        {
            _registry = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        }

        public void SetValue(string appName, string executablePath)
        {
            _registry.SetValue(appName, executablePath);
        }

        public void DeleteValue(string appName)
        {
            _registry.DeleteValue(appName, false);
        }

        public object GetValue(string appName)
        {
            return _registry.GetValue(appName);
        }
    }
}
