using System;

//Задание 1
//  
//Выполнил Виль В. В.

namespace DZ_Less3_1
{
    class Complex
    {
        double re, im;

        public double Re { get { return re; } set { re = value; } }
        
        public double Im { get { return im; } set { im = value; } }

        public Complex()
        {
            re = 0;
            im = 0;
        }

        public Complex(double _re , double _im)
        {
            im = _im;
            re = _re;
        }

        public Complex ComplexSum(Complex second)
        {
            Complex sum = new Complex();
            sum.re = this.re + second.re;
            sum.im = this.im + second.im;
            return sum;
        }

        public Complex ComplexSubtraction(Complex second)
        {
            Complex sub = new Complex();
            sub.re = this.re - second.re;
            sub.im = this.im - second.im;
            return sub;
        }

        public Complex ComplexMultiplication(Complex second)
        {
            Complex mult = new Complex();
            mult.re = (this.re * second.re - this.im*second.im);
            mult.im = (this.im*second.re + this.re*second.im);
            return mult;
        }

        public Complex ComplexDivision(Complex second)
        {
            Complex div = new Complex();
            div.re = (this.re * second.re + this.im * second.im) / (second.re* second.re + second.im* second.im);
            div.im = (this.im * second.re - this.re * second.im) / (second.re * second.re + second.im * second.im);
            return div;
        }

        public override string ToString()
        {
            if (im >= 0)
                return re + "+" + im + "i";
            else return re + "" +  im + "i";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Complex ComplexA = new Complex(12, 15);
            Complex ComplexB = new Complex(3, 7);
            Complex result = new Complex();

            Console.WriteLine("Число А: {0}", ComplexA.ToString());
            Console.WriteLine("Число B: {0}", ComplexB.ToString());

            result = ComplexA.ComplexSum(ComplexB);
            Console.WriteLine("Результат сложения: {0}", result.ToString());
            result = ComplexA.ComplexSubtraction(ComplexB);
            Console.WriteLine("Результат вычитания: {0}", result.ToString());
            result = ComplexA.ComplexMultiplication(ComplexB);
            Console.WriteLine("Результат умножения: {0}", result.ToString());
            result = ComplexA.ComplexDivision(ComplexB);
            Console.WriteLine("Результат деления: {0}", result.ToString());

            Console.ReadLine();
        }
    }
}
