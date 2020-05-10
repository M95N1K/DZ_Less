using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Задание 3
//  а) Дописать класс для работы с одномерным массивом. 
//      Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом. 
//      Создать свойство Sum, которое возвращает сумму элементов массива, 
//      метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений),  
//      метод Multi, умножающий каждый элемент массива на определённое число, 
//      свойство MaxCount, возвращающее количество максимальных элементов. 
//  б)** Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотеки
//  е) *** Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary<int, int>)
//Выполнил Виль В.В.
namespace DZ_Less4_3
{
    class Program
    {
        static string ArrToString(int[] arrs)
        {
            string result = "";
            foreach (int item in arrs)
            {
                result += item + " ";
            }
            return result;
        }

        static void Main(string[] args)
        {

            OneDimensionalArrays ars = new OneDimensionalArrays(20, 10, 20);
            Dictionary<int, int> rate = ars.OccurrenceRate();
            int[] invert;

            Console.WriteLine(ars.ToString());

            Console.WriteLine("Сумма элементов равна: {0}", ars.Sum);

            Console.WriteLine("Данные вхождений");
            foreach (KeyValuePair<int, int> item in rate) 
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
            }

            Console.WriteLine("Количество максимального ({1}) элементa: {0}", ars.MaxCount, ars.MaxElement());

            Console.WriteLine("Минимальный элемент {0}", ars.MinElement());
            Console.WriteLine("Среднее значение: {0:.00}", ars.Mean());
            Console.WriteLine("Количество положительных элементов: {0}", ars.CountPositive());
            invert = ars.Inverse();
            Console.WriteLine("Инвертирование массива \n{0}", ArrToString(invert));
            ars.Multi(2);
            Console.WriteLine("Массив умноженный на 2 \n{0}", ars.ToString());

            Console.ReadLine();
        }
    }
}
