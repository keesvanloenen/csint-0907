namespace Verzekeringen.App.Polissen;

public class Polis
{
    public string? Code { get; init; }
    public Klant? Klant { get; init; }
    public Bedrag? Premie { get; init; }

    public void Deconstruct(out string? code, out string? klantNaam, out Bedrag? premie)
    {
        code = Code;
        klantNaam = Klant?.Naam;
        premie = Premie;
    }

    public virtual Bedrag BerekenPremie() => new Bedrag(50m);
}
