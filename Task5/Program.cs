using System.Text;
class Program
{
    static void Main(string[] args)
    {
        TransformToElephant();
        Console.WriteLine("Муха");
        Console.WriteLine("Дальше все работает");
    }

    static void TransformToElephant()
    {
        // Меняем TextWriter, отвечающий за логику вывода текста в консоль.
        // Для этого передадим наш класс, который наследуется от TextWriter
        Console.SetOut(new ElephantTextWriter());
    }
}


public class ElephantTextWriter : TextWriter
{
    public override Encoding Encoding { get; }

    private readonly StringBuilder buffer;   // В буфер записываем значения, пока не встретилась муха.
                                             // В нашем случае Муха встретится сразу

    private readonly TextWriter old = Console.Out;   // Старый TextWriter (стандартный).
                                                     // Когда встретили Муху - меняем на него.

    public ElephantTextWriter()
    {
        buffer = new StringBuilder();
    }

    public override void Write(string? value)
    {
        buffer.Append(value);
        if (buffer.ToString().Trim('\n') == "Муха")   // Если записанное слово - Муха - устанавливаем стандартный TextWriter
                                                      // И пишем Слон вместо Мухи. Дальше программа работает как раньше
        {
            Console.SetOut(old);
            Console.WriteLine("Слон");
        }
    }
}
