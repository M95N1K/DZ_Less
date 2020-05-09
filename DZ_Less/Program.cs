using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Задание 1
//  Дан  целочисленный  массив  из 20 элементов.  Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно. 
//  Заполнить случайными числами.  Написать программу, позволяющую найти и вывести количество пар элементов массива, 
//      в которых только одно число делится на 3. 
//  В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 
// 
//Выполнил Виль В. В.

namespace DZ_Less4_1
{
    class Program
    {
        static Random randValue = new Random();
        const byte maxCount = 20;

        static int ColDiv3(int[] value)
        {
            int count = 0;
            for (int i = 0; i < value.Length-1; i++)
            {
                if ((value[i] % 3 == 0) && (value[i + 1] % 3 != 0))
                    count++;
            }
            
            return count;
        }
        static void Main(string[] args)
        {
            int[] intArr = new int[maxCount];
            for (int i = 0; i < maxCount; i++)
            {
                intArr[i] = randValue.Next(-10000, 10000);
            }

            foreach (int value in intArr)
            {
                Console.Write("{0} ", value);
            }

            Console.WriteLine("количество пар элементов массива, в которых только одно число делится на 3: {0}", ColDiv3(intArr));

            Console.ReadLine();
        }
    }
}
