using ProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public static class TimeSheetProcessor
    {
        public static double CalcuateHoursWorked(List<TimeSheetEntryModel> timeSheets, string companyName)
        {
            double totalHoursWorked = 0;
            for (int i = 0; i < timeSheets.Count; i++)
            {
                if (timeSheets[i].WorkDone.ToLower().Contains(companyName.ToLower()))
                {
                    totalHoursWorked += timeSheets[i].HoursWorked;
                }
            }

            return totalHoursWorked;
        }

        //public static decimal CalculateEmployeePay(List<TimeSheetEntryModel> timeSheets, EmployeeModel employee)
        //{
        //    decimal totalPay = 0;
        //    double totalHours = 0;

        //    for (int i = 0; i < timeSheets.Count; i++)
        //    {
        //        totalHours += timeSheets[i].HoursWorked;
        //    }
        //    if (totalHours > 40)
        //    {
        //        totalPay = (((decimal)(totalHours - 40) * (employee.HourlyRate * 1.5M) + (40M * employee.HourlyRate)));
        //    }
        //    else
        //    {
        //        totalPay = (decimal)totalHours * employee.HourlyRate;
        //    }

        //    return totalPay;
        //}

        public static decimal CalculateTotalEmployeePay(List<TimeSheetEntryModel> timeSheets, List<EmployeeModel> employees)
        {
            decimal totalPay = 0;

            foreach (var employee in employees)
            {
                double totalHours = 0;
                for (int i = 0; i < timeSheets.Count; i++)
                {
                    totalHours += timeSheets[i].HoursWorked;
                }
                if (totalHours > 40)
                {
                    totalPay += (((decimal)(totalHours - 40) * (employee.HourlyRate * 1.5M) + (40M * employee.HourlyRate)));
                }
                else
                {
                    totalPay += (decimal)totalHours * employee.HourlyRate;
                }
            }

            return totalPay;
        }

        public static List<decimal> CalculateEachEmployeePay(List<TimeSheetEntryModel> timeSheets, List<EmployeeModel> employees)
        {
            decimal eachPay = 0;
            List<decimal> salaries = new List<decimal>();

            foreach (var employee in employees)
            {
                double totalHours = 0;
                for (int i = 0; i < timeSheets.Count; i++)
                {
                    totalHours += timeSheets[i].HoursWorked;
                }
                if (totalHours > 40)
                {
                    eachPay = (((decimal)(totalHours - 40) * (employee.HourlyRate * 1.5M) + (40M * employee.HourlyRate)));
                }
                else
                {
                    eachPay = (decimal)totalHours * employee.HourlyRate;
                }

                salaries.Add(eachPay);
            }

            return salaries;
        }
    }
}
