using System;
using System.Text.RegularExpressions;
using static System.Console;
using static VClass.Cons;


//Задание 1
//  Создать программу, которая будет проверять корректность ввода логина.
//  Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
//  а) без использования регулярных выражений;
//  б) ** с использованием регулярных выражений.
//Выполнил Виль В. В.

namespace DZ_Less5_1
{
    class Program
    {

        static bool IsCorrect(string login) //Проверка на корректность введенного логина
        {
            bool result = true;
            string mess = "";
            if ((login.Length < 2) || ((login.Length > 20)))
            {
                result = false;
                mess += " -[ERROR] Логин должен быть длиной от 2 до 20 символов \n";
            }

            if ((login[0] >= '0') && ((login[0] <= '9')))
            {
                result = false;
                mess += " -[ERROR] Первый символ логина не должен являться цифрой \n";
            }
            foreach (char sym in login.ToUpper())
            {
                if (!(((sym > 47) && (sym < 58)) || ((sym > 64) && (sym < 91))))
                {
                    result = false;
                    mess += " -[ERROR] Логин должен содержать только буквы латинского алфавита или цифры \n";
                }
            }
            if (!result)
            {
                Clear();
                PrintС(mess, ConsoleColor.Red);
            }
            return result;
        }

        static bool IsCorrectMask(string login) //Проверка на корректность введенного логина регулярным вырожением
        {
            bool result;
            Regex mask = new Regex("([A-Za-z][A-Za-z0-9]{1,19})");
            result = mask.IsMatch(login);
            return result;
        }

        static void Main(string[] args)
        {
            bool correct = true;
            do
            {
                if (!correct)
                {
                    PrintС("Введен неверный логин \n  - Логин должен быть длиной от 2 до 20 символов \n  - Первый символ логина не должен являться цифрой \n - Логин должен содержать только буквы латинского алфавита или цифры", ConsoleColor.Red);
                }
                correct = IsCorrectMask(Read("Введие логин: "));
            } while (!correct);

            //ReadMask("[A-Za-z][A-Za-z0-9]{1,19}", "Введите логин: ", true, "Введен неверный логин \n  - Логин должен быть длиной от 2 до 20 символов \n  - Первый символ логина не должен являться цифрой \n - Логин должен содержать только буквы латинского алфавита или цифры\n");

            Pause();
        }
    }
}
