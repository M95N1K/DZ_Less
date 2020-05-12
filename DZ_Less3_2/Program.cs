using System;
using System.Collections.Generic;

//Задание 2
//  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
//  Требуется подсчитать сумму всех нечётных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse.
//Выполнил Виль В.В.

namespace DZ_Less3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool key;
            Console.WriteLine("Вводите числа (для выхода введите 0)");
            List<int> numList = new List<int>();
            int num;
            do
            {
                //ArgumentException;
                key = int.TryParse(Console.ReadLine(), out num);
                if (key && (num % 2 != 0) && num > 0)
                {
                    numList.Add(num);
                }
                else if (!key)
                {
                    num = -1;
                    Console.WriteLine("Ошибочный ввод");
                }
            } while (num != 0);

            foreach (int i in numList)
            {
                Console.Write("{0}, ", i);
            }

            Console.WriteLine("Сумма чисел равна: {0}", SumList(numList));

            Console.ReadLine();
        }

        static int SumList( List<int> nList)
        {
            int sum = 0;
            foreach (int i in nList)
            {
                sum += i;
            }
            return sum;
        }
    }
}
