namespace Verzekeringen.App;

public record Schade(string Omschrijving, decimal Bedrag, DateTime Datum) : IComparable<Schade>
{
    public int CompareTo(Schade? other)
    {
        if (other is null) return 0;
        if (Bedrag < other.Bedrag) return -1;
        if (Bedrag > other.Bedrag) return 1;
        return 0;
    }
}
