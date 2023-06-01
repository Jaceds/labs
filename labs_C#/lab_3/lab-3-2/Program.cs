
namespace lab_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string? str = File.ReadAllText("file.txt");
            if (string.IsNullOrEmpty(str))
                Console.WriteLine("Файл пустий");
            else
            {
                int rE = 0;
                int rS = 0;
                int fS = 0;
                int fE = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ')')
                        rE++;
                    else if (str[i] == '(')
                        rS++;
                    else if (str[i] == '{')
                        fS++;
                    else if (str[i] == '}')
                        fE++;

                }
                if (fE == fS && rE == rS)
                    Console.WriteLine("Всі фігурні і круглі душки мають пари");
                else if (fE == fS)
                    Console.WriteLine("Всі фігурні душки мають пари");
                else if (rE == rS)
                    Console.WriteLine("Всі круглі душки мають пари");
                else
                    Console.WriteLine("Ні фігурні ні круглі душки немають пар");
            }
        }
    }
}