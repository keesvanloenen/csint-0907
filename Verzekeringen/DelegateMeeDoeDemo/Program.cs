namespace DelegateMeeDoeDemo;

//                     vvvvvvvvvvvvv nieuw type!
//public delegate double MathsFunction(double arg);
//              ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ zo moet de functie eruit zien


internal class Program
{
    static void Plot(Func<double, double> f, double xStart, double xEnd, double step)
    {
        for (double x = xStart; x < xEnd; x += step)
        {
            double y = f(x);
            Console.WriteLine($"{x:N2}, {y:N2}");
        }
    }

    static void Main(string[] args)
    {

        Func<double, double> mijnFunctie = Utils.Dubbelaar;
        Plot(mijnFunctie, 0.0, Math.PI / 2, 0.01);
        // Plot(Utils.Dubbelaar, 0.0, Math.PI / 2, 0.01);
        // Plot(delegate(double x) { return x * 3; }, 0.0, Math.PI / 2, 0.01);
        Plot(x => x * 3, 0.0, Math.PI / 2, 0.01);
        

        // Func<> is een ingebouwde generieke delegate van Microsoft:
        // laatste type tussen de vishaken is het type van de return waarde
        // de evt. type(s) daarvoor zijn de input waardes
        // EEN FUNC MOET ALTIJD IETS RETOURNEREN

        // Action<> idem dito, MAAR RETOURNEERT NIETS
    }
}

public static class Utils 
{
    public static double Dubbelaar(double x)
    {
        return x * 2;
    }
}
