namespace Pizzabestellung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Erstellen neuer Pizzen
            Pizza[] pizzen = new Pizza[3];
            pizzen[0] = new("Margerita", 7.90);
            pizzen[1] = new("Salami", 8.90);
            pizzen[2] = new("Fungi", 8.90);

            // Erstellen einer Pizzeria
            Pizzeria pizzeria1 = new("daFranco", 3);

            // Einfügen der Pizzen in die Speisekarte
            for (int i = 0; i < 3; i++)
            {
                pizzeria1.Speisekarte[i] = pizzen[i];
            }

            // Erstellung der Kunden
            Kunde kunde1 = new(123456);

            // Bestellung
            Bestellung order1 = new(pizzeria1, kunde1);
            order1.FuegePositionHinzu(2);
            order1.FuegePositionHinzu(0);
            order1.FuegePositionHinzu(2);
            order1.FuegePositionHinzu(1);

            Console.WriteLine(order1.DruckeBestellung());
        }
    }
}
