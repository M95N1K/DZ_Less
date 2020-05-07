using System;


//Задание 3
//  *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
//      Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, демонстрирующую все разработанные элементы класса.
//  * Добавить свойства типа int для доступа к числителю и знаменателю;
//  * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
//  ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
//  *** Добавить упрощение дробей.
//Выполнил Виль В. В.

namespace DZ_Less3_3
{
    class Program
    {
        static void Main(string[] args)
        {

            Simple_Fractions fractionsA = new Simple_Fractions(1, 5, 7);
            Simple_Fractions fractionsB = new Simple_Fractions(2, 4, 6);
            Simple_Fractions fractionsC = new Simple_Fractions();

            Console.WriteLine("Дробь А равна: {0}",fractionsA.ToString());
            Console.WriteLine("Дробь B равна: {0}", fractionsB.ToString());

            fractionsC = fractionsA.Sum(fractionsB);
            fractionsC.FractionReduction();
            Console.WriteLine("Сложение : {0}", fractionsC.ToString());
            fractionsC = fractionsA.Subtraction(fractionsB);
            fractionsC.FractionReduction();
            Console.WriteLine("Вычитание: {0}", fractionsC.ToString());
            fractionsC = fractionsA.Multiplication(fractionsB);
            fractionsC.FractionReduction();
            Console.WriteLine("Умножение: {0}", fractionsC.ToString());
            fractionsC = fractionsA.Division(fractionsB);
            fractionsC.FractionReduction();
            Console.WriteLine("Деление: {0}", fractionsC.ToString());

            Console.ReadLine();

        }
    }
}
