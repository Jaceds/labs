using System;
using System.Linq.Expressions;

namespace lab_2_2
{
    public class Program
    {

        static void Main(string[] args)
        {
            double x = 1.25,
             b = 6.75,
             dx = 0.25;

            Console.Write(" \tx     ");
            Console.Write("  y=f(x)");
            Console.WriteLine(' ');
            do
            {

                double ctg_x = Math.Round(Math.Pow(x, (double)1 / 3) + Math.Log(3 * x), 2);
                x = Math.Round(x, 2);
                if (x > 0)
                    Console.Write(" \t{0}", x);
                if (x < 0)
                    Console.Write(" \t{0}", x);
                if (ctg_x > 0)
                    Console.Write("\t{0}\n ", ctg_x);
                if (ctg_x < 0)
                    Console.Write("\t{0}\n ", ctg_x);
                x += dx;
            } while (x <= b);
            Console.ReadLine();
        }
    }
}