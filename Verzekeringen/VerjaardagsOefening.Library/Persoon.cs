namespace VerjaardagsOefening.Library;

public class Persoon
{
    public string Naam { get; }
    public short Leeftijd 
    { 
        get; 

        set
        {
            var oud = field;
            var nieuw = value;
            field = value;      // field = nieuwe syntax (scheelt uitschrijven van backing field)

            VerjaarArgs args = new (oud, nieuw);
            OnLeeftijdChanged(args);
        }
    }

    public event EventHandler<VerjaarArgs>? LeeftijdChanged;

    public Persoon(string naam, short leeftijd)
    {
        Naam = naam;
        Leeftijd = leeftijd;
    }

    public void Verjaar() => Leeftijd += 1;
    
    protected virtual void OnLeeftijdChanged(VerjaarArgs args)
    {
        LeeftijdChanged?.Invoke(this, args);
    }
}
