//  oppgave 1A : Et program som leser inn en temperaturvariabel, og basert 
//              på grenser dere definerer selv, gir tilbakemelding i terminalen 
//              om temperaturen.

// Hvordan Løse : 1) Velkomstmelding introduksjon 
//                2) Ber om data 
//                3) Sjekker data og gir en komentar



Console.WriteLine("Velkommen til tempratur analyse. ");
Console.WriteLine ("Hvor høy er tempraturen der hvor du er?");
double svar=double.Parse(Console.ReadLine());



if (svar>=30){Console.WriteLine(" Dette er en norsk Tropedag");}
else if (svar>=1 && svar<30) {Console.WriteLine(" Det er varmegrader i dag");}
// må bruke assign == fordi null blir ett problem
else if (svar==0){Console.WriteLine("Det er null grader og ting fryser");}
else if (svar<0){Console.WriteLine("Det er minusgrader");}
Console.WriteLine("Trykk en tast for å Begynne neste del");
Console.ReadLine();
// Oppgave 1B Et program som sjekker hvor mange produkter en butikk har
//            av en vare, og skriver ut hvor 
//            mye rabatt varen skal få basert på beholdningen.
                
// Hvordan løse oppgaven : 1) Velkomstmelding introduksjon 
//                         2) Lagrer data som viser varebeholdning
//                         3) Sjekker varebeholdning og gir en rabatt basert på antall.

//  NB Tenkte var greiest  å bruke  list på denne delen har jo vist kunnskaper om if på del 1.
Console.WriteLine("Velkommen til rabatt sjekk");
List<int > lagerBiler = [1,5,10,15];
List<int > rabattBiler = [0,5,10,20];



for (int antall=0;antall<lagerBiler.Count;antall++)
{
    Console.WriteLine($" Antall Kjøp av Toyota 2026 modell  {lagerBiler[antall]} gir {rabattBiler[antall] } % rabatt");
}

Console.WriteLine("Trykk en tast for å Begynne neste del");
Console.ReadLine();

// Oppgave 1C Et program som sjekker lengden på en tekststreng 
//            (f.eks. med .Length på en string-variabel) 
//            og vurderer om det kan være et sterkt eller svakt passord.

// Hvordan løse oppgaven : 1) Velkomstmelding introduksjon 
//                         2) Lagrer data som viser ulike textstrenger/passord i en liste,
//                            for å simulerer at vi sjekker passord i en database
//                         3) Sjekk innholde basert på lengde
//                         4) Gir tilbakemeldingen om passordet er sterkt eller svakt



Console.WriteLine("Velkommen! Her sjekker vi om lagrede passord er sterke eller svake.");
List<string> passord = new List<string> { "en", "hest", "passord","Hjelpmegålageetpassord" };
                
for (int antall=0;antall<passord.Count;antall++)
{
    if(passord[antall].Length<=2)
    { Console.WriteLine($"Dette ordet \"{passord[antall]}\" som passord er veldig svakt.");}
    
    else if(passord[antall].Length>=3 && passord[antall].Length<=8)
    { Console.WriteLine($"Dette ordet \"{passord[antall]}\" som Passord er for svakt.");}

    else if(passord[antall].Length>=9 && passord[antall].Length<=16)
    {Console.WriteLine($"Dette ordet \"{passord[antall]}\" som passord har normal styrke.");}
    
    else if(passord[antall].Length>=17)
    {Console.WriteLine($"Dette ordet \"{passord[antall]}\" som passord er meget sterkt.");}

}