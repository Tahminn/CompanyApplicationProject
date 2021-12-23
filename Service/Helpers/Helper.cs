﻿using System;

namespace Service.Helpers
{
    public static class Helper
    {
        public static void WriteToConsole(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}