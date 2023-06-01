using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace lab_2_2
{
    public class Program

    {
        static double Check()
           
        {
           var str = Console.ReadLine();
            try
            {
                double b;
              b =  double.Parse(str);
                return Math.Round(b,2);
            }
            catch 
            {
                return -1;
            }
        }
        static bool GetMethod(string str)
        {

            string[]  array= { "Так" , "так", "да" , "Y" , "Yes" , "yes" , "yea" , "ТАк","y","ДА","Tak","da","Da","TAK","tak","ТАК","ДА" };
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i] == str)
                    return true;

            }
                return false;
        }

        static double GetMax ( double[,] matrix)
        {
            double max = matrix[0,0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > max)
                        max = matrix[i, j];
            }
            return max;
        }
        static double GetMin(double[,] matrix)
        {
            double min = matrix[0,0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < min)
                        min = matrix[i, j];
            }
            return min;
        }
        static double GetAvg(double min,double max)
        {
            return (min + max) / 2;
        }

        static void Main(string[] args)
        {
            int m , n ;
            double min , max, avg ,
            checking ;
            bool method ;
            do
            {
                Console.Write("Ведiь кiлькiсть колонок : ");
                checking = Check();
                m = Convert.ToInt32(Math.Round(checking));

            } while (checking == -1);
            do
            {
                Console.Write("Ведіть кiлькiсть рядкiв : ");
                checking = Check();
                n = Convert.ToInt32(Math.Round(checking));
                if( n > 0)

            } while (checking == -1);
            double[,] matrix = new double[m, n];
            Console.Write(" Чи хочете вести данi для масиву власноруч : ");
            string str = Console.ReadLine();
            method = GetMethod(str);

         if(method)
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    
                    do
                    {

                        Console.Write("Ведiть число для елементу масиву під номером  {0}|{1} :  ", i, j);
                        checking = Check();
                        matrix[i, j] = checking;

                    } while (checking == -1);
                }
            }
            Random rnd = new Random();
            if(!method)
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                        matrix[i, j] = rnd.Next(-100,100);
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write("{0} ", matrix[i, j]);
                Console.WriteLine();
            }
            max = GetMax(matrix);
            min = GetMin(matrix);
            avg = GetAvg(max, min);
            Console.WriteLine("Середнє арифметичне елиментів  {0},{1}  : {2} " ,max ,min,avg);
        }
    }
}