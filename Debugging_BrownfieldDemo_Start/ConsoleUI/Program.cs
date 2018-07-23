using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Please note - THIS IS A BAD APPLICATION - DO NOT REPLICATE WHAT IT DOES
// This application was designed to simulate a poorly-built application that
// you need to support. Do not follow any of these practices. This is for 
// demonstration purposes only. You have been warned.
namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {

            string w, rawTimeWorked;
            int i;
            double ttl, t;
            List<TimeSheetEntry> ents = new List<TimeSheetEntry>();
            TimeSheetEntry ent = new TimeSheetEntry();

            Console.Write("Enter what you did: ");
            w = Console.ReadLine();

            Console.Write("How long did you do it for: ");
            rawTimeWorked = Console.ReadLine();

            while (double.TryParse(rawTimeWorked, out t) == false)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid number");
                Console.Write("How long did you do it for: ");
                rawTimeWorked = Console.ReadLine();

                //WarningManager.RepeatInsert();
                //WarningManager.NewRepeatInsert();

            }

            ent.HoursWorked = t;
            ent.WorkDone = w;
            ents.Add(ent);
            Console.Write("Do you want to enter more time (y/n):");

            string answer = Console.ReadLine();

            bool cont = false;

            
            if (answer.ToLower() == "y")
            {
                cont = true;
            }

            // ********************************

            else if (answer.ToLower() != "y" || answer.ToLower() != "n")
            {
                //Console.Write("Insert a valid answer (y/n): ");
                //answer = Console.ReadLine();

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Wrong option");
                    Console.Write("Insert a valid answer (y/n): ");

                    answer = Console.ReadLine();

                    if (answer.ToLower() == "y")
                    {
                        cont = true;
                        break;
                    }

                    else if (answer.ToLower() == "n")
                    {
                        cont = false;
                        break;
                    }
                }
            }

            // ********************************

            while (cont == true) 
            {
                Console.Write("Enter what you did: ");
                w = Console.ReadLine();

                Console.Write("How long did you do it for: ");
                rawTimeWorked = Console.ReadLine();

                while (double.TryParse(rawTimeWorked, out t) == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid number");
                    Console.Write("How long did you do it for: ");
                    rawTimeWorked = Console.ReadLine();
                }

                ent = new TimeSheetEntry();
                ent.HoursWorked = t;
                ent.WorkDone = w;
                ents.Add(ent);

                Console.Write("Do you want to enter more time (y/n):");

                //cont = bool.Parse(Console.ReadLine());
                answer = Console.ReadLine();

                cont = false;


                if (answer.ToLower() == "y")
                {
                    cont = true;
                }
            } 

            ttl = 0;
            for (i = 0; i < ents.Count; i++)
            {
                if (ents[i].WorkDone.ToLower().Contains("acme"))
                {
                    ttl += ents[i].HoursWorked;
                }
            }

            Console.WriteLine("Simulating Sending email to Acme");
            Console.WriteLine("Your bill is $" + ttl * 150 + " for the hours worked.");

            ttl = 0;
            for (i = 0; i < ents.Count; i++)
            {
                if (ents[i].WorkDone.ToLower().Contains("abc"))
                {
                    ttl += ents[i].HoursWorked;
                }
            }
            Console.WriteLine("Simulating Sending email to ABC");
            Console.WriteLine("Your bill is $" + ttl * 125 + " for the hours worked.");

            ttl = 0;
            for (i = 0; i < ents.Count; i++)
            {
                ttl += ents[i].HoursWorked;
            }
            if (ttl > 40)
            {
                ttl = ((ttl - 40) * 15 + (40 * 10));
                Console.WriteLine("You will get paid $" + ttl + " for your work.");
            }
            else
            {
                ttl *= 10;
                Console.WriteLine("You will get paid $" + ttl + " for your time.");
            }
            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }
       
    }

}
