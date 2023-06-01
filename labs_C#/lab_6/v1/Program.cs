using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace v1
{
    class ConfigurationPc : IConfigurationPc
    {
        int id;
        int type;
        int clockFrequency;
        string nameProc;
        int ram;
        int rom;
        int monitorWidth;
        int monitorHeight;
        int refresh;

        public ConfigurationPc(string s) // 2 конструктор з параметром
        {
            string[] arr = { };
            for (int i = 0; i < 8; i++)
                arr = s.Split(' ');
            id = Convert.ToInt32(arr[0]);
            type = Convert.ToInt32(arr[1]);
            clockFrequency = Convert.ToInt32(arr[2]);
            nameProc = arr[3];
            ram = Convert.ToInt32(arr[4]);
            rom = Convert.ToInt32(arr[5]);
            monitorWidth = Convert.ToInt32(arr[6]);
            monitorHeight = Convert.ToInt32(arr[7]);
            refresh = Convert.ToInt32(arr[8]);
        }

        public void Print()
        {
            Console.WriteLine($"id {id} | тип  процеcора {type} | частота процесора {clockFrequency} | назва процесора {nameProc} | RAM {ram}gb | ROM {rom}gb | ширина монітора  {monitorWidth}px | довжина монітора {monitorHeight}px | частота оновлення {refresh} ");
        }
        public int getMemory()
        {
            return ram + rom;
        }
        public int getTypeProc()
        {
            return type;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ConfigurationPc[] dbase = new ConfigurationPc[5];
            var dbase = new List<IConfigurationPc>();
            try
            {
                //Копіюю дані з документа і створюю масив обьектів 
                var f = new StreamReader("a.txt");
                string line;
                while ((line = f.ReadLine()) != null)
                {
                    dbase.Add(new ConfigurationPc(line));

                }
                f.Close();
                //Сортую масив  по типу процесора
                for (int i = 0; i < dbase.Count; i++)
                    for (int j = 0; j < dbase.Count - i - 1; j++)
                        if (dbase[j].getTypeProc() < dbase[j + 1].getTypeProc())
                        {
                            var k = dbase[j];
                            dbase[j] = dbase[j + 1];
                            dbase[j + 1] = k;
                        }
                // Визиваю метод Print
                foreach (var item in dbase)
                    item.Print();
                //Шукаю найбільшу к.ть память в пк
                //  int[] arMem = new int[dbase.Count];
                List<int> arMem = new List<int>();
                //   int maxMem = arMem[0];
                // int maxMemIndex = -1;
                foreach (var item in dbase)
                    // arMem[inde = item.getMemory(0);
                    arMem.Add(item.getMemory());
                Console.WriteLine("Kомп`ютер з найбільшим обсягом оперативної і дискової пам’яті");
                dbase[arMem.IndexOf(arMem.Max())].Print();
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

            // catch (Exception e)
            // {
            //     Console.WriteLine("Помилка: " + e.Message);
            //     return;
            // }

        }
    }
}