﻿

namespace DungeonsGame
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}
