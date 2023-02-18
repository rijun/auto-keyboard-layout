// ReSharper disable InconsistentNaming
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RawInput
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct RAWINPUTDEVICE
    {
        internal HidUsagePage usUsagePage;
        internal HidUsageId usUsage;
        internal DeviceFlags dwFlags;
        internal IntPtr hwndTarget;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal class RAWINPUT
    {
        internal RAWINPUTHEADER header;
        internal RAWDATA data;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RAWINPUTHEADER
    {
        internal uint dwType;
        internal uint dwSize;
        internal IntPtr hDevice;
        internal IntPtr wParam;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct RAWDATA
    {
        [FieldOffset(0)] internal RAWMOUSE mouse;
        [FieldOffset(0)] internal RAWKEYBOARD keyboard;
        [FieldOffset(0)] internal RAWHID hid;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct RAWMOUSE
    {
        [FieldOffset(0)] internal ushort usFlags;
        [FieldOffset(4)] internal uint ulButtons;
        [FieldOffset(4)] internal ushort usButtonFlags;
        [FieldOffset(6)] internal ushort usButtonData;
        [FieldOffset(8)] internal uint ulRawButtons;
        [FieldOffset(12)] internal int lLastX;
        [FieldOffset(16)] internal int lLastY;
        [FieldOffset(20)] internal uint ulExtraInformation;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RAWKEYBOARD
    {
        internal ushort MakeCode;
        internal ushort Flags;
        internal ushort Reserved;
        internal ushort VKey;
        internal uint Message;
        internal ulong ExtraInformation;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RAWHID
    {
        internal uint dwSizHid;
        internal uint dwCount;
        internal byte bRawData;
    }
}