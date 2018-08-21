using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Models
{
    public class EmployeeModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal HourlyRate { get; set; }

        public TimeSheetEntryModel TimeSheet { get; set; }

        public decimal Salary { get => (decimal) TimeSheet.HoursWorked * HourlyRate; }
    }
}
