using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// wspólne klasy
public class Wymiary
{
    public int Wysokosc { get; set; }
}

public class Klocek
{
    public string Nazwa { get; set; }
    public Wymiary Rozmiar { get; set; } 
}

class Program
{
    static void Main()
    {
        try
        {
            // --- ODCZYT I DESERIALIZACJA ---
            
            // Wczytujemy cały tekst z pliku
            string json = File.ReadAllText("plik.json");
            
            // Tłumaczymy JSON z powrotem na listę obiektów C#
            List<Klocek> lista = JsonSerializer.Deserialize<List<Klocek>>(json);

            Console.WriteLine("Sukces! Odczytano klocki z pliku:\n");
            
            // Pętla wypisująca każdy odczytany klocek na ekran
            foreach (var k in lista)
            {
                Console.WriteLine($"Klocek: {k.Nazwa}, Wysokość: {k.Rozmiar.Wysokosc}");
            }
        }
        catch (Exception)
        {
            // Łapie błąd m.in. wtedy, gdy zapomnisz najpierw odpalić pierwszego programu
            Console.WriteLine("Błąd! Nie udało się odczytać pliku. Upewnij się, że plik.json istnieje.");
        }
    }
}