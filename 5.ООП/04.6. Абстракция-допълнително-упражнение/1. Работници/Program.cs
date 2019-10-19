using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Работници
{
    public abstract class BaseEmployee
    {
        private string employeeID;
        private string employeeName;
        private string employeeAddress;
        
        public string EmployeeID { get => employeeID; set => employeeID = value; }
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public string EmployeeAddress { get => employeeAddress; set => employeeAddress = value; }

        public BaseEmployee(string employeeID, string employeeName, string employeeAddress)
        {
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            EmployeeAddress = employeeAddress;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Работник {EmployeeName} - {EmployeeID}, от отдел {GetDepartment()}, живее на адрес {EmployeeAddress}.");
        }

        public abstract double CalculateSalary(int workingHours);

        public abstract string GetDepartment();
    }

    public class FullTimeEmployee : BaseEmployee
    {
        private string employeePosition;
        private string employeeDepartment;

        public FullTimeEmployee(string employeeID, string employeeName,string employeeAddress, 
                                string employeePosition, string employeeDepartment)
            : base(employeeID, employeeName, employeeAddress)
        {
            this.employeePosition = employeePosition;
            this.employeeDepartment = employeeDepartment;
        }

        public override void Show() 
        {
            base.Show();
            Console.WriteLine($"From department {GetDepartment()}, and my posititon is {employeePosition}");
        } 

        public override double CalculateSalary(int workingHours)
        {
            return 250 + (workingHours) *10.80;
        }

        public override string GetDepartment()
        {
            return employeeDepartment;
        }
    }
    public class ContractEmployee : BaseEmployee
    {
        private string employeeTask;
        private string employeeDepartment;

        public string EmployeeTask { get => employeeTask; set => employeeTask = value; }
        public string EmployeeDepartment { get => employeeDepartment; set => employeeDepartment = value; }

        public ContractEmployee(string employeeID, string employeeName, string employeeAddress, string employeeTask, string employeeDepartment)
            :base(employeeID, employeeName, employeeAddress)
        {
            this.EmployeeTask = employeeTask;
            this.EmployeeDepartment = employeeDepartment;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"My task is {employeeTask}!");
        }
        public override double CalculateSalary(int workingHours)
        {
            return 250 + (workingHours) * 20;
        }
        public override string GetDepartment()
        {
            return employeeDepartment;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BaseEmployee Pesho = new FullTimeEmployee("10", "Pesho", "Lom", "worker", "market");
            Pesho.Show();
            BaseEmployee Gosho = new ContractEmployee("15", "Gosho", "Montana", "selling stuff", "online marketing");
            Gosho.Show();
        }
    }
}
