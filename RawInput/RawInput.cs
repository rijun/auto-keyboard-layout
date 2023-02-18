using System.Runtime.InteropServices;
using System.Diagnostics;

namespace RawInput
{
    public class RawInput
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowHandle"></param>
        /// <exception cref="ApplicationException"></exception>
        public RawInput(IntPtr windowHandle)
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
        /// 
        /// </summary>
        /// <param name="lParam"></param>
        public void ProcessRawInput(IntPtr lParam)
        {
            uint rawInputDataSize = 0;
            _ = User32.GetRawInputData(lParam, Command.RID_INPUT, IntPtr.Zero, ref rawInputDataSize,
                (uint)Marshal.SizeOf(typeof(RAWINPUTHEADER)));

            RAWINPUT inputData = new();
            var dataSize = User32.GetRawInputData(lParam, Command.RID_INPUT, inputData, ref rawInputDataSize,
                (uint)Marshal.SizeOf(typeof(RAWINPUTHEADER)));
            if (rawInputDataSize != dataSize)
            {
                Debug.WriteLine("Error getting the RawInput buffer");
                return;
            }

            var device = (int)inputData.header.hDevice;

            if (inputData.data.keyboard.Message == User32.WM_KEYDOWN ||
                inputData.data.keyboard.Message == User32.WM_SYSKEYDOWN)
            {
                Debug.WriteLine($"device {device}");
            }
        }
    }
}