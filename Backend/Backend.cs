﻿using System.Globalization;
using RawInput;

namespace Backend;

public class Backend
{
    public List<CultureInfo> Cultures { get; }

    public Backend()
    {
        Cultures = new List<CultureInfo>();
        foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
        {
            Cultures.Add(lang.Culture);
        }
    }

    public void RegisterRawInput(IntPtr windowHandle)
    {
        RawInput.RawInput.RegisterRawInput(windowHandle);
    }

    public bool HandleWmInputEvent(Message message)
    {
        if (!RawInput.RawInput.ProcessRawInput(message.LParam, out var deviceId)) return false;
        ProcessKeyboardPressed(deviceId);
        return true;
    }

    public int LastDeviceUsed { get; private set; } = 0;

    private void ProcessKeyboardPressed(int deviceId)
    {
        LastDeviceUsed = deviceId;
    }
}