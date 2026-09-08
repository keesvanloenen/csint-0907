namespace Verzekeringen.App.Polissen;

public class AutoPolis : Polis, ISchadeVerzekering
{
    private readonly ITariefApi _tariefApi;      // 1️. Ik wil het onthouden

    public Bedrag? EigenRisico { get; set; } = new Bedrag(30m);

    public AutoPolis(ITariefApi tariefApi)       // 2. Injectie
    {
        _tariefApi = tariefApi;         
    }

    public override Bedrag BerekenPremie()
    {
        Bedrag dagTarief = _tariefApi.HaalDagTariefOp("auto");
        Bedrag basisPremie = new Bedrag(40m);
        return basisPremie.Add(dagTarief);
    }
    

}
