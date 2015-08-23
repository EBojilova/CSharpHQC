using System;
using System.IO;

internal class RecursiveNestedLoops
{
    private static int numberOfLoops;

    private static int numberOfIterations;

    private static int[] loops;

    private static void Main()
    {
        //Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
        Console.Write("N = ");
        numberOfLoops = int.Parse(Console.ReadLine());

        Console.Write("K = ");
        numberOfIterations = int.Parse(Console.ReadLine());

        loops = new int[numberOfLoops];

        NestedLoops(0);
        Console.WriteLine();
        GenerationLoops(numberOfLoops-1);
    }

    private static void NestedLoops(int currentLoop)
    {
        if (currentLoop == numberOfLoops) // dano na rekursiata ako sme stignali tretata cifra
        {
            PrintLoops();
            return;
        }

        for (var counter = 1; counter <= numberOfIterations; counter++) // dano na rekursiata ako sme stignali maksimalnato chislo na iteraciata
        {
            loops[currentLoop] = counter; // v loops prezapisvame mnogokratno rezultata
            NestedLoops(currentLoop + 1);
        }
    }

    private static void GenerationLoops(int index)
    {
        if (index == -1) // dano na rekursiata ako sme stignali tretata cifra
        {
            PrintLoops();
            return;
        }

        for (var i = 1; i <= numberOfIterations; i++) // dano na rekursiata ako sme stignali maksimalnato chislo na iteraciata
        {
            loops[index] = i; // v loops prezapisvame mnogokratno rezultata
            GenerationLoops(index - 1);
        }
    }

    private static void PrintLoops()
    {
        for (var i = 0; i < numberOfLoops; i++)
        {
            Console.Write("{0} ", loops[i]);
        }

        Console.WriteLine();
    }
}