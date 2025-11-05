using Microsoft.VisualStudio.TestPlatform.Utilities;
using Pizzabestellung;
using System.Data;

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
        private DataTable MakeTestTable()
        {
            // Create a new DataTable
            DataTable testTable = new DataTable("test");

            // Add column objects to the table.
            testTable.Columns.Add("ID", typeof(int));
            testTable.Columns.Add("Preis", typeof(double));
            testTable.Columns.Add("Rabattcode", typeof(string));
            testTable.Columns.Add("Ausgabe", typeof(double));

            // Fill the Table with Data
            testTable.Rows.Add(1, 24.90, "", 24.90);
            testTable.Rows.Add(2, 24.90, "STUDENT10", 22.41);
            testTable.Rows.Add(3, 24.90, "60MINUS12", 24.90);
            testTable.Rows.Add(4, 73.70, "60MINUS12", 64.86);
            testTable.Rows.Add(5, 180.10, "60MINUS12", 158.49);
            testTable.Rows.Add(6, 180.10, "TOPOrder", 153.09);
            testTable.Rows.Add(7, 180.10, "xxxxx", 180.10);
            testTable.Rows.Add(8, 150.00, "TOPOrder", 127.50);
            testTable.Rows.Add(9, 0.0, "Student10", 0.0);

            // Return the new DataTable.
            return testTable;
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
        [TestMethod]
        public void berechnePreismitRabattTest()
        {
            //DataTable testData = MakeTestTable();
            // Create a new DataTable
            DataTable testTable = new DataTable("test");

            // Add column objects to the table.
            testTable.Columns.Add("ID", typeof(int));
            testTable.Columns.Add("Preis", typeof(double));
            testTable.Columns.Add("Rabattcode", typeof(string));
            testTable.Columns.Add("Ausgabe", typeof(double));

            // Fill the Table with Data
            testTable.Rows.Add(1, 24.90, "", 24.90);
            testTable.Rows.Add(2, 24.90, "STUDENT10", 22.41);
            testTable.Rows.Add(3, 24.90, "60MINUS12", 24.90);
            testTable.Rows.Add(4, 73.70, "60MINUS12", 64.86);
            testTable.Rows.Add(5, 180.10, "60MINUS12", 158.49);
            testTable.Rows.Add(6, 180.10, "TOPOrder", 153.09);
            testTable.Rows.Add(7, 180.10, "xxxxx", 180.10);
            testTable.Rows.Add(8, 150.00, "TOPOrder", 127.50);
            testTable.Rows.Add(9, 0.0, "Student10", 0.0);
            foreach (DataRow row in testTable.Rows)
            {
                double preis = (double)row["Preis"];
                string rabattcode = row["Rabattcode"].ToString();
                double expectedOut = (double)row["Ausgabe"];
                double output = Bestellung.berechnePreisMitRabatt(preis, rabattcode);
                Assert.AreEqual(expectedOut, output);
            }
        }
    }
}
