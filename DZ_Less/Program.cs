﻿using System;

//Задание 1
//  Написать метод, возвращающий минимальное из трёх чисел.
//Выполнил Виь В. В.  

namespace DZ_Less2_1
{
    class Program
    {
        static int MinX(int a=3, int b=7, int c=5)
        {
            if (a < b)
                b = a;
            if (b < c)
                c = b;
            return c;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(MinX());

            Console.ReadKey();
        }
    }
}
