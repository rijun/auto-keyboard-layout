using System.Globalization;

namespace Backend;

public class Backend
{
    public List<CultureInfo> Cultures { get; }
    public List<int> Devices { get; }
    private Dictionary<int, CultureInfo> _mappings;

    public Backend()
    {
        Cultures = new List<CultureInfo>();
        foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
        {
            Cultures.Add(lang.Culture);
        }
        Devices = new List<int>();
        _mappings = new Dictionary<int, CultureInfo>();
    }

    public void RegisterRawInput(IntPtr windowHandle)
    {
        RawInput.RawInput.RegisterRawInput(windowHandle);
    }

    public event EventHandler? NewDeviceFound;
    
    public bool HandleWmInputEvent(Message message)
    {
        if (!RawInput.RawInput.ProcessRawInput(message.LParam, out var deviceId)) return false;
        if (!Devices.Contains(deviceId))
        {
            Devices.Add(deviceId);
            NewDeviceFound?.Invoke(this, EventArgs.Empty);
        }
        ProcessKeyboardPressed(deviceId);
        return true;
    }

    public void AddLayoutMapping(int deviceId, int cultureListIndex)
    {
        _mappings.Add(deviceId, Cultures[cultureListIndex]);
    }
    
    public void RemoveLayoutMapping(int deviceId)
    {
        _mappings.Remove(deviceId);
    }
    
    public int LastDeviceUsed { get; private set; }
    
    private void ProcessKeyboardPressed(int deviceId)
    {
        LastDeviceUsed = deviceId;
        if (_mappings.TryGetValue(deviceId, out var culture))
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(culture);
        }
    }
}