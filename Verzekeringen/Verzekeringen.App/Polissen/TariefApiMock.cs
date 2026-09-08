using System;
namespace Verzekeringen.App.Polissen;

public class TariefApiMock : ITariefApi
{
    public Bedrag HaalDagTariefOp(string polisSoort)
    {
        Console.WriteLine("Ik ben een mock");
        return new Bedrag(0m);
    }
}
