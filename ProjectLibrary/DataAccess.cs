using ProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public static class DataAccess
    {
        public static List<CustomerModel> GetCustomers()
        {
            List<CustomerModel> output = new List<CustomerModel>();

            output.Add(new CustomerModel { CompanyName = "Acme", HourlyRate = 150 });
            output.Add(new CustomerModel { CompanyName = "ABC", HourlyRate = 125 });

            return output;
        }

        public static EmployeeModel GetEmployeeInfo()
        {
            EmployeeModel output = new EmployeeModel { FirstName = "xxx", LastName = "zzz", HourlyRate = 15 };

            return output;
        }

        public static List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> allEmployees = new List<EmployeeModel>();

            allEmployees.Add(new EmployeeModel { FirstName = "aaa", LastName = "bbb", HourlyRate = 10 });
            allEmployees.Add(new EmployeeModel { FirstName = "ccc", LastName = "ddd", HourlyRate = 20 });

            return allEmployees;

        }
    }
}
