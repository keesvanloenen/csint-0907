namespace Verzekeringen.App;

public class Klant
{
    public int Id { get; set; }                 // value type, standaard non-nullable
    public string? Naam { get; set; }           // reference type, tegenwoordig ook standaard non-nullable
    // public string Naam { get; set; } = null!;   // ik beloof dat ik nooit null wordt (bijv. constructor set Naam niet)

    public ContactVoorkeur Voorkeur { get; set; }

    public Klant(string naam)
    {
        Naam = naam;
    }
}

