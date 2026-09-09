namespace VerjaardagsOefening.Library;

public class VerjaardagsDienst
{
    public void OnLeeftijdChanged(object sender, VerjaarArgs args)
    {
        if (sender is Persoon p)
        {
            Console.WriteLine($"Gefeliciteerd, {p.Naam}, je bent nu al {args.NieuweLeeftijd}, ik weet het nog goed dat je {args.OudeLeeftijd} was.");
        }
    }
}
