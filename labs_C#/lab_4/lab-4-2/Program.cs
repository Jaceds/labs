using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
namespace lab_4
{
    class PlanePlan
    {
        int id;
        int flightNumber;
        string typePlane;
        string divMovement;
        int departureFrequency;


        public PlanePlan(string s) //  конструктор з параметром
        {
            string[] arr = { };
            arr = s.Split(' ');
            id = Convert.ToInt32(arr[0]);
            flightNumber = Convert.ToInt32(arr[1]);
            typePlane = arr[2];
            divMovement = arr[3];
            departureFrequency = Convert.ToInt32(arr[4]);
        }

        public void Print()

        {
            Console.WriteLine("id {0,2} | номер рейсу {1,2} | тип літака {2,2} | рейс {3,5} | кількість польотів на тиждень {4,3} |", id, flightNumber, typePlane, divMovement, departureFrequency);
        }

        public void Find(int a)
        {
            if (a == flightNumber)
                Console.WriteLine("id {0,2} | flightNumber {1,2} | typePlane {2,2} | divMovement {3,5} | departureFrequency {4,3} |", id, flightNumber, typePlane, divMovement, departureFrequency);
 
        
        }
        public int GetTypePlane()
        {
            if (typePlane == "Реактивний")
                return 1;
            else if (typePlane == "Важкий")
                return 2;
            else if (typePlane == "Середній")
                return 3;
            else if (typePlane == "Легкий")
                return 4;
            return 0;
        }


        public int getId()
        {
            return id;
        }
        public string getAll(int idRemove)

        {
            string a1 = id.ToString();
            string a2 = flightNumber.ToString();
            string a3 = departureFrequency.ToString();

            if (id != idRemove)
                return a1 + " " + a2 + " " + typePlane + " " + divMovement + " " + a3;
            return string.Empty;
        }
        public void guessingflight(int idChange, int IndexField, string newField)
        {
            string[] arr = {
                "id",
         "flightNumber",
         "typePlane",
       "divMovement",
       "departureFrequency"

            };
            if (idChange == id)
            {
                int a = Array.IndexOf(arr, arr[IndexField]);
                string newF = arr[a];
                Console.WriteLine("newF {0}", newF);

                if (a == 0 || a == 1 || a == 4)
                {
                    if (newF == "id")
                        id = Convert.ToInt32(newField);
                    else if (newF == "flightNumber")
                        flightNumber = Convert.ToInt32(newField);
                    else if (newF == "departureFrequency")
                        departureFrequency = Convert.ToInt32(newField);
                }
                if (newF == "typePlane")
                    typePlane = newField;
                else if (newF == "divMovement")
                    divMovement = newField;

                newF = newField;
                Console.WriteLine("asdfs {0}", a);
            }

        }
        public void setID(int idNEW, int i, int newid)
        {
            string getStr = getAll(-1);
            string[] arr = { };
            arr = getStr.Split(" ");

            // if (idChange == id)
            if (i % 2 == 0)

            {
                //id = idNEW;
                // Console.WriteLine(arr[IndexField]);
                // Console.WriteLine(newField);
                arr[0] = 20.ToString();
                id = newid;
                //string newSting = String.Join(" ", arr);
                // foreach (var item in arr)
                // {
                //     Console.Write("  {0}", item);

                // }
                // Console.WriteLine(" ");
                //id = 100;
                //new PlanePlan(newSting);
                //RemoveString(oldDbase,i)
            }
        }
    }

    class Program
    {
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
        static int GetCount()
        {
            StreamReader reader = new StreamReader("a.txt");
            string lineCount;
            int count = 0;
            while ((lineCount = reader.ReadLine()) != null)
                count++;
            reader.Close();
            return count;
        }
        static public string CreateString(List<int> arr)

        {
            bool check = false;
            string str = "";
            string[] arrStings = {
            "айді",
            "номер рейсу",
            "тип літака",
            "маршрут",
            "кількісь польотів в тиждень",
        };

            for (int i = 0; i < 5; i++)
            {
                string? strA;
                do
                {
                    Console.WriteLine("Ведіть {0}", arrStings[i]);
                    strA = Console.ReadLine();
                    if (i == 0 || i == 1 || i == 4)
                        check = Check(strA, "");


                    else check = Check("", strA);
                    if (i == 0 && check == false)
                    {
                        int a = Int32.Parse(strA);
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
        static void readAgain(List<PlanePlan> oldDBdase)
        {
            string line;
            var xx = new StreamReader("a.txt");
            oldDBdase.Clear();
            while ((line = xx.ReadLine()) != null)
                oldDBdase.Add(new PlanePlan(line));
            xx.Close();
        }
        static async void RemoveString(List<PlanePlan> oldDBdase, int id)
        {
            StreamWriter write = new StreamWriter("a.txt", false);
            for (int i = 0; i < oldDBdase.Count; i++)
                if (oldDBdase[i].getAll(id) != string.Empty)
                    await write.WriteLineAsync(oldDBdase[i].getAll(id));
            write.Close();

        }
        static async void ReWriteFile(List<PlanePlan> oldDBdase)
        {
            StreamWriter write = new StreamWriter("a.txt", false);
            for (int i = 0; i < oldDBdase.Count; i++)
                await write.WriteLineAsync(oldDBdase[i].getAll(-1));
            write.Close();

        }

        static void Main(string[] args)
        {
            try
            {

                List<PlanePlan> dbase = new List<PlanePlan>();
                List<int> idArray = new List<int> { };
                string path = "a.txt";
                bool check;
                
                StreamReader fr = new StreamReader(path);
                string line;
                while ((line = fr.ReadLine()) != null)
                    dbase.Add(new PlanePlan(line));

                Console.Clear();
                Console.WriteLine("Натисність відповідну клавушу \n N дотати дані \n D  вивести список бд \n A відсортувати дані бд \n S заново прочитати файл \n Q для видалення елемента бд \n F для пошуку по елементам бд \n N  додати новий елемент в бд \n Escape вихід");
                ConsoleKeyInfo key;
                do
                {
                    idArray.Clear();
                    foreach (var item in dbase)
                        idArray.Add(item.getId());

                    StreamWriter f = new StreamWriter(path, true);
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.F)
                    {
                        string? a;
                        do
                        {
                            Console.WriteLine("Ведіть номер рейсу для пошуку");
                            a = Console.ReadLine();
                            check = Check(a, "");

                        } while (check);
                        Console.WriteLine("Результат пошуку");
                        foreach (var item in dbase){
                             item.Find(Convert.ToInt32(a));
                        }

                    }

                    else if (key.Key == ConsoleKey.D)
                    {
                        Console.Clear();
                        foreach (var item in dbase)
                            item.Print();
                    }

                    else if (key.Key == ConsoleKey.S)

                    {
                        Console.Clear();
                        var xx = new StreamReader("a.txt");
                        dbase.Clear();
                        while ((line = xx.ReadLine()) != null)
                            dbase.Add(new PlanePlan(line));
                        xx.Close();
                    }
                    else if (key.Key == ConsoleKey.A)
                    {
                        Console.Clear();
                        for (int i = 0; i < dbase.Count; i++)
                            for (int j = 0; j < dbase.Count - i - 1; j++)
                                if (dbase[j].GetTypePlane() > dbase[j + 1].GetTypePlane())
                                {
                                    var k = dbase[j];
                                    dbase[j] = dbase[j + 1];
                                    dbase[j + 1] = k;
                                }
                        Console.WriteLine("Сортування виконано");

                    }
                    else if (key.Key == ConsoleKey.N)
                    {
                        string add = CreateString(idArray); ;
                        var lines = File.ReadAllLines(path).ToList();
                        int index = GetCount();
                        if (add != null)
                            lines.Insert(index, add);
                        File.WriteAllLines(path, lines);
                        var xx = new StreamReader("a.txt");
                        dbase.Clear();
                        while ((line = xx.ReadLine()) != null)
                            dbase.Add(new PlanePlan(line));
                    }

                    else if (key.Key == ConsoleKey.Q)
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
                    else if (key.Key == ConsoleKey.C)
                    {
                        string? id;
                        string? strFlight;
                        string? newField;
                        string[] arrStings = {
                                        "айді",
                                        "номер рейсу",
                                        "тип літака",
                                        "маршрут",
                                        "кількісь польотів в тиждень",
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
                            if(!check && strFlight[0] > '5' || strFlight[0] < '0')
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
                            item.guessingflight(Convert.ToInt32(id), Convert.ToInt32(strFlight) - 1, newField);
                        }
                        ReWriteFile(dbase);
                        readAgain(dbase);
                    }

                    // if (key.Key == ConsoleKey.P)
                    // {
                    //     int count = 0;
                    //     int newid = 1;
                    //     foreach (var item in dbase)
                    //     {
                    //         item.setID(100, count, newid);
                    //         ++count;
                    //     }
                    //     // ReWriteFile(dbase);
                    // }
                    if (key.Key != ConsoleKey.Escape)
                    {
                        Console.WriteLine("Натисність відповідну клавушу \n N дотати дані \n D  вивести список бд \n A відсортувати дані бд \n S заново прочитати файл \n Q для видалення елемента бд \n F для пошуку по елементам бд \n N  додати новий елемент в бд \n Escape вихід");

                    }
                    else if (key.Key == ConsoleKey.Escape)
                        Console.WriteLine(" Вихід...");
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
