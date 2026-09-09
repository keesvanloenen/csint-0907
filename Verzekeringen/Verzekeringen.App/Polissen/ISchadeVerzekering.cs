namespace Verzekeringen.App.Polissen;

public interface ISchadeVerzekering
{
    Bedrag? EigenRisico { get; }

    void PrintSchades()
    {
        Console.WriteLine("Schade overzicht wordt geprint");
    }
}
