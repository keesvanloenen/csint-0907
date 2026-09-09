namespace VerjaardagsOefening.Library;

public class VerjaarArgs : EventArgs
{
    public int OudeLeeftijd { get; }
    public int NieuweLeeftijd { get; }

    public VerjaarArgs(int oudeLeeftijd, int nieuweLeeftijd)
    {
        OudeLeeftijd = oudeLeeftijd;
        NieuweLeeftijd = nieuweLeeftijd;
    }
}
