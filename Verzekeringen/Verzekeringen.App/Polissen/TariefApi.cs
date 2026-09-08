namespace Verzekeringen.App.Polissen;

public class TariefApi : ITariefApi
{
    public Bedrag HaalDagTariefOp(string polisSoort)
    {
        Console.WriteLine($"Dagtarief opgehaald bij externe API voor {polisSoort}");
        return polisSoort == "auto" ? new Bedrag(2.50m) : new Bedrag(1.00m);
    }
}
