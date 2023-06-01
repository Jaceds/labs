// // See https://aka.ms/new-console-template for more information
namespace lab2
{
    class Program{
        static double Example(double x) {
             double y = Math.Round(Math.Pow(x,3) - 4 * Math.Pow(x,2) - (5*x) + 9 + Math.Cos(x),2);
            

return y ;
}
        static void Main(string[] args)
        {
            Console.Write("Enter x : ");
        var s1 = Console.ReadLine();
        if(s1 is not null ){
        double a  = double.Parse(s1);
        Console.WriteLine( Example(a));
}}
}
}