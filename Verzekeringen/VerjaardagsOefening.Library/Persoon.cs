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

/*

## 2 class Werknemer
1. Maak een class Werknemer (die afleidt van Persoon) met daarin:

- Properties:
  - Salaris

1. Zorg dat net **voordat** het leeftijdchanged event afgaat, ook het salaris wordt aangepast (met 1% per jaar verschil)

## Zorg voor nette code

1. Gebruik de protected virtual OnLeeftijdChanged(...) om het salaris aan te passen als de leeftijd verandert.

1. Gegeven een Salaris van € 1000,-
;  
Als Leeftijd +=3  
Dan is het Salaris € 1030,30

1. Zorg dat het Salaris alleen in de class Werknemer aan te passen is (private set)

*/