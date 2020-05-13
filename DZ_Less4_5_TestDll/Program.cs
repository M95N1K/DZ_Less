using System;
using TwoDimensArray;


//Задание 5
    //* а) Реализовать библиотеку с классом для работы с двумерным массивом.Реализовать конструктор, заполняющий массив случайными числами.
    //      Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, 
    //      свойство, возвращающее минимальный элемент массива, 
    //      свойство, возвращающее максимальный элемент массива, 
    //      метод, возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out).
    //** б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    //** в) Обработать возможные исключительные ситуации при работе с файлами.

//Выполнил Виль В. В.
namespace DZ_Less4_5_TestDll
{
    class Program
    {
        static void Main(string[] args)
        {

            TwoDimens arr = new TwoDimens(5, 5);

            Console.WriteLine(arr.ToString());

            Console.WriteLine(arr.SumElement());

            Console.WriteLine(arr.MinElement);

            Console.WriteLine(arr.MaxElement);

            {
                int row = 0;
                int col = 0;
                arr.NumMaxElement(ref row, ref col);
                Console.WriteLine("{0} x {1}", row, col);
            }

            arr.WriteToFile("data.bin");

            arr = new TwoDimens("data.bin", 5, 5);

            Console.WriteLine(arr.ToString());

            Console.ReadLine();
        }
    }
}
