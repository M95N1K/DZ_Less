using System;
using System.Diagnostics;

//Задание 4
//  Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
//  На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
//  Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
//  С помощью цикла do while ограничить ввод пароля тремя попытками.
//Выполнил Виль В. В.

namespace DZ_Less2_4
{
    class Program
    {
        static bool LogIn(string login, string password)
        {
            const string log = "root";
            const string pass = "GeekBrains";

            if ((login == log) && (password == pass))
                return true;
            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Подключение к удаленной системе...");
            int c = 3;
            do
            {
                Console.Write("Введите логин: ");
                string log = Console.ReadLine();
                Console.Write("Введите пароль: ");
                string pass = Console.ReadLine();

                //log = "root";
                //pass = "GeekBrains";

                if (LogIn(log, pass))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Доступ разрешен. Запускаю терминал. Для продолжения нажмите AnyKey");
                    Console.ReadKey();
                    Process.Start("cmd.exe");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                } 
                else
                {
                    c--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Доступ запрещен. Неверный логин или пароль. \n Осталось {c} попыток");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (c != 0);

            if (c == 0)
            {
                Console.WriteLine("Обнаружены санкционные продукты...\nОставайтесь на месте за вами выехал трактор\n    Press AnyKey");
                Console.ReadKey();
            }
        }
    }
}
