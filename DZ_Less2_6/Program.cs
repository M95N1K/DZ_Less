using System;

//Задание 6
//  *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. «Хорошим» называется число, которое делится на сумму своих цифр. 
//  Реализовать подсчёт времени выполнения программы, используя структуру DateTime
//Выполнил Виль В. В.

namespace DZ_Less2_6
{
    class Program
    {
        
        static int Sum(int num)
        {
            
            int s = 0;
            do
            {
                if (num > 9)
                {
                    s += num % 10;
                    num = num / 10;
                }
                else
                {
                    s += num;
                    break;
                }
            } while (true);
            return s;

        }

        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            int count = 0;
            for (int i = 1; i < 1000000000; i++)
            {
                if (i % Sum(i) == 0)
                    count++;
            }
            Console.WriteLine($"Количество <<хороших>> {count}");
            DateTime finish = DateTime.Now;
            Console.WriteLine($"Подсчет занял {finish - start}");
            Console.ReadLine();
        }
    }
}
