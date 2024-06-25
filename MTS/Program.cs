//using System;
//using System.Diagnostics;
//class Program
//{
//    static void Main(string[] args)
//    {
//        try
//        {
//            FailProcess();
//        }
//        catch { }

//        Console.WriteLine("Failed to fail process!");
//        Console.ReadKey();
//    }

//    static void FailProcess()
//    {
//        //Process.GetCurrentProcess().Kill();

//        //Environment.Exit(-1);

//    }
//}

//using System;
//using System.Globalization;

//class Program
//{
//    static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

//    class Number
//    {
//        readonly int _number;

//        public Number(int number)
//        {
//            _number = number;
//        }

//        public override string ToString()
//        {
//            return _number.ToString(_ifp);
//        }

//        public static string operator +(Number number, string other)
//        {
//            if (Int32.TryParse(other, out int otherInt))
//            {
//                return (number._number + otherInt).ToString();
//            }

//            throw new ArgumentException();
//        }
//    }

//    static void Main(string[] args)
//    {
//        int someValue1 = 10;
//        int someValue2 = 5;

//        string result = new Number(someValue1) + someValue2.ToString(_ifp);
//        Console.WriteLine(result);
//        Console.ReadKey();
//    }
//}

//using System;

//public static class EnumerateExtentions
//{
//    /// <summary>
//    /// <para> Отсчитать несколько элементов с конца </para>
//    /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
//    /// </summary> 
//    /// <typeparam name="T"></typeparam>
//    /// <param name="enumerable"></param>
//    /// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
//    /// <returns></returns>
//    public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
//    {
//        List<T> values = enumerable.ToList();

//        if (tailLength > values.Count || tailLength < 0)
//            throw new ArgumentException();

//        for (int i = 0; i < values.Count; ++i)
//        {
//            if (i < values.Count - tailLength)
//            {
//                yield return (values[i], null);
//            }
//            else
//            {
//                yield return (values[i], values.Count - i - 1);
//            }
//        }
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        var a = new[] { 1, 2, 3, 4 }.EnumerateFromTail(2).ToList();
//    }
//}


public class Algo
{
    public IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
    {
        if (sortFactor + 1 < 2000)
        {
            int shift = 0;
            int[] backets = new int[sortFactor + 1];

            foreach (int val in inputStream)
            {
                if (val - shift <= sortFactor)
                {
                    backets[val - shift]++;
                }
                else
                {
                    for (int i = 0; i < backets.Length; ++i)
                    {
                        for (int j = 0; j < backets[i]; ++j)
                        {
                            yield return i + shift;
                        }

                        backets[i] = 0;
                    }

                    shift = val - sortFactor;

                    backets[val - shift]++;
                }

            }

            for (int i = 0; i < backets.Length; ++i)
            {
                for (int j = 0; j < backets[i]; ++j)
                {
                    yield return i + shift;
                }
            }
        }
        else
        {
            int[] backets = new int[2001];
            int lastMin = 0;
            int backetSize = backets.Length;

            foreach (int val in inputStream)
            {
                backets[val]++;

                if (lastMin < val - sortFactor)
                {
                    for (int i = lastMin; i < val - sortFactor; ++i)
                    {
                        for (int j = 0; j < backets[i]; ++j)
                        {
                            yield return i;
                        }

                    }

                    lastMin = val - sortFactor;
                }

            }

            for (int i = 0; i < backetSize; ++i)
            {
                for (int j = 0; j < backets[i]; ++j)
                {
                    yield return i;
                }
            }
        }

    }
}

class Program
{
    /// <summary>
    /// Возвращает отсортированный по возрастанию поток чисел
    /// </summary>
    /// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
    /// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
    /// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
    /// <returns>Отсортированный по возрастанию поток чисел.</returns>


    public static void Main(string[] args)
    {
        Algo alg = new Algo();
        var a = alg.Sort(new int[] { 1, 2, 45, 42, 43, 56, 49 }, 7, 9);
        var aa = a.ToList();
    }

}


//using System;

//class Program
//{
//    static void Main(string[] args)
//    {
//        TransformToElephant();
//        Console.WriteLine("Муха");
//        //Console.WriteLine("WORK!");
//    }

//    static void TransformToElephant()
//    {
//        var originalOutput = Console.Out;
//        var sw = new StringWriter();
//        Console.SetOut(sw);

//        // Custom logic that is supposed to run before the replacement
//        sw.GetStringBuilder().Clear();
//        Console.SetOut(originalOutput);
//        Console.WriteLine("Слон");
//    }
//}