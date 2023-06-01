using System;
namespace lab_1
{
    public class Program
    {
        static public double Hypotenuse(double a, double b)
        {
            double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            Console.WriteLine("Гiпотенуза {0}", Math.Round(c, 2));
            return c;
        }
        static public double Perimetr(double a, double b)
        {
            double c = Hypotenuse(a, b);
            double p = a + b + c;
            Console.WriteLine("Перимерт {0}", Math.Round(p, 2));
            return p;
        }
        static void Main(string[] args)
        {
            Console.Write("Введiть перший катет : ");
            var S1 = Console.ReadLine();
            Console.Write("Введiть другий катет : ");
            var S2 = Console.ReadLine();
            if (S1 != null && S2 != null)
            {
                double a =Math.Round(double.Parse(S1),2) ;
                double b = Math.Round(double.Parse(S2), 2);
                Perimetr(a, b);
            }

        }
    }
}