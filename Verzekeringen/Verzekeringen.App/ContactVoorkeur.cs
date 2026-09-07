namespace Verzekeringen.App;

[Flags]
public enum ContactVoorkeur
{
    Geen = 1 << 0,
    Email = 1 << 1, 
    Telefoon = 1 << 2,
    Post =  1 << 3,
    Sms = 8,
    WhatsApp = 16,
}
