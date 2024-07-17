namespace Fraction
{
    class Fraction
    {
        int numerator;
        int denominator;

        public int Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return denominator;
            }
            set
            {

                denominator = value;

            }
        }

        public Fraction(int n, int d)
        {
            numerator = n;
            denominator = d;
        }

        public Fraction()
        {
            numerator = 0;
            denominator = 0;
        }



        public static int NaObZn(int den0, int den1)// наименьший общий знаменатель
        {
            if (den1 % den0 == 0)
                return den1;

            int rez = 0;
            for (int i = 2; ; i++)
            {
                rez = den1 * i;
                if (rez % den0 == 0)
                {
                    break;
                }
            }
            return rez;
        }

        public static Fraction operator +(Fraction a, Fraction b) //сложение
        {
            Fraction fraction = new Fraction(0, NaObZn(a.Denominator, b.Denominator));

            fraction.numerator = fraction.denominator / a.Denominator * a.Numerator;
            fraction.numerator += fraction.denominator / b.Denominator * b.Numerator;

            return fraction;
        }

        public static Fraction operator -(Fraction a, Fraction b) //вычитание
        {
            Fraction fraction = new Fraction(0, NaObZn(a.Denominator, b.Denominator));

            fraction.numerator = fraction.denominator / a.Denominator * a.Numerator;
            fraction.numerator -= fraction.denominator / b.Denominator * b.Numerator;

            return fraction;
        }

        public static Fraction operator *(Fraction a, Fraction b) //умножение
        {
            Fraction fraction = new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
            return fraction;
        }

        public static Fraction operator *(Fraction a, int b)
        {
            Fraction fraction = new Fraction(a.numerator * b, a.denominator * b);
            return fraction;
        }

        public static Fraction operator /(Fraction a, Fraction b) //деление
        {
            Fraction fraction = new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
            return fraction;
        }

        public static Fraction operator /(Fraction a, int b)
        {
            Fraction fraction = new Fraction(a.numerator, a.denominator * b);
            return fraction;
        }

        public void Reduce()//сокращение
        {
            this.Numerator = this.Numerator > 0 ? this.Numerator : -this.Numerator;
            this.Denominator = this.Denominator > 0 ? this.Denominator : -this.Denominator;

            int maxVal = Numerator > Denominator ? Numerator : Denominator;
            for (int i = maxVal; i >= 2; maxVal--)
            {
                if (Numerator % maxVal == 0 && Denominator % maxVal == 0)
                {
                    this.Numerator /= maxVal;
                    this.Denominator /= maxVal;
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            Fraction drob1 = new Fraction();
            Fraction drob2 = new Fraction();


            //  2/3
            drob1.numerator = 2;
            drob1.denominator = 3;

            //  4/5
            drob2.numerator = 4;
            drob2.denominator = 5;

            Fraction rez = drob1 + drob2;

            rez.Reduce();

            Console.WriteLine(rez.numerator + "/" + rez.denominator);
        }
    }
}