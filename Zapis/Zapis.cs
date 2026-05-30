using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Wspólne klasy (muszą być w obu programach)
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
        List<Klocek> lista = new List<Klocek>();

        try
        {
            Console.WriteLine("--- TWORZENIE KLOCKÓW ---");
            
            // Pętla ustala, że wpisujemy dane dla 2 klocków
            for (int i = 0; i < 2; i++)
            {
                Klocek k = new Klocek();
                k.Rozmiar = new Wymiary(); // Zawsze trzeba zainicjować zagnieżdżoną klasę

                Console.Write("Podaj nazwę klocka: ");
                k.Nazwa = Console.ReadLine(); // Pobiera tekst od użytkownika

                Console.Write("Podaj wysokość (tylko cyfry): ");
                // int.Parse zamienia tekst na liczbę. Jak wpiszesz litery, rzuci wyjątek (błąd)
                k.Rozmiar.Wysokosc = int.Parse(Console.ReadLine()); 

                lista.Add(k); // Dodajemy gotowy klocek do listy
            }

            // Zamieniamy listę na tekst (JSON) i zapisujemy do pliku
            string json = JsonSerializer.Serialize(lista);
            File.WriteAllText("plik.json", json);
            
            Console.WriteLine("Zapisano pomyślnie do pliku.json!");
        }
        catch (Exception)
        {
            // Ten blok uruchomi się, jeśli użytkownik wpisze coś źle (np. tekst zamiast liczby)
            Console.WriteLine("Błąd! Wprowadzono nieprawidłowe dane (np. litery zamiast cyfr).");
        }
    }
}