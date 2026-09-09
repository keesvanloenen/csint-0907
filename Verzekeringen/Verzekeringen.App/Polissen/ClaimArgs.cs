namespace Verzekeringen.App.Polissen;

public class ClaimArgs : EventArgs
{
    public string Omschrijving { get; }
    public Bedrag Bedrag { get; }

    public ClaimArgs(string omschrijving, Bedrag bedrag)
    {
        Omschrijving = omschrijving;
        Bedrag = bedrag;
    }
}
