using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace L4D2_AutoBhop_New
{
    public static class Util
    {
        public static bool IsKeyDown(Keys vKey)
        {
            return (WinAPI.GetAsyncKeyState(vKey) < 0);
        }

        public static int get_module_base(int process_id, string sz_module_name)
        {
            IntPtr hSnapshot = WinAPI.CreateToolhelp32Snapshot(WinAPI.SnapshotFlags.All, process_id);
            if (hSnapshot == IntPtr.Zero)
                return 0;

            WinAPI.MODULEENTRY32 module_entry = new WinAPI.MODULEENTRY32();
            module_entry.dwSize = (int)Marshal.SizeOf(typeof(WinAPI.MODULEENTRY32));
            int dw_return = 0;
            if (WinAPI.Module32First(hSnapshot, ref module_entry))
            {
                while (WinAPI.Module32Next(hSnapshot, ref module_entry))
                {
                    if (module_entry.szModule == sz_module_name)
                    {
                        dw_return = module_entry.modBaseAddr;
                        Model.module_size = module_entry.modBaseSize;
                        break;
                    }
                }
            }
            WinAPI.CloseHandle(hSnapshot);
            return dw_return;
        }
		
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
