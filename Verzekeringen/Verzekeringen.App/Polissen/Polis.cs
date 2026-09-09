namespace Verzekeringen.App.Polissen;

//public delegate void PolisHandler(object sender, ClaimArgs args);

public abstract class Polis
{
    public string? Code { get; init; }
    public Klant? Klant { get; init; }
    public Bedrag? Premie { get; init; }

    public Bedrag Uitgekeerd { get; private set; } = 0m;
    //public event PolisHandler? ClaimIngediend;
    //     👆          👆            👆
    //    weldra      type         naam vh event (voltooid deelwoord)

    public event EventHandler<ClaimArgs>? ClaimIngediend;

    public void VerwerkClaim(Bedrag bedrag, string omschrijving)
    {
        Uitgekeerd += bedrag;

        if (bedrag.Value > 1000)
        {
            var args = new ClaimArgs("Bedrag boven de 1000", bedrag);
            OnClaimIngediend(args);
        }
    }

    protected virtual void OnClaimIngediend(ClaimArgs args)
    {
        ClaimIngediend?.Invoke(this, args);

        //if (ClaimIngediend is not null)
        //{
        //    ClaimIngediend(this, "Bedrag boven de 1000");
        //}
    }

    public void Deconstruct(out string? code, out string? klantNaam, out Bedrag? premie)
    {
        code = Code;
        klantNaam = Klant?.Naam;
        premie = Premie;
    }

    public virtual Bedrag BerekenPremie() => new Bedrag(50m);



}
