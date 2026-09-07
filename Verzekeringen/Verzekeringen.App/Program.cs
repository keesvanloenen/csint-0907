namespace Verzekeringen.App;

internal class Program
{
    static void Main(string[] args)
    {
        DemoNullableTypes();
    }

    private static void DemoNullableTypes()
    {
        decimal? premie = 20;
        //Nullable<decimal> premie = null;

        Console.WriteLine($"Premie is: {premie}");

        Console.WriteLine(premie.HasValue ? premie.Value : "geen premie");

        Klant klant1 = new Klant("An");
        Console.WriteLine(klant1.Naam?.Length);
    }
}
