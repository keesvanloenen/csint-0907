using Verzekeringen.App.Polissen;

namespace Verzekeringen.App;

public record Krant(string Naam, short Jaar = 2026);

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
        //DemoCollectionInitializer();
        //DemoInterfaces();
        //DemoVariadic();
        //DemoVariadicOefeningetje();
        //DemoPatternPatching();
        //DemoTypeConversions();
        //DemoRealConversions();
        //DemoUserDefinedConversions();
        //DemoUserDefinedOperators();
        DemoEvents();
    }

    private static void DemoEvents()
    {
        var schadeMedewerker = new SchadeMedewerker() { Naam = "Toon" };

        // Dit is de publisher
        var polis = new AutoPolis(new TariefApi())
        {
            Code = "ABC123",
            Premie = new Bedrag(20m),
            Klant = new Klant("Abdulrahman")
        };

        polis.ClaimIngediend += schadeMedewerker.OnClaimIngediend!;
        
        // Claims verwerken
        polis.VerwerkClaim(3000m, "Autoreparatie na aanrijding");
        Console.WriteLine($"Totaal uitgekeerd: {polis.Uitgekeerd}");
        Console.WriteLine($"IsRisicovol = {polis.IsRisicovol}");

        polis.VerwerkClaim(1001m, "Glasreparatie");
        Console.WriteLine($"Totaal uitgekeerd: {polis.Uitgekeerd}");
        Console.WriteLine($"IsRisicovol = {polis.IsRisicovol}");

        polis.VerwerkClaim(1001m, "Glasreparatie");
        Console.WriteLine($"Totaal uitgekeerd: {polis.Uitgekeerd}");
        Console.WriteLine($"IsRisicovol = {polis.IsRisicovol}");

    }

    private static void DemoUserDefinedOperators()
    {
        var bedrag1 = new Bedrag(150.33m);
        var bedrag2 = new Bedrag(82.82m);
        //Console.WriteLine(bedrag1.Add(bedrag2));
        Console.WriteLine(bedrag1 + bedrag2);
        bedrag1 += bedrag2;

        Console.WriteLine(bedrag1);

        Console.WriteLine(ulong.MinValue);
        Console.WriteLine(ulong.MaxValue);
        Console.WriteLine(int.MaxValue);
    }

    private static void DemoRealConversions()
    {
        int intValue = 42;
        double doubleValue = intValue;      // Implicit conversion (no data loss)

        double pi = 3.14d;
        int rounded = (int)pi;              // Explicit conversion (data loss)

        Console.WriteLine(pi);
        Console.WriteLine(rounded);
    }

    private static void DemoTypeConversions()
    {
        int number = 42;
        object obj = number;        // upcasting (en boxing: value type -> object)
        Console.WriteLine(obj);
        int backToInt = (int)obj;   // downcasting (en unboxing: object -> value type)
        Console.WriteLine(backToInt);
    }

    private static void DemoUserDefinedConversions()
    {
        Bedrag bedrag = 6.14m;                          // impliciet
        decimal decimaalGetal = (decimal)bedrag;        // expliciet 6.14 EUR -> 6.14
    }

    private static void DemoPatternPatching()
    {
        // Type Pattern (is operator)
        object obj = "Hello";

        //if (obj.GetType() == typeof (string))
        if (obj is string)
        {
            Console.WriteLine(((string)obj).Length);
        }


        // ----------------------------------------------

        // Declaration Pattern
        if (obj is string deGeconverteerdeWaarde)
        {
            Console.WriteLine(deGeconverteerdeWaarde.Length);
        }

        // Constant Pattern

        int aantal = 2;

        if (aantal is 2)
        {
            Console.WriteLine(aantal);
        }

        string s1 = "Rik";
        const string s2 = "Rik";
        Console.WriteLine(s1 is s2);

        // Null Pattern

        string? text = null;

        if (text is null)       // krachtiger dan text == null
        {
            Console.WriteLine("Is null");
        }

        // Relational Pattern
        int age = 20;
        
        //if (age > 18 && age < 21)
        if (age is > 18 and < 21)
        {
            Console.WriteLine("Adolescent");
        }

        // Property Pattern
        List<Krant> kranten = [new Krant("Duckstadkrant"), new Krant("Bobo")];

        //if (kranten[0].Naam is "Duckstadkrant" && kranten[0].Jaar is 2026)        // oud

        if (kranten[0] is { Naam: _, Jaar: >=2026 })
        {
            Console.WriteLine("Donald Duck");
        }

        if (kranten[1] is { Naam.Length: 4 })
        {
            Console.WriteLine("Bobo");
        }

        // string melding;

        // Switch STATEMENT
        //switch(age)
        //{
        //    case 0:
        //        melding = "Baby";
        //        break;
        //    case < 18:
        //        melding = "Kind";
        //        break;
        //    case < 21:
        //        melding = "Adolescent";
        //        break;
        //    case < 68:
        //        melding = "Volwassen";
        //        break;
        //    default:
        //        melding = "Bejaard";
        //        break;
        //}


        // Switch EXPRESSION
        string melding = age switch
        {
            0 => "Baby",
            < 18 => "Kind",
            < 21 => "Adolescent",
            < 68 => "Volwassen",
            _ => "Bejaard"
        };

        Console.WriteLine(melding);

    }

    private static void DemoVariadicOefeningetje()
    {
        var k1 = new Krant("Telegraaf");
        var k2 = new Krant("NRC");
        var k3 = new Krant("Volkskrant");

        Console.WriteLine(TotaleLengteVanKrantNamen(k1, k2, k3));
        Console.WriteLine(KrantNamenInHtml(k1, k2, k3));
    }

    private static int TotaleLengteVanKrantNamen(params Krant[] kranten) =>
        kranten.Sum(krant => krant.Naam.Length);

    private static string KrantNamenInHtml(params Krant[] kranten) =>
        kranten.Aggregate("", (acc, krant) => acc + $"<strong>{krant.Naam}</strong>");

    private static void DemoVariadic()
    {

        PrintCharacters('a', 'b', 'c');
        PrintCharacters([ 'e', 'f' ]);

        char[] arr = ['a', 'b', 'c'];
        ReadOnlySpan<char> span = arr.AsSpan(0, 2);
        PrintCharacters(span);
    }

    private static void PrintCharacters(params ReadOnlySpan<char> characters)
    {
        //characters.Add('-');

        foreach (char c in characters)
        {
            Console.Write(c);
        }
    }

    private static void DemoInterfaces()
    {
        var klant = new Klant("Abdulrahman");
        var bedrag = new Bedrag(20m);
        var tariefApi = new TariefApi();

        var polis = new AutoPolis(tariefApi) { Code = "ABC123", Premie = bedrag, Klant = klant, };
        Console.WriteLine(polis.BerekenPremie());

        VerwerkHetEigenRisico(polis);

        var reisPolis = new ReisPolis() { Code = "DEF456", Premie = bedrag, Klant = klant, };

        // bij toevoeging van een default implementatie in een interface heeft een client 3 opties:
        // 1. ik doe niets, alles blijft werken
        // 2. ik voeg zelf een implementatie toe
        // 3. ik roep de default implementatie van de interface aan:
        ((ISchadeVerzekering)reisPolis).PrintSchades();
    }

    private static void VerwerkHetEigenRisico(ISchadeVerzekering polis)
    {
        Console.WriteLine($"We verwerken nu het eigen risico van: {polis.EigenRisico}");
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
        //var schadeCollection = new SchadeCollection();

        //var schade1 = new Schade("A", 1m, DateTime.Now);
        //var schade2 = new Schade("B", 2m, DateTime.Now);
        //var schade3 = new Schade("C", 3m, DateTime.Now);

        SchadeCollection schadeCollection =
        [
            new Schade("A", 1m, DateTime.Now),
            new Schade("B", 1m, DateTime.Now),
            new Schade("C", 1m, DateTime.Now),
        ];

        //schadeCollection.Add(schade1);
        //schadeCollection.Add(schade2);
        //schadeCollection.Add(schade3);

        //schadeCollection[5] = new Schade("D", 3m, DateTime.Now);

        for (int i = 0; i < schadeCollection.Count; i++)
        {
            Console.WriteLine(schadeCollection[i]);
        }

        foreach(var schade in schadeCollection)
        {
            Console.WriteLine(schade);
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
        var polis = new AutoPolis(new TariefApi())
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
