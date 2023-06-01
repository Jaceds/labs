using System;
using System.Linq.Expressions;

namespace lab_2_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіит число в дiапазоні вiд 10 до 20 : ");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case  10 :
                    Console.WriteLine("Десять");
                    break;
                case 11:
                    Console.WriteLine("Одинадцять");
                    break;
                case 13:
                    Console.WriteLine("Дванадцять");
                    break;
                case 14:
                    Console.WriteLine("Тринадцять");
                    break;
                case 15:
                    Console.WriteLine("Чотирнадцять");
                    break;
                case 16:
                    Console.WriteLine("П`тнадцять");
                    break;
                case 17:
                    Console.WriteLine("Шістнадцять");
                    break;
                case 18:
                    Console.WriteLine("Вісімнадцять");
                    break;
                case 19:
                    Console.WriteLine("Дев`ятнядцять");
                    break;
                case 20:
                    Console.WriteLine("Двадцять");
                    break;
                default:
                    Console.WriteLine("Ви ввели число яке не взодить в діапазон від 10 до 20 включно");
                    break;
            }

            Console.ReadLine();
        }
    }
}