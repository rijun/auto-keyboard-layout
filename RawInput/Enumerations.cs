// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
#pragma warning disable CA1069
namespace RawInput;

public enum HidUsagePage : ushort
{
    HID_USAGE_PAGE_GENERIC = 0x01,  // Generic Desktop Controls
    HID_USAGE_PAGE_GAME    = 0x05,  // Game Controls
    HID_USAGE_PAGE_LED     = 0x08,  // LEDs
    HID_USAGE_PAGE_BUTTON  = 0x09,  // Button
}

public enum HidUsageId : ushort
{
    HID_USAGE_GENERIC_POINTER = 0x01,               // Pointer 	            
    HID_USAGE_GENERIC_MOUSE = 0x02,                 // Mouse 	                
    HID_USAGE_GENERIC_JOYSTICK = 0x04,              // Joystick 	            
    HID_USAGE_GENERIC_GAMEPAD = 0x05,               // Game Pad 	            
    HID_USAGE_GENERIC_KEYBOARD = 0x06,              // Keyboard 	            
    HID_USAGE_GENERIC_KEYPAD = 0x07,                // Keypad 	                
    HID_USAGE_GENERIC_MULTI_AXIS_CONTROLLER = 0x08  // Multi-axis Controller
}

public enum DeviceFlags : uint
{
    RIDEV_REMOVE = 0x00000001,          // Removes the top level collection from the inclusion list
    RIDEV_EXCLUDE = 0x00000010,         // Specifies the top level collections to exclude when reading a complete usage page
    RIDEV_PAGEONLY = 0x00000020,        // Specifies all devices whose top level collection is from the specified usUsagePage
    RIDEV_NOLEGACY = 0x00000030,        // Prevents any devices specified by usUsagePage or usUsage from generating legacy messages
    RIDEV_INPUTSINK = 0x00000100,       // Enables the caller to receive the input even when the caller is not in the foreground
    RIDEV_CAPTUREMOUSE = 0x00000200,    // Mouse button click does not activate the other window
    RIDEV_NOHOTKEYS = 0x00000200,       // Application-defined keyboard device hot keys are not handled
    RIDEV_APPKEYS = 0x00000400,         // Application command keys are handled
    RIDEV_EXINPUTSINK = 0x00001000,     // Enables the caller to receive input in the background only if the foreground application does not process it
    RIDEV_DEVNOTIFY = 0x00002000,       // Enables the caller to receive WM_INPUT_DEVICE_CHANGE notifications for device arrival and device removal
}

public enum Command : uint
{
    RID_HEADER = 0x10000005, // Get the header information from the RAWINPUT structure.
    RID_INPUT = 0x10000003   // Get the raw data from the RAWINPUT structure.
}