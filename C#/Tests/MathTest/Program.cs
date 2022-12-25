using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library_test;

namespace MathTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declare class from library_test.dll
            Class1 math = new Class1();

            // Declare variables and use methods from library_test
            float substract = math.Substract(5, 2);
            float multiply = math.Multiply(5, 2);
            float devide = math.Devide(5, 2);
            float power = math.Power(5);

            Console.WriteLine("This Application uses functions from library_test.dll to do simple calculations");

            // Print results on screen
            Console.WriteLine(substract);
            Console.WriteLine(multiply);
            Console.WriteLine(devide);
            Console.WriteLine(power);

            Console.ReadLine();
        }
    }
}
