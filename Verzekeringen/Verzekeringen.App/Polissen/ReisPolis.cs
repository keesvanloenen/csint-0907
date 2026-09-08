namespace Verzekeringen.App.Polissen;

public class ReisPolis : Polis, ISchadeVerzekering
{
    public Bedrag? EigenRisico { get; set; } = new Bedrag(20m);
}
