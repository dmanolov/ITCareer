using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Списък_на_служители
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>();

            int number = int.Parse(Console.ReadLine());
            while (number > 0)
            {
                var line = Console.ReadLine().Split();

                //име, заплата, длъжност, отдел, ел.поща и възраст
                var employee = new Employee();
                employee.name = line[0];
                employee.salary = double.Parse(line[1]);
                employee.position = line[2];
                employee.departament = line[3];
                if (line.Length > 4)
                    if(line[4].IndexOf("@") > 0)
                    {
                        employee.email = line[4];
                        if (line.Length > 5)
                            employee.age = int.Parse(line[5]);
                    }
                    else employee.age = int.Parse(line[4]);

                employees.Add(employee);
                number--;
            }

            if (employees.Count == 0) return;

            var maxAverageSalaryIndex = 0;
            // TODO: намираме отдела с най-висока средна заплата
            var departament = employees[maxAverageSalaryIndex].departament;

            employees.Sort((x, y) => (int)(y.salary - x.salary));

            Console.WriteLine();
            Console.WriteLine("Highest Average Salary: " + departament);
            foreach (var e in employees)
            {
                if (e.departament == departament)
                {
                    Console.WriteLine("{0} {1:0.00} {2} {3}", e.name, e.salary, 
                        (e.email == ""? "n/a": e.email), (e.age == 0? -1: e.age));
                }
            }
            
        }
    }
}
