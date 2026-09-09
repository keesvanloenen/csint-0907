using VerjaardagsOefening.Library;

namespace VerjaardagsOefening.App;

public class Werknemer : Persoon
{
    public decimal Salaris { get; private set; }
    
    public Werknemer(string naam, short leeftijd, decimal salaris) : base(naam, leeftijd)
    {
        Salaris = salaris;
    }

    protected override void OnLeeftijdChanged(VerjaarArgs args)
    {
        if (args.OudeLeeftijd > 0)
        {
            var verschil = args.NieuweLeeftijd - args.OudeLeeftijd;
            if (verschil is not 0)
            {
                var leeftijdsFactor = verschil / 100m; // e.g. +1 year => 0.01 => +1%
                Salaris *= 1 + leeftijdsFactor;
            }
        }

        base.OnLeeftijdChanged(args);
    }
}
