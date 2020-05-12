using System;


namespace DZ_Less3_3
{
    class Simple_Fractions
    {
        int whole;
        int numerator;
        int denominator=2;

        public int Whole { get => whole; set => whole = value; }
        public int Numerator { get => numerator; set => numerator = value; }
        public int Denominator 
        {   get => denominator;
            set 
            {
                if (value != 0)
                    denominator = value;
                else throw new ArgumentException("Знаменатель не должен ровняться 0");
            } 
        }
        public double DecimalFactions { 
            get
            {
                return ((double)whole + (double)numerator / (double)denominator);
            }
        }

        public Simple_Fractions() 
        {
            Whole = 0;
            Numerator = 0;
            Denominator = 1;
        }

        public Simple_Fractions(int _Whole , int _Numerator, int _Denominator)
        {
            Whole = _Whole;
            Numerator = _Numerator;
            Denominator = _Denominator;
        }

        public Simple_Fractions Sum(Simple_Fractions second)
        {
            this.UnWholePart();
            second.UnWholePart();
            Simple_Fractions result = new Simple_Fractions();
            //result.Whole = this.Whole + second.Whole;
            result.Numerator = this.Numerator * second.Denominator + second.Numerator* this.Denominator;
            result.Denominator = this.Denominator * second.Denominator;
            this.WholePart();
            second.WholePart();
            result.WholePart();
            return result;
        }

        public Simple_Fractions Subtraction(Simple_Fractions second)
        {
            this.UnWholePart();
            second.UnWholePart();
            Simple_Fractions result = new Simple_Fractions();
            //result.Whole = this.Whole - second.Whole;
            result.Numerator = this.Numerator * second.Denominator - second.Numerator * this.Denominator;
            result.Denominator = this.Denominator * second.Denominator;
            this.WholePart();
            second.WholePart();
            result.WholePart();
            return result;
        }

        public Simple_Fractions Multiplication(Simple_Fractions second)
        {
            this.UnWholePart();
            second.UnWholePart();
            Simple_Fractions result = new Simple_Fractions();
            //result.Whole = this.Whole * second.Whole;
            result.Numerator = this.Numerator * second.Numerator;
            result.Denominator = this.Denominator * second.Denominator;
            this.WholePart();
            second.WholePart();
            result.WholePart();
            return result;
        }

        public Simple_Fractions Division(Simple_Fractions second)
        {
            this.UnWholePart();
            second.UnWholePart();
            Simple_Fractions result = new Simple_Fractions();
            //result.Whole = this.Whole / second.Whole;
            result.Numerator = this.Numerator * second.Denominator;
            result.Denominator = this.Denominator * second.Numerator;
            this.WholePart();
            second.WholePart();
            result.WholePart();
            return result;
        }

        public void WholePart()  // Выделяем целую часть (переводим в првильный вид)
        {
            Whole += Numerator / Denominator;
            Numerator = Numerator % Denominator;
        }

        public void UnWholePart() // Переводим в неправильный вид
        {
            Numerator += Whole * Denominator;
            Whole = 0;
        }

        public void FractionReduction() // Сокращение (упрощение) дроби
        {
            this.WholePart();
            int nod = NOD(this.Numerator, this.Denominator);
            Numerator = Numerator / nod;
            Denominator = Denominator / nod;
        }

        int NOD (int first, int second) // Нахождение Наибольшего Общего Делителя
        {
            if (first < 0)
                first = -first;
            do
            {
                if (first > second)
                    first = first % second;
                else second = second % first;
            } while ((first != 0) && (second != 0));

            return first + second;
        }

        public override string ToString()
        {
            string result = "";
            if (whole != 0)
                result = Convert.ToString(Whole) + " ";
            if (numerator != 0)
                result +=Convert.ToString(Numerator) + "/" + Convert.ToString(Denominator);
            return result;
        }
    }
}
