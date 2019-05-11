using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Фирми
{
    class Company
    {
        private string name;
        private List<Employee> employees;
        private string city;
        public string Name
        {
            get => name;
            set
            {
                if (value.Length > 2 )
                    name = value;
                else throw new System.ArgumentException("Invalid company name");
            }
        }
        public string City
        {
            get => city;
            set
            {
                if (value.Length > 4 && char.IsUpper(value[0])) 
                    city = value;
                else throw new System.ArgumentException("Invalid city");
            }

        }

        public Company(string name, string city)
        {
            this.Name = name;
            this.employees = new List<Employee>();
            this.City = city;
        }

        public override string ToString()
        {
            string result = $"Company {name} from {city} has the following employees:" + Environment.NewLine;
            foreach (var e in employees)
            {
                result = result + "--->" + e.ToString() + Environment.NewLine;
            }

            return result;
        }

        public void HireEmployee(Employee emp)
        {
            employees.Add(emp);
        }

        public void FireEmployee(string employeeId)
        {
            foreach (var e in employees)
            {
                if(e.Id == employeeId)
                {
                    employees.Remove(e);
                    break;
                }

            }
        }

        public void IncreaseSalaries(double value)
        {
            foreach (var e in employees)
            {
                e.Salary += value;
            }
        }

        public void DecreaseSalaries(double value)
        {
            foreach (var e in employees)
            {
                if(e.Salary >= value)
                    e.Salary -= value;
            }
        }

        public Employee GetMostHighPaidEmployee()
        {
            double maxSalary = 0;
            Employee mostPaidEmployee = null;
            foreach (var e in employees)
            {
                if (e.Salary > maxSalary)
                {
                    maxSalary = e.Salary;
                    mostPaidEmployee = e;
                }
            }
            return mostPaidEmployee;
        }

        public List<Employee> GetTopThreeMostHighPaidEmployees()
        {
            return employees.OrderByDescending(e => e.Salary).Take(3).ToList();
        }

        public bool CheckEmployeeIsPresent(string employeeId)
        {
            bool found = false;
            foreach (var e in employees)
            {
                if (e.Id == employeeId)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public double GetAverageEmployeeSalary()
        {
            return employees.Average(e => e.Salary);
        }

    }
}
