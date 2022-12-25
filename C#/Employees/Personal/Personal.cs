using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject
{
    public class Personal
    {
        public string name;
        public string position;
        public double salary;
        public int age;
        public static int counter = 0;

        public Personal()
        {
        }
        public Personal(string name, string position, int salary, int age)
        {
            this.name = name;
            this.position = position;
            this.salary = salary;
            this.age = age;
            counter++;
        }

        public static int NumberOfEmp()
        {
            return counter;
        }

        public double RaiseSalary(double rate)
        {
            return salary += salary * rate / 100;
        }

        public static void AverageAge(List<Personal> personal)
        {
            double avrgAge = 0;

            foreach (var p in personal)
            {
                avrgAge += p.age;
            }

            avrgAge /= NumberOfEmp();

            Console.WriteLine("The avarage age of personal is: {0}", Math.Round(avrgAge, 1));
        }
        
        public static void Fire(List<Personal> personal, Personal person)
        {
            personal.Remove(person);

            counter--;
        }

        public static double CalculeSalary(double rate, double hours)
        {
            double salary;

            salary = hours * rate;

            return salary;
        }
    }
}
