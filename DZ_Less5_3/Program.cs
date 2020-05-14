using System;
using System.Collections.Generic;

//Задание 3
//   * Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
//       Например:
//      badc являются перестановкой abcd.
//Выполнил Виль В.В.

namespace DZ_Less5_3
{
    class Program
    {

        static bool Transposition(string textFirst, string textSecond)
        {
            textFirst = textFirst.ToLower();
            textSecond = textSecond.ToLower();

            if (textFirst.Length != textSecond.Length)
                return false;

            Dictionary<char, int> transposFirst = new Dictionary<char, int>();
            Dictionary<char, int> transposSecond = new Dictionary<char, int>();

            for (int i = 0; i < textFirst.Length; i++)
            {
                if (!(transposFirst.ContainsKey(textFirst[i])))
                    transposFirst.Add(textFirst[i], 1);
            }

            for (int i = 0; i < textSecond.Length; i++)
            {
                if (!(transposSecond.ContainsKey(textSecond[i])))
                    transposSecond.Add(textSecond[i], 1);
            }

            foreach (KeyValuePair<char, int> item in transposFirst)
            {
                if (!((transposSecond.ContainsKey(item.Key)) && (transposSecond[item.Key] == item.Value)))
                    return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            string first = "asdf1";
            string second = "fsda1";
            if (Transposition(first, second))
                Console.WriteLine("Строка {0} является перестановкой {1}", first, second);
            else Console.WriteLine("Строка {0} не является перестановкой {1}", first, second);
            Console.WriteLine();
            first = "asdf1п";
            second = "fsda1ы";
            if (Transposition(first, second))
                Console.WriteLine("Строка {0} является перестановкой {1}", first, second);
            else Console.WriteLine("Строка {0} не является перестановкой {1}", first, second);

            Console.ReadLine();
        }
    }
}
