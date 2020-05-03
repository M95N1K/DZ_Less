using System;

//Задание 2
// Написать метод подсчета количества цифр числа.
//Выполнил Виль В. В.

namespace DZ_Less2_2
{
    class Program
    {
        static int CountNum(int nums = 65234)
        {
            int c = 1;
            do
            {
                nums = nums / 10;
                if (nums > 0)
                    c++;
                else break;
            } while (true);

            return c;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(CountNum());
            Console.ReadKey();
        }
    }
}
