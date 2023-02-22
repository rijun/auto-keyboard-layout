using System.Globalization;

namespace Backend;

public class Backend
{
    public List<CultureInfo> Cultures { get; }
    private readonly RawInput.RawInput _rawinput;

    public Backend()
    {
        Cultures = new List<CultureInfo>();
        foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
        {
            Cultures.Add(lang.Culture);
        }
    }

    private void ProcessKeyboardPressed(int deviceId)
    {
        throw new NotImplementedException();
    }
}