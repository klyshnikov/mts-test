using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            FailProcess();
        }
        catch { }

        Console.WriteLine("Failed to fail process!");
        Console.ReadKey();
    }

    static void FailProcess()
    {
        // 1 способ - получить текущий процесс и убить его
        //Process.GetCurrentProcess().Kill();

        // 2 способ. По сути тоже самое, но мы убиваем процесс по его PID - как это было бы на языке C
        //Process.GetProcessById(Process.GetCurrentProcess().Id).Kill();

        // 3 способ - так же завершает текущий процесс
        //Environment.FailFast("Сломал меня полностью");

        // 4 способ - аналогично из класса Enviroment
        //Environment.Exit(-1);

        // 5 способ. Отличае лишь в том, что мы получаем текущий pid методом класса Enviroment
        //var pid = Environment.ProcessId;
        //Process.GetProcessById(pid).Kill();

        // 6 способ. Сделать рекурсию, чтобы вызвался StackOverflowException, который не ловится try / catch
        //int a = 5;
        //FailProcess();

    }


}