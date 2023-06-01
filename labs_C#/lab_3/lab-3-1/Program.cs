namespace lab_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string? str;
            bool check = false;
            do
            {
                Console.Write("Веддіть текст : ");
                str = Console.ReadLine();
                if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                    check = true;
                else
                    check = false;

            } while (check);
            string[] arr = str.Split(" ");
            int i = 0;
            string five = "";
            foreach (string item in arr)
            {

                if (item.ToLower()[item.Length - 1] == 'а' || item.ToLower()[item.Length - 1] == 'і'
                || item.ToLower()[item.Length - 1] == 'у' || item.ToLower()[item.Length - 1] == 'я'
            || item.ToLower()[item.Length - 1] == 'е' || item.ToLower()[item.Length - 1] == 'є'
            || item.ToLower()[item.Length - 1] == 'и' || item.ToLower()[item.Length - 1] == 'ї'
            || item.ToLower()[item.Length - 1] == 'ю' || item.ToLower()[item.Length - 1] == 'о')
                    i++;
                if (item.Length < 5)
                    five += $" {item}";
            }
            Console.WriteLine($"Кількість слів які закінчуються на голосну літеру {i}");
            Console.WriteLine($"Всі слова менші за 5 літер '{five}'");

        }
    }
}