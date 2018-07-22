using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class WarningManager
    {
        public static void RepeatInsert()
        {
            Console.WriteLine();
            Console.WriteLine("Invalid number");
            Console.Write("How long did you do it for: ");
            string rawTimeWorked = Console.ReadLine();
        }
    }
}
