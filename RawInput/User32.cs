// ReSharper disable InconsistentNaming
using System.Runtime.InteropServices;

namespace RawInput;

public static class User32
{
    [DllImport("User32.dll", SetLastError = true)]
    internal static extern bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevice, uint uiNumDevices,
        uint cbSize);

    [DllImport("User32.dll", SetLastError = true)]
    internal static extern uint GetRawInputData(IntPtr hRawInput, Command uiCommand, [Out] IntPtr pData,
        [In, Out] ref uint pcbSize, uint cbSizeHeader);

    [DllImport("User32.dll", SetLastError = true)]
    internal static extern uint GetRawInputData(IntPtr hRawInput, Command uiCommand, [Out] RAWINPUT pData,
        [In, Out] ref uint pcbSize, uint cbSizeHeader);

    public const ushort WM_INPUT = 0x00FF;

    internal const uint WM_KEYDOWN = 0x0100;
    internal const uint WM_SYSKEYDOWN = 0x0104;
}