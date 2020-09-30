using System;
using System.Threading;
using System.Windows.Forms;

namespace L4D2_AutoBhop_New
{
    public static class AutoBhop
    {
        public static void Start()
        {
            Thread th = new Thread(Bhop_Tick);
            th.Start();
        }

        public static void Bhop_Tick()
        {
            do
            {
                if (Model.autobhop)
                {
                    bool isPlayerGround = Player.chk_player_ground();
                    bool keyStatus = Util.IsKeyDown(Keys.Space);

                    if (keyStatus && isPlayerGround)
                    {
                        WinAPI.SendMessage(Model.process_handle, WinAPI.WM_KEYDOWN, Convert.ToInt32(Keys.Space), 0x390000);
                    }
                    else if (keyStatus && !isPlayerGround)
                    {
                        WinAPI.SendMessage(Model.process_handle, WinAPI.WM_KEYUP, Convert.ToInt32(Keys.Space), 0x390000);
                    }
                }
            } while (true);
        }
    }
}
