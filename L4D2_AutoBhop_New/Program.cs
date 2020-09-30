using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace L4D2_AutoBhop_New
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() == 0)
            {
                MessageBox.Show("Type PlayerBase Value\nUse to cmd : L4D2_AutoBhop_New PlayerBase mFlag");
                Environment.Exit(0);
            }

            Model.player_base = Convert.ToInt32(args[0], 16);
            Model.mflags = (int)(Convert.ToInt32(string.IsNullOrEmpty(args[1]) ? "0xF0" : args[1]), 16);

            Console.WriteLine("[-] Find Left 4 Dead 2 process...");
            Process gameProcess = Process.GetProcessesByName("left4dead2").First();
            if (gameProcess != null)
            {
                Console.WriteLine("[+] Left 4 Dead 2 was found.");
                Model.process_handle = gameProcess.MainWindowHandle;
                Model.game_handle = WinAPI.OpenProcess(WinAPI.ProcessAccessFlags.All, false, gameProcess.Id);
                Model.module_base = Util.get_module_base(gameProcess.Id, "client.dll");
                Console.WriteLine(Model.module_base);
                Player.Start();
                AutoBhop.Start();
                Console.WriteLine("[+] Process Attached! Have Fun :)");
                Console.WriteLine();
                Console.WriteLine("[?] Command Hotkey List");
                Console.WriteLine("[-] F1 : AutoBhop On/Off");
                Console.WriteLine("[-] F2 : Exit Program");
                Console.WriteLine();
                Console.WriteLine("[★] AutoBhop : OFF");
                
                do
                {
                    bool F1_Status = Util.IsKeyDown(System.Windows.Forms.Keys.F1);
                    bool F2_Status = Util.IsKeyDown(System.Windows.Forms.Keys.F2);

                    

                    if (F1_Status && !Model.autobhop)
                    {
                        Model.autobhop = true;

                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Util.ClearCurrentConsoleLine();
                        Console.WriteLine("[★] AutoBhop : ON");
                    }
                    else if (F1_Status && Model.autobhop)
                    {
                        Model.autobhop = false;

                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Util.ClearCurrentConsoleLine();
                        Console.WriteLine("[★] AutoBhop : OFF");
                    }

                    if (F2_Status)
                    {
                        Environment.Exit(0);
                    }

                    Thread.Sleep(100);
                } while (true);
            }
            else
                Console.WriteLine("[!] Autobhop attach failed. first start l4d2 :(");

            Console.WriteLine("[-] Press any Key close program");
            Console.ReadLine();
        }
    }
}
