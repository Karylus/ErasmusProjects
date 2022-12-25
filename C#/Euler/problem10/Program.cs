using System;

namespace problem10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int last = 2000000;
            int sum = 0;

            for (int i = 2; i < last; i++) {
                bool flag = true;

                for (int j = 2; j < Math.Sqrt(i) + 1; j++)
                {
                    if (i % j == 0)
                    {
                        flag = false;
                        break;
                    }
                        
                    
                }

                if (flag)
                    sum += i;
            }

            Console.WriteLine(sum);
        }
    }
}