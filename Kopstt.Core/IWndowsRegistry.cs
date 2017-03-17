namespace Kopstt.Core
{
    public interface IWndowsRegistry
    {
        void DeleteValue(string appName);
        void SetValue(string appName, string executablePath);
        object GetValue(string appName);
    }
}