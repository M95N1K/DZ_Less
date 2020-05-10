using System;
using System.Collections.Generic;

namespace OneDimensArray
{
    public class MyArrays
    {
        int[] arr = null;

        public int Sum  // Сумма элементов
        {
            get
            {
                int sum = 0;
                foreach (int i in arr)
                {
                    sum += i;
                }
                return sum;
            }
        }

        public int MaxCount // Количество максимального элемента
        {
            get
            {
                int count = 0;
                int max = MaxElement();
                foreach (int item in arr)
                {
                    if (item == max)
                        count++;
                }
                return count;
            }
        }

        public MyArrays(int length, int number)
        {
            arr = new int[length];

            for (int i = 0; i < arr.Length; i++)
                arr[i] = number;
        }

        public MyArrays(int length, int min, int max)
        {
            Random rand = new Random();
            arr = new int[length];

            for (int i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(min, max);
        }

        public MyArrays(int length, int start, int step, int nul = 0)
        {
            arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = start;
                start += step;
            }
        }

        public Dictionary<int, int> OccurrenceRate()
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                try
                {
                    result[arr[i]]++;
                }
                catch (Exception)
                {
                    result.Add(arr[i], 1);
                }
            }

            return result;
        }

        public double Mean()  // Среднее значение 
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            return (double)sum / arr.Length;
        }

        public int[] Inverse() // Инверсия знаков в массиве
        {
            int[] result = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = -arr[i];
            }

            return result;
        }

        public void Multi(int number) // Умножение элементов массива на number
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= number;
            }
        }

        public int MaxElement() // Максимальный элемент
        {
            int result = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (result < arr[i])
                    result = arr[i];
            }
            return result;
        }

        public int MinElement() // Минимальный элемент
        {
            int result = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (result > arr[i])
                    result = arr[i];
            }
            return result;
        }

        public int CountPositive() // Количество положительных элементов
        {
            int result = 0;
            foreach (int i in arr)
            {
                if (i > 0)
                    result++;
            }

            return result;
        }

        public override string ToString()
        {
            string result = "";
            foreach (int i in arr)
            {
                result += i + " ";
            }
            return result;
        }
    }
}
