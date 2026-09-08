namespace Verzekeringen.App.Polissen;

public interface ITariefApi
{
    Bedrag HaalDagTariefOp(string polisSoort);      // eigenlijk enum
}
