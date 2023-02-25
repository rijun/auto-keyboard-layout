using System.Globalization;

namespace TrayApplication;

public class Backend : Form
{
    public List<CultureInfo> Cultures { get; }
    public List<int> Devices { get; }
    private readonly Dictionary<int, CultureInfo> _mappings;

    public Backend()
    {
        Cultures = new List<CultureInfo>();
        foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
        {
            Cultures.Add(lang.Culture);
        }

        Devices = new List<int>();
        _mappings = new Dictionary<int, CultureInfo>();
        RegisterRawInput();
    }

    protected override void WndProc(ref Message message)
    {
        switch (message.Msg)
        {
            case RawInput.User32.WM_INPUT:
            {
                HandleWmInputEvent(message);
            }
                break;
        }

        base.WndProc(ref message);
    }
    
    private void RegisterRawInput()
    {
        RawInput.RawInput.RegisterRawInput(Handle);
    }
    
    public event EventHandler? NewDeviceFound;

    private bool HandleWmInputEvent(Message message)
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

    internal class KeyboardEventArgs : EventArgs
    {
        public int DeviceId { get; set; }
    }

    internal event EventHandler<KeyboardEventArgs>? KeyboardPressed;

    private void ProcessKeyboardPressed(int deviceId)
    {
        var keyboardEvent = new KeyboardEventArgs
        {
            DeviceId = deviceId
        };
        KeyboardPressed?.Invoke(this, keyboardEvent);
        if (_mappings.TryGetValue(deviceId, out var culture))
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(culture);
        }
    }
    
    public void AddLayoutMapping(int deviceId, int cultureListIndex)
    {
        _mappings.Add(deviceId, Cultures[cultureListIndex]);
    }
    
    public void RemoveLayoutMapping(int deviceId)
    {
        _mappings.Remove(deviceId);
    }
}