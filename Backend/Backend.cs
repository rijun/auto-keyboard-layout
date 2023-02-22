using System.Globalization;
using RawInput;

namespace Backend;

public class Backend
{
    public List<CultureInfo> Cultures { get; }
    public List<int> Devices { get; }

    public Backend()
    {
        Cultures = new List<CultureInfo>();
        foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
        {
            Cultures.Add(lang.Culture);
        }
        Devices = new List<int>();
    }

    public void RegisterRawInput(IntPtr windowHandle)
    {
        RawInput.RawInput.RegisterRawInput(windowHandle);
    }

    public event EventHandler NewDeviceFound;
    
    public bool HandleWmInputEvent(Message message)
    {
        if (!RawInput.RawInput.ProcessRawInput(message.LParam, out var deviceId)) return false;
        if (!Devices.Contains(deviceId))
        {
            Devices.Add(deviceId);
            NewDeviceFound(this, EventArgs.Empty);
        }
        ProcessKeyboardPressed(deviceId);
        return true;
    }

    public int LastDeviceUsed { get; private set; } = 0;

    private void ProcessKeyboardPressed(int deviceId)
    {
        LastDeviceUsed = deviceId;
    }
}