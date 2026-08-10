using System;

class GiftSlotConsole
{
    static readonly int[] reelStrip = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9 };
    static readonly Random numbers = new Random();

    static int credits = 20;
    const int spinCost = 1;
    const double magnetChance = 0.08;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            VisGevinstTabell();

            Console.WriteLine($"\nCredits: {credits}");
            Console.Write("Trykk ENTER for å spinne (Q + ENTER for å slutte): ");
            string input = Console.ReadLine();
            if (input != null && input.Trim().ToUpper() == "Q") break;

            Spin();

            if (credits <= 0)
            {
                Console.WriteLine("\nTom for credits! Game over.");
                break;
            }

            Console.WriteLine("\nTrykk ENTER for neste spinn...");
            Console.ReadLine();
        }

        Console.WriteLine($"\nDu sluttet med {credits} credits.");
    }

    static void VisGevinstTabell()
    {
        Console.WriteLine("=== LUCKY GIFTS (konsollversjon) ===\n");
        Console.WriteLine("GEVINSTTABELL (tre like):");
        Console.WriteLine("  BAR      x3 = 100     SEVEN    x3 =  75     HESTESKO x3 =  50");
        Console.WriteLine("  PLOMME   x3 =  40     SITRON   x3 =  30     APPELSIN x3 =  20");
        Console.WriteLine("  KLOKKE   x3 =  15     CHERRY   x3 =  10");
        Console.WriteLine("  2 x CHERRY  =   5     1 x CHERRY  =   3");
    }

    static void Spin()
    {
        credits -= spinCost;

        int p1 = DrawSymbol();
        int p2 = DrawMagnet(p1);
        int p3 = DrawMagnet(p1);

        int win = CalculateWin(p1, p2, p3);

        Console.WriteLine($"\n  [ {SymbolNavn(p1)} | {SymbolNavn(p2)} | {SymbolNavn(p3)} ]");

        if (win > 0)
        {
            credits += win;
            Console.WriteLine($"  VANT: {win}!");
            Console.Beep();
        }
        else
        {
            Console.WriteLine("  Ingen gevinst.");
        }
    }

    static int DrawMagnet(int first)
    {
        if (first != 9 && numbers.NextDouble() < magnetChance)
            return first;
        return DrawSymbol();
    }

    static int DrawSymbol()
    {
        int i = numbers.Next(0, reelStrip.Length);
        return reelStrip[i];
    }

    static string SymbolNavn(int n)
    {
        switch (n)
        {
            case 1: return "CHERRY";
            case 2: return "KLOKKE";
            case 3: return "APPELSIN";
            case 4: return "SITRON";
            case 5: return "PLOMME";
            case 6: return "HESTESKO";
            case 7: return "SEVEN";
            case 8: return "BAR";
            case 9: return "BANDIT";
            default: return "?";
        }
    }

    static int CalculateWin(int a, int b, int c)
    {
        if (a == 1 && b != 1 && c != 1) return 3;
        if (b == 1 && a != 1 && c != 1) return 3;
        if (c == 1 && a != 1 && b != 1) return 3;

        if (a == 1 && b == 1 && c != 1) return 5;
        if (a == 1 && c == 1 && b != 1) return 5;
        if (b == 1 && c == 1 && a != 1) return 5;

        if (a == 1 && b == 1 && c == 1) return 10;
        if (a == 2 && b == 2 && c == 2) return 15;
        if (a == 3 && b == 3 && c == 3) return 20;
        if (a == 4 && b == 4 && c == 4) return 30;
        if (a == 5 && b == 5 && c == 5) return 40;
        if (a == 6 && b == 6 && c == 6) return 50;
        if (a == 7 && b == 7 && c == 7) return 75;
        if (a == 8 && b == 8 && c == 8) return 100;

        return 0;
    }
}