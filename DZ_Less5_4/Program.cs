using System;
using static System.Console;
using VClass;
using System.IO;
using System.Text.RegularExpressions;

//Задание 4
//  На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
//  В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, 
//  каждая из следующих N строк имеет следующий формат:
//      <Фамилия> <Имя> <оценки>,
//  где <Фамилия> — строка, состоящая не более чем из 20 символов, 
//  <Имя> — строка, состоящая не более чем из 15 символов, 
//  <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. 
//  <Фамилия> и<Имя>, а также<Имя> и<оценки> разделены одним пробелом. Пример входной строки:


namespace DZ_Less5_4
{
    class Program
    {
        struct Student
        {
            public string surname;
            public string name;
            public byte[] assessments;
            public double average;
        }


        static void Main(string[] args)
        {
            StreamReader file;
            try
            {
                int colStudents = 0;
                string path = "..\\..\\data.txt";
                
                if (File.Exists(path))
                {
                    file = new StreamReader(path);
                }
                else throw new FileNotFoundException("Ненайдн файл");
           
                if (!int.TryParse(file.ReadLine() , out colStudents))
                    colStudents = 0;

                if (!((colStudents > 10) && (colStudents <= 100)))
                    throw new Exception("Ошибка в файле данных. Количество учеников не соответствует (от 11 до 100)");
            

                Student[] students = new Student[colStudents];
                Regex maska = new Regex("^[A-ZА-Я][a-zа-я]{1,19} [A-ZА-Я][a-zа-я]{0,14} [1-5] [1-5] [1-5]");

                for (int i = 0; i < colStudents; i++)
                {
                    string strDate = file.ReadLine();
                    string date = "";
                    if (maska.IsMatch(strDate))
                        date = strDate;
                    else throw new Exception("Ошибка формата данных в файле");
                    
                    string[] arrDate = date.Split(' ');
                    students[i].surname = arrDate[0];
                    students[i].name = arrDate[1];
                    students[i].assessments = new byte[3];
                    students[i].assessments[0] = byte.Parse(arrDate[2]);
                    students[i].assessments[1] = byte.Parse(arrDate[3]);
                    students[i].assessments[2] = byte.Parse(arrDate[4]);
                    double tmp = (double)(students[i].assessments[0] + students[i].assessments[1] + students[i].assessments[2]) / 3 * 10;
                    students[i].average = Math.Round(tmp) /10;
                    WriteLine("{0} {1} - {2}", students[i].surname, students[i].name, students[i].average);
                }

                WriteLine("\n -------------------------------------------------------------- \n");
                WriteLine("Фамилии и Имена худших по среднему баллу");
                double[] moreOfLess = new double[3];
                for (int num = 0; num < 3; num++)
                {
                    double minAverage = 5;
                    int index = (num > 0) ? num - 1 : 0;
                    for (int i = 0; i < colStudents; i++)
                    {
                        if ((students[i].average < minAverage) && ((students[i].average > moreOfLess[index])))
                            minAverage = students[i].average;
                    }
                    moreOfLess[num] = minAverage;
                }

                for (int i = 0; i < colStudents; i++)
                {
                    if ((students[i].average == moreOfLess[0]) || (students[i].average == moreOfLess[1]) || (students[i].average == moreOfLess[2]))
                        WriteLine("{0} {1} - {2}", students[i].surname, students[i].name, students[i].average);
                }

            }
            catch (Exception ex)
            {
                Cons.PrintС(ex.Message, ConsoleColor.Red);
            }
            
            Cons.Pause();
        }
    }
}
