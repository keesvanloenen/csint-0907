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
    }
}
