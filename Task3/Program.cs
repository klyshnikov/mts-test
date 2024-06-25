public static class EnumerateExtentions
{
    /// <summary>
    /// <para> Отсчитать несколько элементов с конца </para>
    /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
    /// </summary> 
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
    /// <returns></returns>
    public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
    {
        // Т.к нам передается IEnumerable, мы можем читать элементы только подяд.
        // Т.к мы не знаем размер коллекции, не можем понять заранее, какой tail ставить элементу.
        // Поэтому мы должны миниум 2 раза пройтись по коллекции, т.к каждый элемент надо сначала посчитать,
        // а затем вернуть.
        // Решение проходит ровно 2 раза - ToList() и циклом.

        List<T> values = enumerable.ToList();

        if (tailLength > values.Count || tailLength < 0)
            throw new ArgumentException();

        for (int i = 0; i < values.Count; ++i)
        {
            if (i < values.Count - tailLength)
            {
                yield return (values[i], null);
            }
            else
            {
                yield return (values[i], values.Count - i - 1);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var result = new[] { 1, 2, 3, 4 }.EnumerateFromTail(2).ToList();
        result.ForEach(el => Console.WriteLine(el));
    }
}

