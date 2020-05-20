using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace DZ_Less6_3
{
    public struct Student
    {
        public string firstName;
        public string secondName;
        public string univercity;
        public string faculty;
        public string department;
        public int age;
        public int course;
        public int group;
        public string city;
    }

    class Program
    {
        

        static Student[] ParseToStudent(string filePath)
        {
            List<Student> result = new List<Student>();

            if (!(File.Exists(filePath)))
                return null;
            StreamReader inFile = new StreamReader(filePath);
            inFile.ReadLine();
            while (!(inFile.EndOfStream))
            {
                string inLine = inFile.ReadLine();
                string[] arrDate = inLine.Split(';');
                Student stuTemp;
                int i = 0;
                stuTemp.secondName = arrDate[i++];
                stuTemp.firstName = arrDate[i++];
                stuTemp.univercity = arrDate[i++];
                stuTemp.faculty = arrDate[i++];
                stuTemp.department = arrDate[i++];
                if (!(int.TryParse(arrDate[i++], out stuTemp.age)))
                    return null;
                if (!(int.TryParse(arrDate[i++], out stuTemp.course)))
                    return null;
                if (!(int.TryParse(arrDate[i++], out stuTemp.group)))
                    return null;
                stuTemp.city = arrDate[i++];
                result.Add(stuTemp);
            }
            inFile.Close();
            return result.ToArray();
        }

        static int CountMagist(Student[] students)
        {
            int result = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].course >= 5)
                    result++;
            }
            return result;
        }

        static Dictionary<int , int> Col18To20OfCource(Student[] students)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            result.Add(1, 0);
            result.Add(2, 0);
            result.Add(3, 0);
            result.Add(4, 0);
            result.Add(5, 0);
            result.Add(6, 0);

            for (int i = 0; i < students.Length; i++)
            {
                if ((students[i].age >= 18) && (students[i].age <= 20))
                    result[students[i].course]++;
            }

            return result;
        }

        static void SortByCource(ref Student[] students)
        {
            bool trans = false;
            do
            {
                trans = false;
                for (int i = 0; i < students.Length-1; i++)
                {
                    if (students[i].course > students[i + 1].course)
                    {
                        Student tmp = students[i];
                        students[i] = students[i + 1];
                        students[i + 1] = tmp;
                        trans = true;
                    }
                }
            } while (trans);
        }

        static void DobleSort(ref Student[] students)
        {
            SortByCource(ref students);
            int maxCourse = students[students.Length - 1].course;
            int minCourse = students[0].course;
            bool trans = false;
            for (int course = minCourse; course <= maxCourse; course++)
            {
                do
                {
                    trans = false;
                    for (int i = 0; i < students.Length-1; i++)
                    {
                        if (students[i+1].course > course)
                            break;
                        else if (students[i+1].course < course)
                            continue;
                        else if (students[i].course == course)
                        {
                            if (students[i].age > students[i+1].age)
                            {
                                Student tmp = students[i];
                                students[i] = students[i + 1];
                                students[i + 1] = tmp;
                                trans = true;
                            }
                        }

                    }
                } while (trans);
            }
        }


        static void Main(string[] args)
        {
            string fileName = "..\\..\\students.csv";
            Student[] students = ParseToStudent(fileName);
            if (students is null)
            {
                WriteLine("Ошибка обработки данных");
                ReadLine();
                return;
            }
            else WriteLine("Все ОК!!!");

            WriteLine("Количество магистров: {0}", CountMagist(students));
            Dictionary<int, int> stud = new Dictionary<int, int>();
            WriteLine("Курс - Количество студентов от 18 до 20 лет");
            WriteLine(Col18To20OfCource(students).DictToString());
            WriteLine("ДО");
            WriteLine("Имя - Фамилия - Курс - Возраст");
            for (int i = 0; i < students.Length; i++)
            {
                WriteLine(students[i].StudToStringParts());
            }
            WriteLine("ПОСЛЕ");
            DobleSort(ref students);
            WriteLine("Имя - Фамилия - Курс - Возраст");
            for (int i = 0; i < students.Length; i++)
            {
                WriteLine(students[i].StudToStringParts());
            }
            ReadLine();
        }

        
    }

    internal static class Helps
    {
        public static string DictToString(this Dictionary<int, int> dict)
        {
            string result = "";
            foreach (KeyValuePair<int, int> item in dict)
            {
                result += string.Format("{0,4} - {1}\n", item.Key, item.Value);
            }
            return result;
        }

        public static string StudToStringParts(this Student student)
        {
            string result = string.Format("{0,15} - {1,10} - {2,1} - {3,3}",student.firstName , student.secondName , student.course , student.age);
            return result;
        }
    }
}
