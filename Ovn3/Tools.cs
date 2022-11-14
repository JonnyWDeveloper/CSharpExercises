using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn3
{
    public static class Tools
    {
        public static void Print(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine(text);
            }
        }
        public static void SetFontColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        public static void SetBackgroundColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }
    }


}
