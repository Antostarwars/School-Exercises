using System.Diagnostics;

namespace OperatorOverriding
{
    class RationalNumber
    {
        public static int Euclid(int a, int b)
        {
            Debug.Assert(a > 0 && b > 0);
            while (b > 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        private int num, den;  // dovrà sempre essere (den > 0)

        public RationalNumber(int num, int den)
        {
            if (num == 0)
                throw new Exception("Invalid denominator value");

            this.num = num;
            this.den = den;

            Normalize();
        }
        public RationalNumber(int number) : this(number, 1) { }
        public RationalNumber() : this(0, 1) { }
        private void Normalize()
        {
            if (den < 0)
            {
                den = -den;
                num = -num;
            }

            int MCD = Euclid(Math.Abs(num), den);
            Debug.Assert(num % MCD == 0 && den % MCD == 0);
            num /= MCD;
            den /= MCD;
        }

        public static RationalNumber operator +(RationalNumber a, RationalNumber b) => new RationalNumber(a.num * b.den + b.num * a.den, a.den * b.den);
        public static RationalNumber operator -(RationalNumber a, RationalNumber b) => new RationalNumber(a.num * b.den - b.num * a.den, a.den * b.den);
        public static RationalNumber operator *(RationalNumber a, RationalNumber b) => new RationalNumber(a.num * b.num, a.den * b.den);
        public static RationalNumber operator /(RationalNumber a, RationalNumber b) => new RationalNumber(a.num * b.den, a.den * b.num);
        public static bool operator <(RationalNumber a, RationalNumber b) => a.num * b.den < b.num * a.den;
        public static bool operator >(RationalNumber a, RationalNumber b) => b < a;
        public static bool operator <=(RationalNumber a, RationalNumber b) => a.num * b.den <= b.num * a.den;
        public static bool operator >=(RationalNumber a, RationalNumber b) => b <= a;
        public static bool operator ==(RationalNumber a, RationalNumber b) => a.num == b.num && a.den == b.den;
        public static bool operator !=(RationalNumber a, RationalNumber b) => !(a == b);
        public static RationalNumber operator ++(RationalNumber a) => new RationalNumber(a.num + a.den, a.den);
        public static RationalNumber operator --(RationalNumber a) => new RationalNumber(a.num - a.den, a.den);

        public override string ToString()
        {
            if (den == 1)
                return $"{num}";
            if (num < 0)
                return $"({num}/{den})";
            return $"{num}/{den}";
        }
    }
}
