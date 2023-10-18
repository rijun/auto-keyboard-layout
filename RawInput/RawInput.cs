using System.Runtime.InteropServices;

namespace RawInput;

public static class RawInput
{
    public static void RegisterRawInput(IntPtr windowHandle)
    {
        var rid = new RAWINPUTDEVICE[1];

        rid[0].usUsagePage = HidUsagePage.HID_USAGE_PAGE_GENERIC;
        rid[0].usUsage = HidUsageId.HID_USAGE_GENERIC_KEYBOARD;
        rid[0].dwFlags = DeviceFlags.RIDEV_INPUTSINK;
        rid[0].hwndTarget = windowHandle;

        if (!User32.RegisterRawInputDevices(rid, (uint)rid.Length, (uint)Marshal.SizeOf(rid[0])))
        {
            throw new ApplicationException("Failed to register raw input device(s).");
        }
    }

    /// <summary>
    /// Returns the device id from the RAWINPUT structure.
    /// </summary>
    /// <param name="lParam">A handle to the RAWINPUT structure. This comes from the lParam in WM_INPUT.</param>
    /// <param name="deviceId">Id of the currently triggered device.</param>
    /// <returns>True device id could be retrieved.</returns>
    public static bool ProcessRawInput(IntPtr lParam, out int deviceId)
    {
        uint rawInputDataSize = 0;
        _ = User32.GetRawInputData(lParam, Command.RID_INPUT, IntPtr.Zero, ref rawInputDataSize,
            (uint)Marshal.SizeOf(typeof(RAWINPUTHEADER)));

        RAWINPUT inputData = new();
        var dataSize = User32.GetRawInputData(lParam, Command.RID_INPUT, inputData, ref rawInputDataSize,
            (uint)Marshal.SizeOf(typeof(RAWINPUTHEADER)));
            
        deviceId = 0;
        if (rawInputDataSize != dataSize) return false;
        if (inputData.data.keyboard.Message is not (User32.WM_KEYDOWN or User32.WM_SYSKEYDOWN)) return false;
            
        deviceId = (int)inputData.header.hDevice;
        return true;
    }
}