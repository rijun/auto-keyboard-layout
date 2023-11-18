using System.Globalization;

namespace TrayApplication;

public class Backend : Form
{
    /// <summary>
    /// Dictionary holding the mappings between input devices and languages.
    /// </summary>
    private readonly Dictionary<int, CultureInfo> _mappings;

    public Backend()
    {
        _mappings = new();
        Cultures = new();
        Devices = new();

        foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
        {
            Cultures.Add(lang.Culture);
        }

        RawInput.RawInput.RegisterRawInput(Handle);
    }

    internal event EventHandler? NewDeviceFound;
    internal event EventHandler<KeyboardEventArgs>? KeyboardPressed;

    public List<CultureInfo> Cultures { get; }
    public List<int> Devices { get; }

    /// <summary>
    /// Inject HandleWmInputEvent into the WndProc method.
    /// </summary>
    /// <param name="message"></param>
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

    private bool HandleWmInputEvent(Message message)
    {
        if (!RawInput.RawInput.ProcessRawInput(message.LParam, out var deviceId)) return false;
        if (!Devices.Contains(deviceId))
        {
            Devices.Add(deviceId);
            NewDeviceFound?.Invoke(this, EventArgs.Empty);
        }
        // ProcessKeyboardPressed(deviceId);
        return true;
    }

    private void ProcessKeyboardPressed(int deviceId)
    {
        // KeyboardPressed?.Invoke(this, new KeyboardEventArgs { DeviceId = deviceId });

        // Set current input language to language mapped to the input device
        if (_mappings.TryGetValue(deviceId, out CultureInfo? culture))
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

    internal class KeyboardEventArgs : EventArgs
    {
        public int DeviceId { get; set; }
    }
}