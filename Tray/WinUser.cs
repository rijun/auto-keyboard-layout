using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks; 

namespace Tray
{
    internal class WinUser
    {
        internal const int SPI_GETDEFAULTINPUTLANG = 0x0059;
        internal const int SPI_SETDEFAULTINPUTLANG = 0x005A;

        /* BOOL SystemParametersInfoA(
    [in] UINT uiAction,
    [in] UINT uiParam,
    [in, out] PVOID pvParam,
    [in] UINT fWinIni
   );
*/
        [DllImport("user32.dll")]
        internal static extern Boolean SystemParametersInfoA(UInt32 uiAction, UInt32 uiParam, IntPtr pvParam, UInt32 fWinIni);

        internal static (bool, IntPtr) GetKeyboardLayout()
        {
            IntPtr inputLanguage = new();
            bool result = WinUser.SystemParametersInfoA(WinUser.SPI_GETDEFAULTINPUTLANG, 0, inputLanguage, 0);
            return (result, inputLanguage);
        }
    }
}
