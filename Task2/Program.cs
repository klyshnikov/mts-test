using System;
using System.Globalization;

class Program
{
    static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

    class Number
    {
        readonly int _number;

        public Number(int number)
        {
            _number = number;
        }

        public override string ToString()
        {
            return _number.ToString(_ifp);
        }

        // Для решения переопределим оператор +, чтобы Number
        // можно было бы складывать с числом, и не забудем про FormatProvider
        public static string operator +(Number number, string other)
        {
            if (int.TryParse(other, _ifp, out int otherInt))
            {
                return (number._number + otherInt).ToString();
            }

            throw new ArgumentException();
        }
    }

    static void Main(string[] args)
    {
        int someValue1 = 10;
        int someValue2 = 5;

        string result = new Number(someValue1) + someValue2.ToString(_ifp);
        Console.WriteLine(result);
        Console.ReadKey();
    }
}
