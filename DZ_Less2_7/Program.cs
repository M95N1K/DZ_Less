using System;
using VClass;

//Задание 7
//  a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
//  б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
//Выполнил Виль В. В. 

namespace DZ_Less2_7
{
    class Program
    {
        static void PrintAB(int first , int second)
        {
            Console.WriteLine(first);
            if (first < second)
                PrintAB(first + 1, second);

        }

        static int SumAB(int first, int second)
        {
            int sum = 0;
            if (first < second)
            {
                sum = first + SumAB(first + 1, second);
            }
            else sum = first;

            return sum;
        }

        static void Main(string[] args)
        {
            int numA, numB;
            do
            {
                numA = Cons.ReadInt("Введите число А: ");
                numB = Cons.ReadInt("Введите число Б(больше чем А): ");
            } while (numB <= numA);

            PrintAB(numA, numB);

            Console.Write($"Сумма чисел равна {SumAB(numA, numB)}");

            Cons.Pause();
        }
    }
}
