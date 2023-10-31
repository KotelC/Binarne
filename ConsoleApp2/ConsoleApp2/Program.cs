using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> wartosciBinarne = CzytajWartosc("G:\\binarne.txt");
        List<string> posortowaneWartosci = Sortowanie(wartosciBinarne);

        WyswietlNumery(posortowaneWartosci);

        foreach (string wartoscBinarna in wartosciBinarne)
        {
            ZnajdzWzorce(wartoscBinarna, "1", 4);
            ZnajdzWzorce(wartoscBinarna, "0", 4);
        }

        List<string> sameJedynki = ZnajdzUnikalne(wartosciBinarne, '1');
        List<string> sameZera = ZnajdzUnikalne(wartosciBinarne, '0');

        Wyswietlanie("Wszystkie wartości zawierające tylko 1:", sameJedynki);
        Wyswietlanie("Wszystkie wartości zawierające tylko 0:", sameZera);
    }

    static List<string> CzytajWartosc(string fileName)
    {
        List<string> watosciBinarne = new List<string>();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                watosciBinarne.Add(line);
            }
        }
        return watosciBinarne;
    }

    static List<string> Sortowanie(List<string> wartosci)
    {
        return wartosci.OrderByDescending(x => x.Length).ToList();
    }

    static void WyswietlNumery(List<string> wartosci)
    {
        for (int i = 0; i < wartosci.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {wartosci[i]}");
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

    static List<string> ZnajdzUnikalne(List<string> wartosci, char character)
    {
        return wartosci.Where(x => x.All(c => c == character)).ToList();
    }

    static void Wyswietlanie(string title, List<string> values)
    {
        Console.WriteLine(title);
        values.ForEach(Console.WriteLine);
    }
}
