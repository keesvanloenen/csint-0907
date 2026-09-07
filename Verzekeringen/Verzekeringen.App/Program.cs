using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Cryptography;

namespace Verzekeringen.App;

internal class Program
{
    static void Main(string[] args)
    {
        //DemoNullableTypes();
        //DemoKlant();
        //DemoStruct();
        //DemoTuples();
        //DemoTryParseVoorDaan();
        //DemoDeconstruct();
        //DemoRecord();
        //DemoSchadeCollection();
        DemoCollectionInitializer();
    }

    private static void DemoCollectionInitializer()
    {
        // List<char> characters = new List<char>() { 'b', 'c', 'd' };
        //                                         ^^^^^^^^^^^^^ collection initializer

        // List<char> characters = new() { 'b', 'c', 'd' };
        List<char> characters = ['b', 'c', 'd']; // collection expression
        characters = ['a', .. characters, 'e'];

        foreach (var character in characters)
        {
            Console.WriteLine(character);
        }
    }

    private static void DemoSchadeCollection()
    {
        var schadeCollection = new SchadeCollection();

        var schade1 = new Schade("A", 1m, DateTime.Now);
        var schade2 = new Schade("B", 2m, DateTime.Now);
        var schade3 = new Schade("C", 3m, DateTime.Now);

        schadeCollection.Add(schade1);
        schadeCollection.Add(schade2);
        schadeCollection.Add(schade3);

        //schadeCollection[5] = new Schade("D", 3m, DateTime.Now);

        for (int i = 0; i < schadeCollection.Count; i++)
        {
            Console.WriteLine(schadeCollection[i]);
        }

        var schade4 = schadeCollection["B"];
        Console.WriteLine(schade4);
    }

    private static void DemoRecord()
    {
        var nu = DateTime.Now;
        var schade1 = new Schade("Auto ongeluk", 1500m, nu);
        Console.WriteLine(schade1);             // gratis ToString()

        var (_, Bedrag, Datum) = schade1;       // gratis Deconstruct()
        Console.WriteLine($"Datum is dus: {Datum}.");

        var schade2 = new Schade("Auto ongeluk", 1500m, nu);

        Console.WriteLine(schade1 == schade2);  // gratis value-based equality
        Console.WriteLine(schade1.Equals(schade2));  // gratis value-based equality
        Console.WriteLine(schade1.GetHashCode() == schade2.GetHashCode());  // gratis value-based equality

        // gratis with 😀

        Schade schade3 = schade2 with
        {
            Datum = DateTime.Now.AddMonths(1),
        };
    
        Console.WriteLine(schade3);

    }

    private static void DemoDeconstruct()
    {
        var polis = new Polis()
        {
            Code = "ABC123",
            Premie = new Bedrag(20m),
            Klant = new Klant("Abdulrahman")
        };

        var (code, klant, premie) = polis;

        Console.WriteLine($"{code}\t{premie}... {klant}");
    }

    private static void DemoTryParseVoorDaan()
    {
        string input = "20";
        var result = int.TryParse(input, out int geconverteerdeWaarde);

        if (result)
        {
            Console.WriteLine(geconverteerdeWaarde);
        } else {
            Console.WriteLine("lukte niet");
        }
    }

    private static void DemoTuples()
    {
        //(string, decimal) premieInfo = ("WA Verzekering", 110m);
        //Console.WriteLine(premieInfo.Item1);

        (string Product, decimal Premie) premieInfo1 = ("WA Verzekering", 110m);
        (string Product, decimal Premie) premieInfo2 = ("WA Verzekering", 110m);
        Console.WriteLine($"Zijn de tuples hetzelfde: {premieInfo1 == premieInfo2}");

        var result = SchadeBerekening.BerekenUitkering(1500m, 600m);
        Console.WriteLine($"Uitkering {result.Uitkering} ({result.ToegepastEigenRisico})");

        //(var uitkering, var toegepastEigenRisico) = result;
        //var (uitkering, toegepastEigenRisico) = result;
        //var (_, toegepastEigenRisico) = result;
    }

    private static void DemoStruct()
    {
        var premie1 = new Bedrag(120.50m, "EUR");
        var premie2 = new Bedrag(100.50m, "EUR");
        //Bedrag bedrag2 = new Bedrag(120.50m, "EUR");
        //Bedrag bedrag3 = new (120.50m, "EUR");

        var total = premie1.Add(premie2);
        Console.WriteLine(total);

        //var premie3 = new Bedrag();
        //Console.WriteLine(premie3);
    }




    private static void DemoKlant()
    {
        Klant k1 = new Klant("An de Wit");
        //k1.Voorkeur = ContactVoorkeur.Sms | ContactVoorkeur.Telefoon;
        //k1.Voorkeur |= ContactVoorkeur.WhatsApp;

        k1.Voorkeur = ContactVoorkeur.Sms;


        Console.WriteLine($"Voorkeur: {k1.Voorkeur} - {(int)k1.Voorkeur}");

        //if (k1.Voorkeur == ContactVoorkeur.Sms)
        //if ((k1.Voorkeur & ContactVoorkeur.Sms) != 0)
        //if ((k1.Voorkeur & (ContactVoorkeur.Sms | ContactVoorkeur.Telefoon | ContactVoorkeur.WhatsApp)) != 0)
        if ((k1.Voorkeur.HasFlag(ContactVoorkeur.Sms) || k1.Voorkeur.HasFlag(ContactVoorkeur.Telefoon)))
        {
            Console.WriteLine("De klant heeft blijkbaar een telefoon");
        }
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
