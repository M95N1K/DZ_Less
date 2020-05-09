using System;

//Задание 2
//  Реализуйте задачу 1 в виде статического класса StaticClass;
//  а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
//  б) * Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
//  в)** Добавьте обработку ситуации отсутствия файла на диске.
//Выполнил Виль В. В.

namespace DZ_Less4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randValue = new Random();
            const byte maxCount = 20;
            int[] intArr = new int[maxCount];
            for (int i = 0; i < maxCount; i++)
            {
                intArr[i] = randValue.Next(-10000, 10000);
            }

            foreach (int value in intArr)
            {
                Console.Write("{0} ", value);
            }

            Console.WriteLine("\nKоличество пар элементов массива, в которых только одно число делится на 3: {0}", Arrays.ColDiv3(intArr));

            intArr = Arrays.ReadFromFile("..\\..\\data.txt");
            foreach (int value in intArr)
            {
                Console.Write("{0} ", value);
            }

            Console.WriteLine("\nKоличество пар элементов массива, в которых только одно число делится на 3: {0}", Arrays.ColDiv3(intArr));

            Console.ReadLine();
        }
    }
}
