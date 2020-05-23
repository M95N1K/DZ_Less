using System;


//Задание 1
//  Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). 
//  Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
//Выполнил Виль В. В.

namespace DZ_Less
{
    class Program
    {
        public delegate double Function(double variableA, double variableX);

        public static void Table(Function F, double variableA, double variableB, double variableX)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (variableX <= variableB)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", variableX, F(variableA, variableX));
                variableX += 1;
            }
            Console.WriteLine("---------------------");
        }

        public static double FunctionOne(double varA, double varX)
        {
            return varA * varX * varX;
        }

        public static double FunctionTwo(double varA, double varX)
        {
            return varA * Math.Sin(varX);
        }

        static void Main(string[] args)
        {
            double a = 2;
            double b = 10;
            double x = 1;
            Console.WriteLine("-----a*x^2-----");
            Table(FunctionOne, a, b, x);
            Console.WriteLine("-----a*sin(x)-----");
            Table(FunctionOne, a, b, x);

            Console.ReadLine();
        }
    }
}
