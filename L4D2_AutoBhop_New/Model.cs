using System;

namespace L4D2_AutoBhop_New
{
    public static class Model
    {
        public static int player_base { get; set; }

        public static int mflags { get; set; }

        public static bool autobhop { get; set; }

        public static IntPtr game_handle { get; set; }

        public static IntPtr process_handle { get; set; }

        public static int module_base { get; set; }

        public static int module_size { get; set; }
    }
}
