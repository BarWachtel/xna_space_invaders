using System;

namespace A16_Ex01_Bar_301797445_Elad
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Invaders())
                game.Run();
        }
    }
#endif
}
