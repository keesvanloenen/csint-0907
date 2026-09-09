using Verzekeringen.App.Polissen;

namespace Verzekeringen.App;

public class SchadeMedewerker
{
    // Dit is de subscriber
    public string? Naam { get; init; }

    public void OnClaimIngediend(object sender, ClaimArgs args)
    {
        if (sender is Polis p)
        {
            Console.WriteLine($"Polis {p.Code} voor klant {p?.Klant?.Naam} meldt:");
            Console.WriteLine($"{args.Omschrijving} ({args.Bedrag})");
        }


    }
}
