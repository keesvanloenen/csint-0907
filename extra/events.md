# Events Oefening

## 1. class Persoon

Maak een class Persoon met een event dat geraised wordt als de leeftijd verandert.  

Gebruik zoveel mogelijk het \[Standard .NET event pattern](https://learn.microsoft.com/en-us/dotnet/csharp/event-pattern).

1. Maak een class **Persoon** (in een nieuwe class library) met daarin:

    - Properties:
      - `Naam` (get+set)
      - `Leeftijd` (get+set)
    - Methods:
      - `Verjaar()`
    - Events:
      - `LeeftijdChanged`

1. In de EventHandling methode moet de volgende data beschikbaar zijn:

    - naam
    - oude leeftijd
    - nieuwe leeftijd

1. Test dat het event afgaat als de `Leeftijd` property gewijzigd wordt.

1. Test dat de juiste data beschikbaar komt.  Bijvoorbeeld:  
  naam=Kees, oude leeftijd=50, nieuwe leeftijd=25

1. Test dat het event afgaat als de `Verjaar()` methode wordt aangeroepen.

1. Test dat de juiste data beschikbaar komt.  
Bijvoorbeeld:  
  naam=Kees, oude leeftijd=57, nieuwe leeftijd=58

    _"Gefeliciteerd, Kees, je bent nu al 58, ik weet het nog goed dat je 57 was."_

## Zorg voor nette code

... maar misschien had je dit gelijk al goed gedaan:

1. Test dat de goede 'sender' wordt meegegeven aan het event.

2. Zorg dat de Naam niet in de EventArgs zit – De Naam heeft niet direct met het LeeftijdChanged event te maken, maar in de EventHandling methode willen we wel de naam beschikbaar hebben.

---

(if time permits)

## 2 class Werknemer
1. Maak een class Werknemer (die afleidt van Persoon) met daarin:

    - Properties:
      - Salaris

1. Zorg dat net **voordat** het leeftijdchanged event afgaat, ook het salaris wordt aangepast (met 1% per jaar verschil)

## Zorg voor nette code

1. Gebruik de protected virtual OnLeeftijdChanged(...) om het salaris aan te passen als de leeftijd verandert.

1. Gegeven een Salaris van € 1000,-
;  
   Als Leeftijd +=3  
   Dan is het Salaris € 1030,30

1. Zorg dat het Salaris alleen in de class Werknemer aan te passen is (private set)
