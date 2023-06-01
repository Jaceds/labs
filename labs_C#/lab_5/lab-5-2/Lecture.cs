using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace v1
{
    class Lecture : LearnCourse
    {
        string date;
        string lectureTheme;
        int numberStudents;
        public Lecture(string _string)
        {
            string[] arr = _string.Split(" ");
            id = Convert.ToInt32(arr[0]);
            name = arr[1];
            lastNameTeacher = arr[2];
            date = arr[3];
            lectureTheme = arr[4];
            numberStudents = Convert.ToInt32(arr[5]);
        }
        public void Show()
        {
            Console.WriteLine($" id {id} Назва курсу {name} Викладач {lastNameTeacher} дата {date} тема {lectureTheme} кількіість студентів {numberStudents} ");
        }
        public int GetNumberstudents()
        {
            return numberStudents;
        }
        public void ShowSearchedTheme(string _search)
        {
            var textInfo = new CultureInfo("ua-Ua").TextInfo;
            var capitalizedText = textInfo.ToTitleCase(textInfo.ToLower(_search));


            if (lectureTheme.Contains(capitalizedText))
                Show();
        }
        public int ShowLastTeacher(char _search)
        {
            if (lastNameTeacher[lastNameTeacher.Length - 1] == _search)
            {
                Show();
                return 1;
            }

            else return 0;

        }
        public string GetAll(int idRemove)

        {
            string a1 = id.ToString();
            string a3 = numberStudents.ToString();

            if (id != idRemove)
                return a1 + " " + name + " " + lastNameTeacher + " " + date + " " + lectureTheme + " " + a3;
            return string.Empty;
        }
        public int GetId()
        {
            return id;
        }
        public void Guessingflight(int idChange, int IndexField, string newField)
        {
            string[] arr = {
                "id",
                "name",
                "lastNameTeacher",
                "date",
                "lectureTheme",
                "numberStudents"

            };
            if (idChange == id)
            {
                int a = Array.IndexOf(arr, arr[IndexField]);
                string newF = arr[a];

                if (a == 0 || a == 5)
                {
                    if (newF == "id")
                        id = Convert.ToInt32(newField);
                    else if (newF == "name")
                        name = newField;
                    else if (newF == "lastNameTeacher")
                        lastNameTeacher = newField;
                }
                if (newF == "date")
                    date = newField;
                else if (newF == "lectureTheme")
                    lectureTheme = newField;
                else if (newF == "numberStudents")
                    numberStudents = Convert.ToInt32(numberStudents);

                newF = newField;
            }

        }

    }
}