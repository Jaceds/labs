using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace lab_4
{
    class ConfigurationPc
    {
        int id;
        public int type;
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
            Console.WriteLine("id {0,2} | type {1,2} | clockFrequency {2,2} | Proc {3,5} | RAM {4,3}gb | ROM {5,4}gb | monitorWidth {6,4}px | monitorHeight {7,4}px | refresh {8,5} |", id, type, clockFrequency, nameProc, ram, rom, monitorWidth, monitorHeight, refresh);
        }
        public int getMemory()
        {
            return ram + rom;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationPc[] dbase = new ConfigurationPc[5];
            try
            {
                //Копіюю дані з документа і створюю масив обьектів 
                int index = 0;
                var f = new StreamReader("a.txt");
                string line;
                while ((line = f.ReadLine()) != null)
                {
                    dbase[index] = new ConfigurationPc(line);
                    index++;
                }
                index = 0;
                f.Close();
                //Сортую масив  по типу процесора
                for (int i = 0; i < dbase.Length; i++)
                    for (int j = 0; j < dbase.Length - i - 1; j++)
                        if (dbase[j].type < dbase[j + 1].type)
                        {
                            var k = dbase[j];
                            dbase[j] = dbase[j + 1];
                            dbase[j + 1] = k;
                        }
                // Визиваю метод Print
                foreach (var item in dbase)
                    item.Print();
                //Шукаю найбільшу к.ть память в пк
                int[] arMem = new int[dbase.Length];
                int maxMem = arMem[0];
                int maxMemIndex = -1;
                foreach (var item in dbase)
                {
                    arMem[index] = item.getMemory();
                    index++;
                }
                index = 0;
                foreach (var item in arMem)
                    if (maxMem < item)
                    {
                        maxMem = item;
                        maxMemIndex++;
                    }
                Console.WriteLine("Kомп`ютер з найбільшим обсягом оперативної і дискової пам’яті");
                dbase[maxMemIndex].Print();

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