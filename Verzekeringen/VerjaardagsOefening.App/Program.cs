using VerjaardagsOefening.Library;

namespace VerjaardagsOefening.App;

internal class Program
{
    static void Main(string[] args)
    {
        var verjaardagsDienst = new VerjaardagsDienst();

        var p = new Persoon("Esmeralda", 26);

        p.LeeftijdChanged += verjaardagsDienst.OnLeeftijdChanged!;

        p.Verjaar();
        p.Leeftijd = 18;

        // Oefening 2:

        var w = new Werknemer("Karin", 25, 1000);

        w.LeeftijdChanged += verjaardagsDienst.OnLeeftijdChanged!;

        Console.WriteLine($"Salaris vóór verjaardag: {w.Salaris}");
        w.Verjaar();
        Console.WriteLine($"Salaris na verjaardag: {w.Salaris}");

        w.Leeftijd = 22;
        Console.WriteLine($"Salaris na leeftijdswijziging: {w.Salaris}");
    }
}
