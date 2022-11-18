using System;
using System.Collections.Generic;

namespace lesson3
{
    class Personal
    {
        public String name;
        public String position;
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
        public static int numberOfEmp()
        {
            return counter;
        }
        public double race(double rate)
        {
            return salary += salary * rate / 100;
        }
        public static void Avrg(List<Personal> personals)
        {
            double avrgAge = 0;
            foreach (var p in personals)
            {
                avrgAge += p.age;
            }
            avrgAge = avrgAge / numberOfEmp();
            Console.WriteLine("The Avarage Age of People is: {0}", Math.Round(avrgAge, 1));
        }
        public static void PrintPersonels(List<Personal> personals)
        {
            foreach (var p in personals)
            {
                Console.WriteLine("Name: {0}, Position: {1}, Salary: {2}, Age: {3}", p.name, p.position, p.salary, p.age);
            }
        }
        public static Personal Fire(List<Personal> personals, Personal person)
        {
            personals.Remove(person);
            return person = null;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Personal> personals = new List<Personal>();
            Personal p1 = new Personal("Oguz", "Student", 1500, 22);
            Personal p2 = new Personal("Berk", "Manager", 2000, 28);
            Personal p3 = new Personal("Aydin", "Ceo", 2500, 30);

            personals.Add(p1);
            personals.Add(p2);
            personals.Add(p3);

            Personal.PrintPersonels(personals);
            Console.WriteLine("number of employee: {0} ", Personal.numberOfEmp());

            p1.race(10);
            
            Personal.Avrg(personals);
            
            Console.WriteLine("-------------------------------------");
            
            Personal.PrintPersonels(personals);
            
            Personal.Fire(personals, p1);
            
            Personal.Avrg(personals);
            
            Console.WriteLine(p1.age);
            
            Console.WriteLine("-------------------------------------");
            
            //Console.WriteLine(p1.name);
            
            Console.WriteLine("-------------------------------------");
            
            Personal.PrintPersonels(personals);
        }
    }
}