using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace lab_2_2
{
    public class Program

    {
        static double Check()

        {
            var str = Console.ReadLine();
            try
            {
                double b = 0;
                if (str != null)
                b = double.Parse(str);
                return Math.Round(b, 2);
            }
            catch
            {
                return -1;
            }
        }
        static double GetLessSeven(double[] arr)
        {
            int lessSeven = 0;
            foreach (int item in arr)
                if (item < 7)
                    lessSeven++;
            return lessSeven;
        }
        static double GetSuma(double[] arr)
        {

            int lastD =0 , firstD = 0;
            double suma = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] > 0)
                {
                    firstD = i;
                    break;
                }
            for (int i = arr.Length - 1; i >= 0; i--)
                if (arr[i] > 0)
                {
                    lastD = i;
                    break;
                }
            for (int i = firstD + 1; i < lastD; i++)
                suma += arr[i];
            return suma;

        }

        static bool GetMethod(string str)
        {

            string[] array = { "Так", "так", "да", "Y", "Yes", "yes", "yea", "ТАк", "y", "ДА", "Tak", "da", "Da", "TAK", "tak", "ТАК", "ДА" };
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i] == str)
                    return true;

            }
            return false;
        }

        static void Main(string[] args)

        {
           double  checking ,
                lessSeven,
                suma;
            int m;
            bool method = false;
            var str = " ";


            do
            {
                Console.Write("Ведiть розмiр масиву : ");
                checking = Check();
                m = Convert.ToInt32(Math.Round(checking));

            } while (checking == -1);
        
            double[] array =new double[m] ;
            Console.Write(" Чи хочете вести данi для масиву власноруч : ");
             str = Console.ReadLine();
             if(str != null)
                method = GetMethod(str);
            if (method)
                for (int i = 0; i < m; i++)
                {
                  
                        do
                        {

                            Console.Write("Ведiть число для елементу масиву пiд номером  {0}| :  ", i);
                            checking = Check();
                            array[i] = checking;

                        } while (checking == -1);
                    }


              Random rnd = new Random();
            if (!method)
            for (int i = 0; i < m; i++)
                array[i] = rnd.Next(-100, 100);

            foreach (var item in array)
            {
                Console.Write(" {0}", item);
            }

            Console.WriteLine();
            lessSeven = GetLessSeven(array);
            suma = GetSuma(array);

            Console.WriteLine("Кiлькiсть чисел менших за 7 : {0}  ", lessSeven);
            Console.WriteLine("Сума : {0}  ", suma );

        }
    }
}