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

