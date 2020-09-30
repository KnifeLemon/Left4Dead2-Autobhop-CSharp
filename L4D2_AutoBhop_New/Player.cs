using System;
using System.Collections.Generic;
using System.Threading;

namespace L4D2_AutoBhop_New
{
    public static class Player
    {
        static int p_base;
        static int flag;

        public static void Start()
        {
            Thread th = new Thread(readMemory);
            th.Start();
        }

        static void readMemory()
        {
            do
            {
                if (Model.autobhop)
                {
                    WinAPI.ReadProcessMemory(Model.game_handle, Model.module_base + Model.player_base, ref p_base, sizeof(int), 0);
                    WinAPI.ReadProcessMemory(Model.game_handle, p_base + Model.mflags, ref flag, sizeof(int), 0);
                }
            } while (true);
        }

        public static bool chk_player_ground()
        {
            return flag == 129 || flag == 131 || flag == 641 || flag == 643;
        }
    }
}
