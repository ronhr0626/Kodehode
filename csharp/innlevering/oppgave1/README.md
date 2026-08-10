# Kodehode – Oppgave 1

Et konsollprogram i C# som består av tre deler (1A, 1B og 1C), som viser bruk av
`if`-betingelser, lister og strengbehandling.

## Oppgave 1A – Temperaturanalyse

Leser inn en temperatur og gir en kommentar tilbake basert på selvvalgte grenser.

| Temperatur    | Melding                          |
|---------------|----------------------------------|
| 30 og over    | Norsk tropedag                   |
| 1–29          | Varmegrader                      |
| 0             | Null grader, ting fryser         |
| Under 0       | Minusgrader                      |

## Oppgave 1B – Rabatt basert på lagerbeholdning

Sjekker hvor mange produkter butikken har av en vare, og skriver ut hvilken
rabatt varen skal få basert på beholdningen. Bruker to lister
(`lagerBiler` og `rabattBiler`) koblet sammen i en løkke.

| Antall på lager | Rabatt |
|-----------------|--------|
| 1               | 0 %    |
| 5               | 5 %    |
| 10              | 10 %   |
| 15              | 20 %   |

## Oppgave 1C – Passordstyrke

Sjekker lengden på tekststrenger (`.Length`) i en liste og vurderer om hvert
passord er sterkt eller svakt. Simulerer at vi sjekker passord i en database.

| Lengde     | Vurdering        |
|------------|------------------|
| 2 og under | Veldig svakt     |
| 3–8        | For svakt        |
| 9–16       | Normal styrke    |
| 17 og over | Meget sterkt     |

## Slik kjører du

​```
dotnet run
​```

Programmet kjører delene etter hverandre. Trykk en tast mellom hver del for å
gå videre.
