using System;
using System.Globalization;
using System.IO;
using VClass;

//Задание 2
//  Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
//  а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум.
//      Использовать массив(или список) делегатов, в котором хранятся различные функции.
//  б) * Переделать функцию Load, чтобы она возвращала массив считанных значений.
//      Пусть она возвращает минимум через параметр(с использованием модификатора out). 
//Выполнил Виль В. В.

namespace DZ_Less6_2
{
    class Program
    {
        public delegate double Function(double x);

        public static double Func(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static void SaveFunc(string fileName, Function F, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double[] Load(string fileName, out double minimum)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double[] arrFx = new double[fs.Length / sizeof(double)];
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = bw.ReadDouble();
                arrFx[i] = d;
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            minimum = min;
            return arrFx; ;
        }

        static string ToCurentDecimalSeparator(string strDecimal)
        {
            CultureInfo myCIintl = new CultureInfo(CultureInfo.CurrentCulture.Name);
            string numSeparator = myCIintl.NumberFormat.NumberDecimalSeparator;
            string result = strDecimal;
            result = result.Replace(".", numSeparator);

            return result;
        }

        static double GetDate(string mask, string text)
        {
            string tmp = Cons.ReadMask(mask, text);
            tmp = ToCurentDecimalSeparator(tmp);
            return double.Parse(tmp);
        }

        static void Main(string[] args)
        {
            string f1 = "Func (квадратное уравнение)";
            string f2 = "Sin";
            string f3 = "Cos";

            Function[] functions = new Function[3];
            functions[0] = Func;
            functions[1] = Math.Sin;
            functions[2] = Math.Cos;
            Cons.PrintС($"1 - {f1}\n2 - {f2}\n3 - {f3}\n", ConsoleColor.Yellow);
            int ansv = int.Parse(Cons.ReadMask("[1-3]", "Выберите функцию: ", true));

            double min = GetDate("^-?[0-9]{1,}[,]{0,1}[0-9]{0,}", "Введите минимальное значение Х: ");

            double max = GetDate("^-?[0-9]{1,}[,]{0,1}[0-9]{0,}", "Введите максимальное значение Х: ");

            double step = GetDate("^[0-9]{1,}[,]{0,1}[0-9]{0,}", "Введите максимальное значение Х: ");

            double minFx = 0;
            SaveFunc("data.bin", functions[ansv - 1], min, max, step);
            double[] value;
            value = Load("data.bin", out minFx);
            Console.WriteLine("Значения функции {0}", functions[ansv - 1].Method.Name);
            foreach (double item in value)
            {
                Console.Write("{0:0.00}  ", item);
            }
            Console.WriteLine();
            Cons.PrintС($"Минимум функции на отрезке {min:0.00} -  {max:0.00}: {minFx:0.00}", ConsoleColor.Yellow);
            //Console.WriteLine($"Минимум функции на отрезке {min:0.00} -  {max:0.00}: {minFx:0.00}");
            Cons.Pause();
        }
    }
}
