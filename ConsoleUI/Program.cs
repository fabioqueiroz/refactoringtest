using ProjectLibrary;
using ProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TimeSheetEntryModel> timeSheets = LoadTimeSheets();
            List<CustomerModel> customers = DataAccess.GetCustomers();
            //EmployeeModel currentEmployee = DataAccess.GetEmployeeInfo();
            List<EmployeeModel> currentEmployees = DataAccess.GetAllEmployees();

            customers.ForEach(x => BillCustomer(timeSheets, x));

           // DisplayEmployeePay(timeSheets, currentEmployee);
            DisplayEmployeePay(timeSheets, currentEmployees);


            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }

        private static List<TimeSheetEntryModel> LoadTimeSheets()
        {
            bool extraTimeWorked = false;
            double hoursWorked;

            List<TimeSheetEntryModel> output = new List<TimeSheetEntryModel>();

            do
            {
                Console.Write("Enter what you did: ");
                string input = Console.ReadLine();
                Console.Write("How long did you do it for: ");
                string rawTimeWorked = Console.ReadLine();

                while (double.TryParse(rawTimeWorked, out hoursWorked) == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid number given");
                    Console.Write("How long did you do it for: ");
                    rawTimeWorked = Console.ReadLine();
                }

                TimeSheetEntryModel entry = new TimeSheetEntryModel();
                entry.HoursWorked = hoursWorked;
                entry.WorkDone = input;
                output.Add(entry);

                Console.Write("Do you want to enter more time (yes/no): ");
                string answer = Console.ReadLine();
                extraTimeWorked = false;

                if (answer.ToLower() == "yes")
                {
                    extraTimeWorked = true;
                }
            } while (extraTimeWorked == true);

            Console.WriteLine();

            return output;
        }

        private static void BillCustomer(List<TimeSheetEntryModel> timeSheets, CustomerModel customer)
        {
            double totalHours = TimeSheetProcessor.CalcuateHoursWorked(timeSheets, customer.CompanyName);

            Console.WriteLine($"Simulating Sending email to {customer.CompanyName}");
            Console.WriteLine("Your bill is $" + (decimal)totalHours * customer.HourlyRate + " for the hours worked.");
            Console.WriteLine();
        }

        //private static void DisplayEmployeePay(List<TimeSheetEntryModel> timeSheets, EmployeeModel employee)
        //{
        //    decimal totalAmountToPay = TimeSheetProcessor.CalculateEmployeePay(timeSheets, employee);
        //    Console.WriteLine($"You will get paid $ {totalAmountToPay} for your time.");
        //}

        private static void DisplayEmployeePay(List<TimeSheetEntryModel> timeSheets, List<EmployeeModel> employees)
        {
            decimal totalAmountToPay = TimeSheetProcessor.CalculateTotalEmployeePay(timeSheets, employees);
            //List<decimal> salaries = TimeSheetProcessor.CalculateEachEmployeePay(timeSheets, employees);

            Console.WriteLine($"In total you will get paid $ {totalAmountToPay} for your time.");
            Console.WriteLine();

            foreach (EmployeeModel person in employees)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} will get paid $ {person.Salary} for their work.");

                //foreach (var eachEmployeePay in salaries)
                //{
                //    Console.WriteLine($"{person.FirstName} {person.LastName} will get paid $ {eachEmployeePay} for their work.");
                //}
          
            }
        }
    }
}
