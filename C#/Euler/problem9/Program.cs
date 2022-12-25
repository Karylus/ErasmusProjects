namespace problem9
{
    internal class Program
    {
        static bool IsPythagoreanTriplet (int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return false;
            }

            return a * a + b * b == c * c;
        }
        static void Main()
        {
            for (int c = 413; c < 500; c++)
            {
                int max = Math.Max(1, 1000 - c - (c - 1));
                int min = (int)Math.Floor(Convert.ToDecimal(Math.Min(332, (1000 - c))) / 2);

                for (int a = max; a < min +1; a++)
                {
                    int b = 1000 - c - a;

                    if (IsPythagoreanTriplet(a, b, c))
                    {
                        int product = a * b * c;

                        Console.WriteLine(product);
                    }
                }   
            }
        }
    }
}