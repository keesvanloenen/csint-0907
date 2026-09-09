namespace DelegateOefening;

//public delegate string MyFormatter(int value);

class Printer
{
    public void Print(int number, Func<int, string> formatter)
    {
        Console.WriteLine(formatter(number));
    }
}

static class Layout
{
    public static string SuperDuperFormat(int number)
    {
        return $"The number is [{number}]";
    }

    public static string FunkyFormat(int number)
    {
        return $"Funky number @ {number} @ ";
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        var p = new Printer();
        
        p.Print(54, Layout.SuperDuperFormat);
        p.Print(54, Layout.FunkyFormat);
    }
}
