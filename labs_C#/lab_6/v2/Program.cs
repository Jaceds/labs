using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

interface ICourseSave
{
    void LoadRecords(); // interface method (does not have a body)
    void SaveRecords();
}

class Course
{
    public string NameCourse { get; set; }
    public string LastNameTeacher { get; set; }

    public Course(string nameCourse, string lastNameTeacher)
    {
        NameCourse = nameCourse;
        LastNameTeacher = lastNameTeacher;
    }
}

class Lecture : Course
{
    public string Date { get; set; }
    public string LectureTheme { get; set; }
    public int NumberStudents { get; set; }

    public Lecture(string nameCourse, string lastNameTeacher, string date, string lectureTheme, int numberStudents)
        : base(nameCourse, lastNameTeacher)
    {
        Date = date;
        LectureTheme = lectureTheme;
        NumberStudents = numberStudents;
    }
}

class CourseDatabase : ICourseSave
{
    private string fileName;
    private List<Lecture> records;

    public CourseDatabase(string fileName)
    {
        this.fileName = fileName;
        records = new List<Lecture>();
    }

    public int GetRecordCount()
    {
        return records.Count;
    }

    public void LoadRecords()
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] recordData = line.Split(',');
                string nameCourse = recordData[0];
                string lastNameTeacher = recordData[1];
                string date = recordData[2];
                string lectureTheme = recordData[3];
                int numberStudents = int.Parse(recordData[4]);

                Lecture Lecture = new Lecture(nameCourse, lastNameTeacher, date, lectureTheme, numberStudents);
                records.Add(Lecture);
            }
        }
    }

    public void SaveRecords()
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Lecture record in records)
            {
                string line = $"{record.NameCourse},{record.LastNameTeacher},{record.Date},{record.LectureTheme},{record.NumberStudents}";
                writer.WriteLine(line);
            }
        }
    }

    public void AddRecord(Lecture lecture)
    {
        records.Add(lecture);
    }

    public void EditRecord(int index, Lecture newLecture)
    {
        if (index >= 0 && index < records.Count)
        {
            records[index] = newLecture;
        }
        else
        {
            throw new ArgumentException("Invalid index.");
        }
    }

    public void DeleteRecord(int index)
    {
        if (index >= 0 && index < records.Count)
        {
            records.RemoveAt(index);
        }
        else
        {
            throw new ArgumentException("Invalid index.");
        }
    }

    public void PrintRecords()
    {
        for (int i = 0; i < records.Count; i++)
        {
            Lecture record = records[i];
            // Console.WriteLine();
            Console.WriteLine($"Iндекс {i+1} назва курсу {record.NameCourse} прізвище викладача {record.LastNameTeacher} дата {record.Date}  тему лекції {record.LectureTheme}  кількість студентів {record.NumberStudents}");
        }
    }
    public virtual void MinStudents()
    {
        List<int> studentsArray = new List<int>();
        foreach (Lecture record in records)
            studentsArray.Add(record.NumberStudents);
        foreach (Lecture record in records)
        {
            if (studentsArray.Min() == record.NumberStudents)
                Console.WriteLine($"Назва курсу {record.NameCourse} прізвище викладача {record.LastNameTeacher} дата {record.Date}  тему лекції {record.LectureTheme}  кількість студентів {record.NumberStudents}");
        }

    }

    public void FindLectureTheme(string word)
    {
        Console.Clear(); var textInfo = new CultureInfo("ua-Ua").TextInfo;

        Console.WriteLine("Результат пошуку");
        foreach (Lecture record in records)
        {
            var capitalizedText = textInfo.ToTitleCase(textInfo.ToLower(word));
            if (record.LectureTheme.Contains(capitalizedText))
                Console.WriteLine($"Назва курсу {record.NameCourse} прізвище викладача {record.LastNameTeacher} дата {record.Date}  тему лекції {record.LectureTheme}  кількість студентів {record.NumberStudents}");
        }
    }
    public void FindLastLetter(char letter)
    {
        int count = 0;
        foreach (Lecture record in records)
        {
            if (record.LastNameTeacher[record.LastNameTeacher.Length - 1] == letter)
            {
                count++;
                Console.WriteLine($"Назва курсу {record.NameCourse} прізвище викладача {record.LastNameTeacher} дата {record.Date}  тему лекції {record.LectureTheme}  кількість студентів {record.NumberStudents}");
            }
        }
        if (count == 0)
            Console.WriteLine("Нічого не знайдено ");
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
                if (String.IsNullOrWhiteSpace(str))
                    return true;
                for (int i = 0; i < str.Length; i++)
                    if (str[i] >= '0' && str[i] <= '9')
                        return true;
            }

        }
        return false;
    }
    static void Main(string[] args)
    {
        var courseDateBase = new CourseDatabase("dbase.txt");
        courseDateBase.LoadRecords();
        bool check;
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Додати запис");
            Console.WriteLine("2. Редагувати запис");
            Console.WriteLine("3. Видалити запис");
            Console.WriteLine("4. Друк записів");
            Console.WriteLine("5. Вивести курс з найменною кількістю студентів");
            Console.WriteLine("6. Щоб вевети курс по останій літері викладача");
            Console.WriteLine("7. Найти курс по темі");
            Console.WriteLine("8. Зберегти записи та вийти");
            Console.Write("Введіть свій вибір:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    courseDateBase.PrintRecords();
                    string[] strArr = {
                    "назву курсу",
                    "прізвище викладача",
                    "дату (рррр-ММ-дд)",
                    "тему лекції",
                    "кількість студентів",
                };
                    List<string> newStr = new List<string>();
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        string? newValue = " ";
                        do
                        {
                            Console.Write($"Введіть {strArr[i]}: ");
                            newValue = Console.ReadLine();
                            if (String.IsNullOrWhiteSpace(newValue))
                                check = true;
                            else if (i != 4)
                                check = Check("", newValue);
                            else
                                check = Check(newValue, "");

                        } while (check);
                        if (newValue != null)
                            newStr.Add(newValue);
                    }

                    if (newStr[0] != null && newStr[1] != null && newStr[2] != null && newStr[3] != null)
                    {
                        Lecture newLecture = new Lecture(newStr[0], newStr[1], newStr[2], newStr[3], Convert.ToInt32(newStr[4]));
                        courseDateBase.AddRecord(newLecture);
                        Console.WriteLine("Запис додано.");

                    }
                    break;

                case "2":
                    Console.Clear();
                    List<string> newStrEd = new List<string>();
                    string? editIndex;
                    string[] strArrEd = {
                    "назву курсу",
                    "прізвище викладача",
                    "дату (рррр-ММ-дд)",
                    "тему лекції",
                    "кількість студентів",
                };
                    do
                    {
                        Console.Write("Введіть індекс запису для редагування:");
                        editIndex = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(editIndex))
                            check = true;
                        else
                            check = Check(editIndex, "");

                    } while (check);


                    if (Convert.ToInt32(editIndex) >= 0 && Convert.ToInt32(editIndex) < courseDateBase.GetRecordCount())
                    {
                        for (int i = 0; i < strArrEd.Length; i++)
                        {
                            string? newValue = " ";
                            do
                            {
                                Console.Write($"Введіть {strArrEd[i]}: ");
                                newValue = Console.ReadLine();
                                if (String.IsNullOrWhiteSpace(newValue))
                                    check = true;
                                else if (i != 4)
                                    check = Check("", newValue);
                                else
                                    check = Check(newValue, "");

                            } while (check);
                            if (newValue != null)
                                newStrEd.Add(newValue);
                        }

                        Lecture editedLecture = new Lecture(newStrEd[0], newStrEd[1], newStrEd[2], newStrEd[3], Convert.ToInt32(newStrEd[4]));
                        courseDateBase.EditRecord(Convert.ToInt32(editIndex), editedLecture);
                        Console.WriteLine("Запис відредаговано.");
                    }
                    else
                    {
                        Console.WriteLine("Неправильний індекс.");
                    }
                    break;
                case "3":
                    Console.Write("Введіть індекс запису, який потрібно видалити:");
                    int deleteIndex = int.Parse(Console.ReadLine());

                    if (deleteIndex >= 0 && deleteIndex < courseDateBase.GetRecordCount())
                    {
                        courseDateBase.DeleteRecord(deleteIndex);
                        Console.WriteLine("Запис видалено.");
                    }
                    else
                    {
                        Console.WriteLine("Неправильний індекс.");
                    }

                    Console.WriteLine();
                    break;

                case "4":
                    Console.Clear();
                    courseDateBase.PrintRecords();
                    break;

                case "5":
                    Console.Clear();
                    courseDateBase.MinStudents();
                    break;

                case "6":
                    char _searchChar = ' ';
                    do
                    {
                        System.Console.Write("Введіть останню літеру прізвища викладача : ");
                        var _searchWord = Console.ReadLine();
                        if (!String.IsNullOrWhiteSpace(_searchWord) && _searchWord.Length == 1)
                        {
                            _searchChar = char.Parse(_searchWord);
                            check = false;
                        }
                        else
                            check = true;

                    } while (check);
                    courseDateBase.FindLastLetter(_searchChar);
                    break;

                case "7":
                    Console.Clear();
                    string? _search;
                    do
                    {
                        Console.Write("Введіть назву теми : ");
                        _search = Console.ReadLine();
                        check = Check("", _search);
                    } while (check);

                    Console.WriteLine("Результат пошуку");
                    if (_search != null)
                        courseDateBase.FindLectureTheme(_search);
                    break;

                case "8":
                    courseDateBase.SaveRecords();
                    Console.WriteLine("Записи збережено. Вихід з програми.");
                    return;

                default:
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}