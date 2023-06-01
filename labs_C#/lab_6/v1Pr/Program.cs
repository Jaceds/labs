using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

interface IPcManagement
{
    void AddPc();
    void EditPc();
    void DeletePc();
    void DisplayAllPc();
    void SearchByManufacture();
    void SearchByName();
    void SearchMin();
    void LoadPcFromFile();
    void SaveBooksToFile();
    void Run();
}

class Pc
{
    public int TypeProc { get; set; }
    public int ProccFrequency { get; set; }
    public string ProcManufacturer { get; set; }
    public int Ram { get; set; }
    public int Rom { get; set; }
    public string MonitorExpansion { get; set; }
    public string NameProc { get; set; }
}

class PcManagement : IPcManagement
{
    private List<Pc> pces = new List<Pc>();

    static bool Check(string intg, string str)
    {

        try
        {
            int s = Convert.ToInt32(intg);
        }
        catch
        {
            {
                if (String.IsNullOrWhiteSpace(str))
                    return true;
                for (int i = 0; i < str.Length; i++)
                    if (str[i] >= '0' && str[i] <= '9')
                        return true;
            }

        }
        return false;
    }
    public void AddPc()
    {

        bool check = false;
        bool repeat = false;
        Console.WriteLine("Введіть характеристику:");

        string? procManufacturer;
        do
        {
            Console.Write("Виробника процесора:");
            procManufacturer = Console.ReadLine();
            if (string.IsNullOrEmpty(procManufacturer) || string.IsNullOrWhiteSpace(procManufacturer))
                repeat = true;
            else
                repeat = false;

        } while (repeat);
        string? typeProc;
        do
        {
            Console.Write("Тип процесора:");
            typeProc = Console.ReadLine();
            if (typeProc != null)
                check = Check(typeProc, "");
            else
                check = false;

        } while (check);

        string? proccFrequency;
        do
        {
            Console.Write("Частота процесора:");
            proccFrequency = Console.ReadLine();
            if (proccFrequency != null)
                check = Check(proccFrequency, "");
            else
                check = false;

        } while (check);

        Console.Write("Кількість оперптивної памяті:");
        string? ram;
        do
        {
            Console.Write("Кількість оперптивної памяті:");
            ram = Console.ReadLine();
            if (ram != null)
                check = Check(ram, "");
            else
                check = false;

        } while (check);
        string? rom;
        do
        {
            Console.Write("Кількість оперптивної памяті:");
            rom = Console.ReadLine();
            if (rom != null)
                check = Check(rom, "");
            else
                check = false;

        } while (check);

        Console.Write("Кількість постоянної памяті:");
        var nameProc = Console.ReadLine();



        Pc pc = new Pc
        {
            TypeProc = Convert.ToInt32(typeProc),
            ProccFrequency = Convert.ToInt32(proccFrequency),
            ProcManufacturer = procManufacturer,
            Ram = Convert.ToInt32(ram),
            Rom = Convert.ToInt32(rom),
            NameProc = nameProc
        };

        pces.Add(pc);

        Console.WriteLine("Характеристику  успішно додано.");
    }

    public void EditPc()
    {
        bool check = false;
        Pc pc = new Pc();
        string? index;
        bool repeat;
        Console.Clear();
        DisplayAllPc();

        do
        {
            Console.WriteLine("Введіть індекс для характеристики редагування:");
            index = Console.ReadLine();
            check = Check(index, "");
            if (Convert.ToInt32(index) > 0 && Convert.ToInt32(index) < pces.Count)
                check = false;

        } while (check);

        pc = pces[Convert.ToInt32(index) - 1];
        if (pc != null)
        {
            Console.WriteLine("Виберіть поле для редагування:");
            Console.WriteLine("1. Тип процесора");
            Console.WriteLine("2. Частота процесора");
            Console.WriteLine("3. Виробник прооцесора");
            Console.WriteLine("4. Кількість оперетивної памяті");
            Console.WriteLine("5. Кількість постояної памяті ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    string? newManufacturer;
                    do
                    {
                        Console.WriteLine("Введіть нового вирообника:");
                        newManufacturer = Console.ReadLine();
                        if (string.IsNullOrEmpty(newManufacturer) || string.IsNullOrWhiteSpace(newManufacturer))
                            repeat = true;
                        else
                            repeat = false;
                    } while (repeat);

                    if (newManufacturer != null)
                        pc.ProcManufacturer = newManufacturer;
                    Console.WriteLine(" Виробника успішно змінено.");
                    break;
                case "2":
                    Console.WriteLine("Введіть нову назву процесора:");
                    string? newNameProc;
                    do
                    {
                        Console.WriteLine("Введіть нову назву процесора:");
                        newNameProc = Console.ReadLine();
                        if (string.IsNullOrEmpty(newNameProc) || string.IsNullOrWhiteSpace(newNameProc))
                            repeat = true;
                        else
                            repeat = false;
                    } while (repeat);

                    if (newNameProc != null)
                        pc.NameProc = newNameProc;
                    Console.WriteLine(" Виробника успішно змінено.");
                    break;
                case "3":
                    string? newTypeProc;
                    do
                    {
                        Console.WriteLine("Введіть новий тип процесора:");
                        newTypeProc = Console.ReadLine();
                        if (string.IsNullOrEmpty(newTypeProc) || string.IsNullOrWhiteSpace(newTypeProc))
                            repeat = true;
                        else
                            repeat = false;
                    } while (repeat);
                    pc.TypeProc = Convert.ToInt32(newTypeProc);
                    Console.WriteLine("Тип процесора успішно змінено.");
                    break;
                case "4":
                    string? newProccFrequency;
                    do
                    {
                        Console.WriteLine("Введіть новий тип процесора:");
                        newProccFrequency = Console.ReadLine();
                        if (string.IsNullOrEmpty(newProccFrequency) || string.IsNullOrWhiteSpace(newProccFrequency))
                            repeat = true;
                        else
                            repeat = false;
                    } while (repeat);
                    Console.WriteLine("Введіть нову тактову частоту:");
                    if (newProccFrequency != null)
                        pc.ProccFrequency = Convert.ToInt32(newProccFrequency);
                    Console.WriteLine("Тактову частоту успішно змінено.");
                    break;

                case "5":
                    string? newRam;
                    do
                    {
                        Console.WriteLine("Введіть нову кількість озу:");
                        newRam = Console.ReadLine();
                        check = Check(newRam, "");


                    } while (check);

                    pc.Ram = Convert.ToInt32(newRam);
                    Console.WriteLine("Кількість озу  успішно змінено.");
                    break;
                case "6":
                    string? newRom;
                    do
                    {
                        Console.WriteLine("Введіть нову кількість память:");
                        newRom = Console.ReadLine();
                        check = Check(newRom, "");


                    } while (check);

                    pc.Rom = Convert.ToInt32(newRom);
                    Console.WriteLine("Кількість память  успішно змінено.");
                    break;
                case "7":
                    string newMonitorExpansion;
                    do
                    {
                        Console.WriteLine("Введіть нове розширення дисплею:");
                        newMonitorExpansion = Console.ReadLine();
                        if (string.IsNullOrEmpty(newMonitorExpansion) || string.IsNullOrWhiteSpace(newMonitorExpansion))
                            repeat = true;
                        else
                            repeat = false;
                    } while (repeat);
                    pc.MonitorExpansion = newMonitorExpansion;
                    Console.WriteLine("Розширеня дисплею успішно змінено.");
                    break;
                default:
                    Console.WriteLine("Некоректний вибір. Редагування скасовано.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Нічого не знайдено.");
        }
    }
    public void DeletePc()
    {
        Console.Clear();
        DisplayAllPc();
        Console.WriteLine("Введіть індекс характкристики для видалення:");
        int index = Convert.ToInt32(Console.ReadLine());
        if (index >= 0 && index < pces.Count)
        {
            pces.RemoveAt(index);
            Console.WriteLine("Характеристику успішно видалено.");
        }
        else
        {
            Console.WriteLine("Пк за такими характеристиками не знайдено не знайдено.");
        }
    }
    public void DisplayAllPc()
    {
        if (pces.Count > 0)
        {
            Console.WriteLine("Список усіх характеристик пк:");
            Console.WriteLine();
            int i = 1;
            Console.Clear();
            foreach (Pc pc in pces)
            {

                Console.WriteLine($"Індекс {i} Виробник {pc.ProcManufacturer} Назва {pc.NameProc} Тип {pc.TypeProc} Частота {pc.ProccFrequency} Озу{pc.Ram} Память {pc.Ram} Дисплей{pc.MonitorExpansion}");
                i++;
            }
        }
        else
        {
            Console.WriteLine("У базі даних немає характеристик пк.");
        }
    }
    public void SearchByManufacture()
    {
        Console.WriteLine("Введіть назву виробника процесора для пошуку:");
        string manufacture = Console.ReadLine();

        List<Pc> searchResults = pces.FindAll(b => b.ProcManufacturer.Equals(manufacture, StringComparison.OrdinalIgnoreCase));

        if (searchResults.Count > 0)
        {
            Console.WriteLine($"Результати пошуку за автором'{manufacture}':");

            foreach (Pc pc in searchResults)
            {

                Console.WriteLine();
                Console.WriteLine($"Виробник {pc.ProcManufacturer} Назва {pc.NameProc} Тип {pc.TypeProc} Частота {pc.ProccFrequency} Озу{pc.Ram} Память {pc.Ram} Дисплей{pc.MonitorExpansion}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine($"Книги автора '{manufacture}' не знайдено.");
        }
    }
    public void SearchByName()
    {
        Console.WriteLine("Введіть назву  процесора для пошуку:");
        string title = Console.ReadLine();

        List<Pc> searchResults = pces.FindAll(b => b.NameProc.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (searchResults.Count > 0)
        {
            foreach (Pc pc in searchResults)
            {

                Console.WriteLine();
                Console.WriteLine($"Виробник {pc.ProcManufacturer} Назва {pc.NameProc} Тип {pc.TypeProc} Частота {pc.ProccFrequency} Озу{pc.Ram} Память {pc.Ram} Дисплей{pc.MonitorExpansion}");
                Console.WriteLine();
            }

        }
        else
        {
            Console.WriteLine($"Книги з назвою '{title}' не знайдено.");
        }
    }
    public void SearchMin()
    {
       //List<Pc> min = new List<Pc>();
        Pc min = new Pc();
        min = pces[0];
      //  min.Add(pces[0]);
        for (int i = 0; i < pces.Count; i++)
        {
           // foreach (var item in min)
         //   {
             //   if (pces[i].Ram + pces[i].Rom < item.Ram + item.Rom)
                if (pces[i].Ram + pces[i].Rom < min.Ram + min.Rom)

                {
                  //  min.Clear();
                  //  min.Add(pces[i]);
                    min = pces[i];

           //     }
           }
        }
     //   foreach (Pc pc in min)
       // {

            Console.WriteLine();
      //      Console.WriteLine($"Виробник {pc.ProcManufacturer} Назва {pc.NameProc} Тип {pc.TypeProc} Частота {pc.ProccFrequency} Озу{pc.Ram} Память {pc.Rom} Дисплей{pc.MonitorExpansion}");
            Console.WriteLine($"Виробник {min.ProcManufacturer} Назва {min.NameProc} Тип {min.TypeProc} Частота {min.ProccFrequency} Озу{min.Ram} Память {min.Rom} Дисплей{min.MonitorExpansion}");
            Console.WriteLine();
       // }

    }
    public void Run()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Виберіть дію: ");
            Console.WriteLine("1. Додати характеристики комп'ютера");
            Console.WriteLine("2. Редагувати характеристики");
            Console.WriteLine("3. Видалити характеристики");
            Console.WriteLine("4. Вивести всі характеристики");
            Console.WriteLine("5. Пошук за виробником процесора");
            Console.WriteLine("6. Пошук За назвою процесора");
            Console.WriteLine("6. Пошук найшеного пе озу і памяті");
            Console.WriteLine("0. Вийти");
            Console.Write("Вибір : ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddPc();
                    break;
                case "2":
                    EditPc();
                    break;
                case "3":
                    DeletePc();
                    break;
                case "4":
                    DisplayAllPc();
                    break;
                case "5":
                    SearchByManufacture();
                    break;
                case "6":
                    SearchByName();
                    break;
                case "7":
                    SearchMin();
                    break;
                case "0":
                    Console.WriteLine("Програму завершено.");
                    return;
                default:
                    Console.WriteLine("Некоректний вибір. Спробуйте знову.");
                    break;
            }
        }
    }
    public void SaveBooksToFile()
    {
        using (StreamWriter writer = new StreamWriter("dbase.txt"))
        {
            foreach (Pc pc in pces)
            {
                writer.WriteLine($"{pc.ProcManufacturer},{pc.NameProc},{pc.TypeProc},{pc.ProccFrequency},{pc.Ram},{pc.Rom},{pc.MonitorExpansion}");
            }
        }
    }
    public void LoadPcFromFile()
    {
        using (StreamReader reader = new StreamReader("dbase.txt"))
        {

            Pc pc = new Pc();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] recordData = line.Split(',');
                pc.ProcManufacturer = recordData[0];
                pc.NameProc = recordData[1];
                pc.TypeProc = Convert.ToInt32(recordData[2]);
                pc.ProccFrequency = Convert.ToInt32(recordData[3]);
                pc.Ram = Convert.ToInt32(recordData[4]);
                pc.Rom = Convert.ToInt32(recordData[5]);
                pc.MonitorExpansion = recordData[6];
                pces.Add(pc);
                pc = new Pc();
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            IPcManagement PcManagement = new PcManagement();
            PcManagement.LoadPcFromFile();
            PcManagement.Run();
            PcManagement.SaveBooksToFile();
        }
    }
}

