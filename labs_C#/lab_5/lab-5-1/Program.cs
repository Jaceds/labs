using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
// 1 Біологія Биков 11.02.2023 Клітини 21
// 2 Історія Шевченко 21.03.2023 Стародавній-Рим 12
// 3 Математика Махайленко 12.04.2023 Матриці 9
// 4 Інформатика Кузюк 01.05.2023 Інтернет 25
// 5 Музика Кучер 11.11.2023 Типи-інструментів 18
namespace v1
{
    class Program
    {
        static async void RemoveString(List<Lecture> oldDBdase, int id)
        {
            StreamWriter write = new StreamWriter("dbase.txt", false);
            for (int i = 0; i < oldDBdase.Count; i++)
                if (oldDBdase[i].GetAll(id) != string.Empty)
                    await write.WriteLineAsync(oldDBdase[i].GetAll(id));
            write.Close();

        }
        static bool Check(string intg, string str)
        {
            try
            {
                int s = Convert.ToInt32(intg);
            }
            catch
            {
                {
                    if (str.Length < 2)
                        return true;
                    for (int i = 0; i < str.Length; i++)
                        if (str[i] >= '0' && str[i] <= '9')
                            return true;
                }

            }
            return false;
        }
        static void readAgain(List<Lecture> oldDBdase)
        {
            string line;
            var xx = new StreamReader("dbase.txt");
            oldDBdase.Clear();
            //   while (!String.IsNullOrWhiteSpace((line = xx.ReadLine())))
            while ((line = xx.ReadLine()) is not null)
                oldDBdase.Add(new Lecture(line));
            xx.Close();
        }
        static public string CreateString(List<int> arr)

        {
            bool check;
            string str = "";
            string[] arrStings = {
            "айді",
            "назва курсу",
            "Прізвище викладача",
            "дату",
            "тему",
            "кількісь студентів",
        };

            for (int i = 0; i < 6; i++)
            {
                string? strA;
                do
                {
                    Console.WriteLine("Введіть {0} {1}", arrStings[i], i);
                    strA = Console.ReadLine();

                    if (i == 0 || i == 5)
                        check = Check(strA, "");


                    else check = Check("", strA);
                    if (i == 0 && check == false)
                    {
                        int a = Convert.ToInt32(strA);
                        foreach (int item in arr)
                            if (item == a)
                            {
                                Console.WriteLine("Id має бути унікальним");
                                check = true;
                            }

                    }

                } while (check);
                str = i == 0 ? strA : str + " " + strA;

            }
            return str;
        }
        static int GetCount()
        {
            StreamReader reader = new StreamReader("dbase.txt");
            string lineCount;
            int count = 0;
            while ((lineCount = reader.ReadLine()) != null)
                count++;
            reader.Close();
            return count;
        }
        static async void ReWriteFile(List<Lecture> oldDBdase)
        {
            StreamWriter write = new StreamWriter("dbase.txt", false);
            for (int i = 0; i < oldDBdase.Count; i++)
                await write.WriteLineAsync(oldDBdase[i].GetAll(-1));
            write.Close();

        }
        static void Main(string[] args)
        {
            try
            {
                List<Lecture> dbase = new List<Lecture>();
                List<int> numberStudents = new List<int>();
                List<int> idArray = new List<int>();
                bool check;
                string path = "dbase.txt";
                StreamReader fr = new StreamReader(path);
                string line;
                while (!String.IsNullOrWhiteSpace((line = fr.ReadLine())))
                    dbase.Add(new Lecture(line));

                Console.Clear();
                Console.WriteLine("\nНатисність відповідну клавішу \n N дотати дані \n S вивести список бд \n M Вивести курс з найменною кількістю студентів \n D видалити курс  \n Escape вихів \n C Щоб вевети курс по останій літері викладача");
                ConsoleKeyInfo key;
                do
                {

                    idArray.Clear();
                    foreach (var item in dbase)
                        idArray.Add(item.GetId());

                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.S)
                    {
                        Console.Clear();
                        foreach (var item in dbase)
                            item.Show();

                    }
                    else if (key.Key == ConsoleKey.X)
                    {
                        Console.Clear();
                        System.Console.Write("Введіть назву теми : ");
                        var _search = Console.ReadLine();
                        Console.WriteLine("Результат пошуку");
                        foreach (var item in dbase)
                            if (_search != null)
                                item.ShowSearchedTheme(_search);

                    }
                    else if (key.Key == ConsoleKey.C)
                    {
                        Console.Clear();
                        char _searchChar = ' ';
                        do
                        {
                            System.Console.Write("Введіть останню літеру прізвища викладача : ");
                            var _search = Console.ReadLine();
                            if (!String.IsNullOrWhiteSpace(_search) && _search.Length == 1)
                            {
                                _searchChar = char.Parse(_search);
                                check = false;
                            }
                            else
                                check = true;
                        }
                        while (check);
                        int count = 0;
                        Console.WriteLine("Результат пошуку");
                        foreach (var item in dbase)
                        {
                            count += item.ShowLastTeacher(_searchChar);
                            if (count == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Нічого не знайдено ");
                            }
                        }
                    }
                    else if (key.Key == ConsoleKey.M)
                    {
                        foreach (var item in dbase)
                            numberStudents.Add(item.GetNumberstudents());
                        dbase[numberStudents.IndexOf(numberStudents.Min())].Show();
                    }
                    else if (key.Key == ConsoleKey.D)
                    {
                        string? id;
                        do
                        {
                            Console.WriteLine("Введіть айді рейсу який хочете видалити : ");
                            id = Console.ReadLine();
                            check = Check(id, "");
                        } while (check);
                        RemoveString(dbase, Convert.ToInt32(id));

                        Console.Clear();
                        Console.WriteLine("Видалення виконано : ");
                        readAgain(dbase);
                    }
                    else if (key.Key == ConsoleKey.N)
                    {
                        string add = CreateString(idArray); ;
                        var lines = File.ReadAllLines(path).ToList();
                        int index = GetCount();
                        lines.Insert(index, add);
                        File.WriteAllLines(path, lines);
                        System.Console.WriteLine(dbase.Count);
                        //  dbase.Clear();

                        readAgain(dbase);
                        System.Console.WriteLine(dbase.Count);
                    }
                    else if (key.Key == ConsoleKey.V)
                    {
                        string? id;
                        string? strFlight;
                        string? newField;
                        string[] arrStings = {
                                        "айді",
                                        "назву курсу",
                                        "прізвище викладача",
                                        "дату",
                                        "тема курсу ",
                                        "кількість студентів",
                                    };
                        do
                        {
                            Console.WriteLine("Введіть айді рейсу який хочете регадувати : ");
                            id = Console.ReadLine();
                            check = Check(id, "");
                            if (!check)
                                if (!idArray.Contains(Convert.ToInt32(id)))
                                {
                                    Console.WriteLine("Не знайдено рейсу по такому айді");
                                    check = true;
                                }

                        } while (check);
                        do
                        {
                            Console.WriteLine("Введіть номер поля який хочете регадувати : ");
                            strFlight = Console.ReadLine();
                            check = Check(strFlight, "");
                            if (!check && strFlight[0] > '5' || strFlight[0] < '0')
                                check = true;
                        } while (check);
                        do
                        {
                            Console.WriteLine("Введіть нове значення для для {0} : ", arrStings[Convert.ToInt32(strFlight) - 1]);
                            newField = Console.ReadLine();

                            if (Convert.ToInt32(strFlight) - 1 == 1 || Convert.ToInt32(strFlight) - 1 == 4)
                                check = Check(newField, "");
                            else if (Convert.ToInt32(strFlight) - 1 == 0)
                            {
                                check = Check(newField, "");
                                if (1 == Convert.ToInt32(strFlight) && !check)
                                {

                                    if (idArray.Contains(Convert.ToInt32(newField)))
                                    {
                                        Console.WriteLine("Id має бути унікальним");
                                        check = true;
                                    }

                                }
                            }
                            else check = Check("", newField);

                        } while (check);
                        Console.Clear();
                        Console.WriteLine("Регадування виконано : ");
                        foreach (var item in dbase)
                        {
                            item.Guessingflight(Convert.ToInt32(id), Convert.ToInt32(strFlight) - 1, newField);
                        }
                        ReWriteFile(dbase);
                        readAgain(dbase);
                    }

                    else if (key.Key == ConsoleKey.Escape)
                        Console.WriteLine(" Вихід...");
                    if (key.Key != ConsoleKey.Escape)
                    {
                        Console.WriteLine("\nНатисність відповідну клавішу \n N дотати дані \n S  вивести список бд \n M Вивести курс з найменною кількістю студентів \n D видалити курс  \n Escape вихів \n C Щоб вевети курс по останій літері викладача");


                    }
                }
                while (key.Key != ConsoleKey.Escape);
                fr.Close();
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Перевірте правильність імені і шляху до файлу!");
                return;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Дуже великий файл!");
                return;
            }

            catch (Exception e)
            {
                Console.WriteLine("Помилка: " + e.Message);
                return;
            }

        }
    }
}
