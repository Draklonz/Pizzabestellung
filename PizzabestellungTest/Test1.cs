using Pizzabestellung;

namespace PizzabestellungTest
{
    [TestClass]
    public sealed class Test1
    {
        private void setupBestellung(Pizzeria pizzeria, Kunde kunde)
        {
            // Erstellen neuer Pizzen
            Pizza[] pizzen = new Pizza[3];
            pizzen[0] = new("Margerita", 7.90);
            pizzen[1] = new("Salami", 8.90);
            pizzen[2] = new("Fungi", 8.90);

            // Einfügen der Pizzen in die Speisekarte
            for (int i = 0; i < 3; i++)
            {
                pizzeria.Speisekarte[i] = pizzen[i];
            }

            // Erstellung der bestellung
            Bestellung order1 = new(pizzeria, kunde);
        }

        [TestMethod]
        public void berechnePreisTest1()
        {
            // Arrange
            string expectedOut = "Der Kunde Nr. 4711 hat für 26,70 Euro bestellt bei Pizzeria daFranco:\n3x Fungi";
            Pizzeria pizzeria1 = new("daFranco", 3);
            Kunde kunde1 = new(4711);

            // Act
            setupBestellung(pizzeria1, kunde1);
            Bestellung order1 = new(pizzeria1, kunde1);
            for (int i = 0; i < 3; i++)
            { order1.FuegePositionHinzu(2);}

            // Assert
            Assert.AreEqual(expectedOut, order1.DruckeBestellung());
        }
        [TestMethod]
        public void berechnePreisTest2()
        {
            // Arrange
            string expectedOut = "Der Kunde Nr. 4711 hat für 25,70 Euro bestellt bei Pizzeria daFranco:\n1x Margerita\n1x Salami\n1x Fungi";
            Pizzeria pizzeria1 = new("daFranco", 3);
            Kunde kunde1 = new(4711);

            // Act
            setupBestellung(pizzeria1, kunde1);
            Bestellung order1 = new(pizzeria1, kunde1);
            order1.FuegePositionHinzu(0);
            order1.FuegePositionHinzu(1);
            order1.FuegePositionHinzu(2);

            // Assert
            Assert.AreEqual(expectedOut, order1.DruckeBestellung());
        }
        [TestMethod]
        public void berechnePreisTest3()
        {
            // Arrange
            string expectedOut = "Der Kunde Nr. 4711 hat für 0,00 Euro bestellt bei Pizzeria daFranco:";
            Pizzeria pizzeria1 = new("daFranco", 3);
            Kunde kunde1 = new(4711);

            // Act
            setupBestellung(pizzeria1, kunde1);
            Bestellung order1 = new(pizzeria1, kunde1);

            // Assert
            Assert.AreEqual(expectedOut, order1.DruckeBestellung());
        }
        [TestMethod]
        public void berechnePreisTest4()
        {
            // Arrange
            string expectedOut = "0.00";
            Pizzeria pizzeria1 = new("daFranco", 3);
            Kunde kunde1 = new(4711);

            // Act
            setupBestellung(pizzeria1, kunde1);
            Bestellung order1 = new(pizzeria1, kunde1);
            order1.FuegePositionHinzu(0);
            order1.FuegePositionHinzu(1);
            order1.FuegePositionHinzu(4);

            // Assert
            Assert.AreEqual(expectedOut, order1.DruckeBestellung());
        }
    }
}
