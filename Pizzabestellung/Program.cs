namespace Pizzabestellung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Konsole auf UTF8 stellen um € Symbole richtig anzuzeigen
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Erstellen neuer Pizzen und extra Zutaten
            Pizza[] pizzen = new Pizza[3];
            pizzen[0] = new("Margerita", 7.90);
            pizzen[1] = new("Salami", 8.90);
            pizzen[2] = new("Fungi", 8.90);

            Zutat[] zutaten = new Zutat[4];
            zutaten[0] = new("Käse", 0.5);
            zutaten[1] = new("Salami", 1.0);
            zutaten[2] = new("Pilz", 1.0);
            zutaten[3] = new("Shrimp", 1.5);

            // Erstellen einer Pizzeria
            Pizzeria pizzeria1 = new("daFranco", 3, 4);

            // Einfügen der Pizzen und Zutaten in die Speisekarte
            for (int i = 0; i < 3; i++)
            {
                pizzeria1.Speisekarte[i] = pizzen[i];
            }
            for (int i = 0; i < 4; i++)
            {
                pizzeria1.ExtraZutaten[i] = zutaten[i];
            }

            // Erstellung der Kunden
            Kunde kunde1 = new(123456);

            // Bestellung
            Bestellung order1 = new(pizzeria1, kunde1);
            order1.FuegePositionHinzu(2);
            order1.FuegePositionHinzu(0);
            order1.BestellPosList[1].FuegeZutatHinzu(2);
            order1.FuegePositionHinzu(2);
            order1.FuegePositionHinzu(1);

            Console.WriteLine(order1.DruckeBestellung());
        }
    }
}
