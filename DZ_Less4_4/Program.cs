using System;
using System.IO;
using VClass;

namespace DZ_Less4_4
{

    class Program
    {

        struct LoginData
        {
            public string login;
            public string pass;
        }

        /// <summary>
        ///   Заполняет массив из файла и возвращает его
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        static LoginData[] FileToArray(string path)
        {
            if (!File.Exists(path))
                return null;

            LoginData[] result = new LoginData[ColLineInFile(path) / 2];
            StreamReader file = new StreamReader(path);
            int count = 0;
            while (!file.EndOfStream)
            {
                result[count].login = file.ReadLine();
                result[count].pass = file.ReadLine();
                count++;
            }
            return result;
        }

        /// <summary>
        ///   Возвращает количество строк в файле
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        static int ColLineInFile(string path)
        {
            if (!File.Exists(path))
                return 0;

            StreamReader file = new StreamReader("..\\..\\data.bin");
            int count = 0;
            while (!file.EndOfStream)
            {
                file.ReadLine();
                count++;
            }
            file.Dispose();

            return count;
        }

        /// <summary>
        ///     Идентификация пользователя
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        static bool LogIn(string login, string password)
        {
            const string path = "..\\..\\data.bin";

            if (!File.Exists(path))
                return false;
           
            LoginData[] arrLogin = new LoginData[ColLineInFile(path) / 2];
            arrLogin = FileToArray(path);

            foreach (LoginData item in arrLogin)
            {
                if ((item.login == login) && (item.pass == password))
                    return true;
            }

            return false;
        }
        static void Main(string[] args)
        {
            LoginData userDate;
            userDate.login = Cons.Read("Введите логин: ");
            userDate.pass = Cons.Read("Введите пароль: ");

            if (LogIn(userDate.login, userDate.pass))
            {
                Cons.PrintС("Вход разрешен", ConsoleColor.Green);
            }
            else Cons.PrintС("Неверный логин или пароль", ConsoleColor.Red);

            Cons.Pause();
        }
    }
}
