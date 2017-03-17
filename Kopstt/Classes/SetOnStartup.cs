namespace Kopstt.Classes
{
    using System.Windows.Controls;
    using Core;

    public class SetOnStartup
    {
        WndowsRegistry windows_registry;

        public SetOnStartup(WndowsRegistry windows_registry)
        {
            this.windows_registry = windows_registry;
        }


        public string AppName { get; set; }
        public string ExecutablePath { get; set; }

        // _executable_path = Assembly.GetEntryAssembly();
        //  _app_name = _executable_path.FullName;

        public void setAppOnStartup(bool startup_box)
        {
            if (startup_box)
            {
                windows_registry.SetValue(AppName, ExecutablePath);
            }
            else
            {
                windows_registry.DeleteValue(AppName);               
            }
        }

    }
}
