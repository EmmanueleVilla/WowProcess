using System.Diagnostics;
using Microsoft.Win32;

namespace WowProcess;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        RegisterApplicationForToast();
        
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        
        using var trayApp = new TrayApplication();
        Application.Run();
    }
    
    private static void RegisterApplicationForToast()
    {
        var aumid = "WoWProcess";
        var processModule = Process.GetCurrentProcess().MainModule;
        if (processModule == null) return;
        var exePath = processModule.FileName;

        using var key = Registry.CurrentUser.CreateSubKey($@"Software\Classes\{aumid}");
        key.SetValue("AppUserModelID", aumid);
        key.SetValue("ApplicationName", exePath);
        key.SetValue("Icon", exePath);
    }
}