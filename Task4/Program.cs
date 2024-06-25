using System;

class Program
{
    /// <summary>
    /// Возвращает отсортированный по возрастанию поток чисел
    /// </summary>
    /// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
    /// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
    /// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
    /// <returns>Отсортированный по возрастанию поток чисел.</returns>
    public static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
    {
        if (sortFactor + 1 < maxValue)
        {
            // Первый случай - когда sortFactor меньше, чем максимальное значение 
            // Используем сортировку подсчетом. Тут будет (sortFactor + 1) корзин.
            // Изначально они обозначают кол-во значений 0, 1, 2 ... sortFactor
            // Если значения из этой области - в соответсвующей ячейке делаем +1
            // Если нет - то значения меньше (x - sortFactor) встречаться не будут,
            // поэтому теперь корзины это значения (x - sortFactor) ... (x). Предыдущие значения возвращаем.
            // Сдвиг значений корзин контролирует shift. 

            // Итого время O(2n), память O(sortFactor)
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
            // Случай, когда sortFactor больше maxValue. Это бесполезный случай)
            // Т.к тогда sortFactor ничего не обозначает, значения в коллекции могут быть другими.
            // В этом случае делаем maxValue корзин и решаем в лоб - без сдвигов.

            // Время O(2n), Память O(maxValue)
            int[] backets = new int[maxValue];
            int lastMin = 0;

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

            for (int i = 0; i < maxValue; ++i)
            {
                for (int j = 0; j < backets[i]; ++j)
                {
                    yield return i;
                }
            }
        }

        // ИТОГО
        // Время O(2n), меньше быть не может, т.к каждый элемент нужно прочитать + вернуть
        // Память - O(min(sortFactor, maxValue))
        // Ее можно принять за константу, т.к sortFactor по хорошему должен быть меньше maxValue, то есть 2000
        // Так что решение весьма оптимальное
    }

    public static void Main(string[] args)
    {
        var result = Sort(new int[] { 1, 2, 45, 42, 43, 56, 49 }, 7, 9);
        foreach (var val in result)
        {
            Console.WriteLine(val);
        }
    }

}

