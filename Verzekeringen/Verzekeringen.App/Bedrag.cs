namespace Verzekeringen.App;
public readonly struct Bedrag
{
    public decimal Value { get; }
    public string Currency { get; }

    public Bedrag(decimal value, string currency = "EUR")
    {
        if (value < 0)
        {
            throw new ArgumentException("Bedrag kan niet negatief zijn");
        }

        Value = value;
        Currency = currency;
    }

    public static implicit operator Bedrag(decimal value)
    {
        return new Bedrag(value);
    }

    public static explicit operator decimal(Bedrag bedrag)
    {
        return bedrag.Value;
    }

    public static Bedrag operator +(Bedrag a, Bedrag b) =>
        a.Add(b);


    public Bedrag Add(Bedrag other)
    {
        if (Currency != other.Currency)
        {
            throw new InvalidOperationException("Currencies must match!");
        }

        return new Bedrag(Value + other.Value, Currency);
    }

    public override string ToString()
    {
        return $"{Currency} {Value}";
    }
}
   
