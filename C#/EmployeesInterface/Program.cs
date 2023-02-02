using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalProject;
using System.IO;

public delegate void printString(string str);

namespace Employees
{
    internal class Program
    {
        static void PrintSalary(List<Personal> per)
        {
            foreach (var p in per)
            {
                Console.WriteLine("Name: {0}, Salary($): {1}",
                    p.Name, p.Salary);
            }

            Console.WriteLine("-------------------------------------\n");
        }

        static void PrintPersonal(List<Personal> per)
        {
            foreach (var p in per)
            {
                Console.WriteLine("Name: {0}, Position: {1}, Salary: {2}, Age: {3}",
                    p.Name, p.Position, p.Salary, p.Age);
            }

            Console.WriteLine("-------------------------------------\n");
        }

        static double AverageSalary(List<Personal> per)
        {
            double average = per.Average(p => p.Salary);

            return average;
        }

        static void SalaryStadistics(List<Personal> per)
        {
            double max = 0, min = 10e10, temp;

            for (int i = 0; i < per.Count; i++)
            {
                temp = per[i].Salary;

                if (temp < min)
                    min = temp;

                else if (temp > max)
                    max = temp;
            }

            per.Max(p => p.Salary);

            double average = AverageSalary(per);

            Console.WriteLine(" The average salary is: {0}\n The maximum salary is: {1}\n " +
                "The minimum salary is: {2}\n", average, max, min);

            Console.WriteLine("-------------------------------------\n");

        }

        static void Main()
        {
            List<Personal> personal = new List<Personal>();
            Boss p1 = new Boss("Felipe", "Boss", 500, 22, 300);
            Personal p2 = new Personal("Teresa", "Manager", 1000, 28);
            Personal p3 = new Personal("Elon", "Ceo", 5500, 30);
            Personal p4 = new Personal("Juan", "Seller", 2500, 25);
            Personal p5 = new Personal("Paquito", "Cleaner", 3100, 27);

            personal.Add(p1);
            personal.Add(p2);
            personal.Add(p3);
            personal.Add(p4);
            personal.Add(p5);

            PrintPersonal(personal);

            Console.WriteLine("Number of employees: {0} ", Personal.NumberOfEmp());

            p1.RaiseSalary(10);

            Personal.AverageAge(personal);

            PrintPersonal(personal);

            p1.Fire(personal);
            p2.Fire(personal);

            Console.WriteLine("Number of employees: {0} ", Personal.NumberOfEmp());

            Personal.AverageAge(personal);

            double salaryExample = Personal.CalculeSalary(35, 40);

            Console.WriteLine("\nIf the rate is 35$/h and the hours 40, the salary is: {0}\n", salaryExample);

            PrintPersonal(personal);

            PrintSalary(personal);

            SalaryStadistics(personal);

            var result = from p in personal
                         where p.Salary > AverageSalary(personal)
                         select p;

            List<string> lines = new List<string>();

            string header = "The employees whose salary is more than the average are:";

            Console.WriteLine(header);
            lines.Add(header);

            foreach(Personal per in result)
            {
                string body = per.Name + " - " + per.Salary + "$";
                Console.WriteLine(body);
                lines.Add(body);
            }

            File.WriteAllLines("MoreSalaryAverage.txt", lines);

            Console.WriteLine("-------------------------------------\n");
        }
    }
}
