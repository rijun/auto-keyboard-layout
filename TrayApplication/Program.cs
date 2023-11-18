namespace TrayApplication;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    public static void Main()
    {
        ApplicationConfiguration.Initialize();
        CustomApplicationContext applicationContext = new();
        Application.Run(applicationContext);
    }
}