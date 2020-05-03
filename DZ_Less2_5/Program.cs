using System;

//Задание 5
//  а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
//  б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
//Выполнил Виль В .В.

namespace DZ_Less2_5
{
    class Program
    {
        static int IndexMass(double massa, double heigh)
        {
            int ind = (int)(massa / (heigh * heigh));
            return ind;
        }

        static double ToNormIndex(double massa, double heigh)
        {
            int index = (int)(massa / (heigh * heigh));

            if (index < 20)
            {
                int m = (int)(22 * heigh * heigh);
                return (massa - m);
            }
            else if (index > 25)
            {
                int m = (int)(26 * heigh * heigh);
                return (massa - m);
            }
            return 0;
        }

        static void Main(string[] args)
        {
            Console.Write("Введите вес в кг: ");
            double mas = Convert.ToDouble(Console.ReadLine().Replace('.',','));
            Console.Write("Введите рост в м: ");
            double hgh = Convert.ToDouble(Console.ReadLine().Replace('.', ','));

            Console.WriteLine($"Ваш индекс массы равен {IndexMass(mas, hgh)}");
            if (ToNormIndex(mas, hgh) < 0)
                Console.WriteLine($"Вам надо набрать {ToNormIndex(mas, hgh) * (-1)} кг");
            else if (ToNormIndex(mas, hgh) > 0)
                Console.WriteLine($"Вам надо похудеть на {ToNormIndex(mas, hgh)} кг");
            else Console.WriteLine("Ваш вес в норме");

            Console.ReadKey();
        }
    }
}
