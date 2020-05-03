using System;

//Задание 3
//  С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
//Выполнил Виль В.В.

namespace DZ_Less2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целые числа (для выхода введите 0)");
            int n = 0;
            int sum = 0;
            do
            {
              n = Convert.ToInt32(Console.ReadLine());
              sum += n;
            } while (n != 0);

            Console.WriteLine($"Сумма числе равна {sum}");
            Console.ReadKey();
        }
    }
}
