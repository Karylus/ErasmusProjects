﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject
{
    public class IPersonal
    {
        public void Fire(List<IPersonal> personal);
    }

    public class Boss : IPersonal
    {
        public Boss (string name, string position, int salary, int age, int extra)
        {
            this.Position = "Boss";
            this.Extra = extra;
            this.Salary = salary + extra;
            this.Name = name;
            this.Position = position;
            this.Salary = salary;
            this.Age = age;
            counter++;
        }

        protected string _name;
        protected string _position;
        protected double _salary;
        protected int _age;
        protected static int counter = 0;
        private int _extra;

        public int Extra
        {
            get { return _extra; }
            set { _extra = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public static int NumberOfEmp()
        {
            return counter;
        }

        public double RaiseSalary(double rate)
        {
            return Salary += Salary * rate / 100;
        }

        public static void AverageAge(List<IPersonal> personal)
        {
            double avrgAge = 0;

            foreach (var p in personal)
            {
                avrgAge += p.Age;
            }

            avrgAge /= NumberOfEmp();

            Console.WriteLine("The avarage age of personal is: {0}", Math.Round(avrgAge, 1));
        }

        public virtual void Fire(List<IPersonal> personal)
        {
            personal.Remove(this);

            counter--;
        }

        public static double CalculeSalary(double rate, double hours)
        {
            double salary;

            salary = hours * rate;

            return salary;
        }

        public override void Fire(List<IPersonal> personal)
        {
            Console.WriteLine("The boss can't be fired\n");
        }

    }
}
