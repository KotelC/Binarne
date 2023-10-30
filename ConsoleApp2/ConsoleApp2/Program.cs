using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> binaryValues = CzytajWartosc("C:\\binarne.txt");
        List<string> sortedValues = Sortowanie(binaryValues);

        WyswietlNumery(sortedValues);

        foreach (string binaryValue in binaryValues)
        {
            ZnajdzWzorce(binaryValue, "1", 4);
            ZnajdzWzorce(binaryValue, "0", 4);
        }

        List<string> allOnes = ZnajdzUnikalne(binaryValues, '1');
        List<string> allZeros = ZnajdzUnikalne(binaryValues, '0');

        Wyswietlanie("Wszystkie wartości zawierające tylko 1:", allOnes);
        Wyswietlanie("Wszystkie wartości zawierające tylko 0:", allZeros);
    }

    static List<string> CzytajWartosc(string fileName)
    {
        List<string> binaryValues = new List<string>();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                binaryValues.Add(line);
            }
        }
        return binaryValues;
    }

    static List<string> Sortowanie(List<string> values)
    {
        return values.OrderByDescending(x => x.Length).ToList();
    }

    static void WyswietlNumery(List<string> values)
    {
        for (int i = 0; i < values.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {values[i]}");
        }
    }

    static void ZnajdzWzorce(string wartoscbinarna, string wzorzec, int dlugosc)
    {
        for (int i = 0; i <= wartoscbinarna.Length - dlugosc; i++)
        {
            if (wartoscbinarna.Substring(i).StartsWith(wzorzec.PadLeft(dlugosc, wzorzec[0])))
            {
                Console.WriteLine($"Znaleziono wzorzec '{wzorzec}' w linii od pozycji {i} do {i + dlugosc - 1}.");
            }
        }
    }

    static List<string> ZnajdzUnikalne(List<string> values, char character)
    {
        return values.Where(x => x.All(c => c == character)).ToList();
    }

    static void Wyswietlanie(string title, List<string> values)
    {
        Console.WriteLine(title);
        values.ForEach(Console.WriteLine);
    }
}
