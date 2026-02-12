using MySql.Data.MySqlClient;
using System.Data;
using Pizzabestellung;

namespace PizzabestellungUI
{

    public partial class Form1 : Form
    {
        const string connectorstring = "Server=localhost;Database=pizzabestellung_jonas;Uid=root;Pwd=Ich_1998;";

        private Bestellung bestellung;
        private Pizzeria pizzeria1;
        public Form1()
        {

            InitializeComponent();

            //Zutat[] zutaten = new Zutat[4];
            //zutaten[0] = new("Käse", 0.5);
            //zutaten[1] = new("Salami", 1.0);
            //zutaten[2] = new("Pilz", 1.0);
            //zutaten[3] = new("Shrimp", 1.5);

            // Erstellen einer Pizzeria
            pizzeria1 = new("daFranco", 6, 4);
            FillSpeisekarte();
            //for (int i = 0; i < pizzen.Length; i++)
            //{
            //    pizzeria1.Speisekarte[i] = pizzen[i];
            //}
            //for (int i = 0; i < 4; i++)
            //{
            //    pizzeria1.ExtraZutaten[i] = zutaten[i];
            //}
            Kunde kunde1 = new(9966);
            using (var connection = new MySqlConnection(connectorstring))
            {
                // Datenbank-Kommando zusammenbauen
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT MAX(BNR) FROM Bestellungen;";
                command.CommandType = CommandType.Text;

                try
                {
                    connection.Open(); // Verbindung öffnen
                    MySqlDataReader reader = command.ExecuteReader(); // SQL-Befehl ausführen
                    reader.Read();
                    bestellung = new(pizzeria1, kunde1, Convert.ToInt32(reader[0]) + 1);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Console.ReadLine();
            }

        }
        public void FillSpeisekarte()
        {
            Speisekarte.BeginUpdate();

            // ListView leeren            
            Speisekarte.Items.Clear();
            Speisekarte.Columns.Clear();
            using (var connection = new MySqlConnection(connectorstring))
            {
                // Datenbank-Kommando zusammenbauen
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM PIZZEN;";
                command.CommandType = CommandType.Text;

                try
                {
                    connection.Open(); // Verbindung öffnen
                    MySqlDataReader reader = command.ExecuteReader(); // SQL-Befehl ausführen

                    // Tabellenüberschriften in die ListView schreiben
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);
                        Speisekarte.Columns.Add(columnName, Speisekarte.Width / reader.FieldCount, HorizontalAlignment.Left);
                    }

                    // Datensätze auf dem Reader lesen und in ListViewItems schreiben
                    int p = 0;
                    while (reader.Read())
                    {
                        if (reader.FieldCount > 0)
                        {
                            ListViewItem lvi = new ListViewItem(reader[0].ToString());

                            for (int i = 1; i < reader.FieldCount; i++)
                            {
                                lvi.SubItems.Add(reader[i].ToString());

                            }
                            pizzeria1.Speisekarte[p] = new Pizza(reader[1].ToString(), Decimal.ToDouble((decimal)reader[2]));
                            p++;
                            Speisekarte.Items.Add(lvi);
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Console.ReadLine();

            }
            Speisekarte.EndUpdate();
        }

        private void AktualisiereBestellListe()
        {
            BestellListe.Items.Clear();
            foreach (BestellPos x in bestellung.BestellPosList)
            {
                string name = x.Pizza.Name;
                var item = new ListViewItem(name);
                item.SubItems.Add(x.Anzahl.ToString());
                item.SubItems.Add(x.Groesse.ToString());
                string strZutaten = "";
                foreach (int i in x.ExtraZutat)
                {
                    strZutaten += x.Pizzeria.ExtraZutaten[i].Name;
                    strZutaten += ", ";
                }
                item.SubItems.Add(strZutaten);
                item.SubItems.Add($"{x.BerechnePosPreis():0.00} €");

                BestellListe.Items.Add(item);
            }
        }

        private void buttonAddPos_Click(object sender, EventArgs e)
        {
            if (Speisekarte.SelectedItems.Count == 1)
            {
                var rb = groupGroesse.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                if (rb != null)
                {
                    bestellung.FuegePositionHinzu(Speisekarte.SelectedIndices[0], Enum.Parse<Pizzagroesse>(rb.Text));
                }
                AktualisiereBestellListe();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BestellListe.SelectedItems.Count == 1)
            {
                var myForm2 = new Form2(bestellung, BestellListe.SelectedIndices[0]);
                myForm2.FormClosed += Form2_FormClosed;
                myForm2.Show();
            }
        }

        private void Form2_FormClosed(object? sender, FormClosedEventArgs e)
        {
            AktualisiereBestellListe();
        }

        private void buttonBestell_Click(object sender, EventArgs e)
        {
            if (textBoxRabatt != null)
            {
                bestellung.Rabattcode = textBoxRabatt.Text;
            }
            if (textBox1.Text == "")
            {
                textBox1.BackColor = Color.Red;
            }
            else
            {
                using (var connection = new MySqlConnection(connectorstring))
                {
                    // Datenbank-Kommando zusammenbauen
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = $"INSERT INTO Bestellungen (BNR, KNR, Datum, Rabatt) VALUES ({bestellung.Bestellnummer}, {bestellung.Kunde.Kundennummer}, @datum, \"{bestellung.Rabattcode}\");";
                    command.Parameters.Add("@datum", MySqlDbType.Date).Value = DateTime.Today;
                    command.CommandType = CommandType.Text;

                    connection.Open(); // Verbindung öffnen
                    MySqlDataReader reader = command.ExecuteReader(); // SQL-Befehl ausführen
                    reader.Close();
                    foreach (BestellPos pos in bestellung.BestellPosList)
                    {
                        command.CommandText = $"INSERT INTO Bestelllisten (BNR, PNR, Anzahl) VALUES ({bestellung.Bestellnummer}, {pos.Kartenindex + 1}, {pos.Anzahl});";
                        command.CommandType = CommandType.Text;

                        try
                        {
                            reader = command.ExecuteReader(); // SQL-Befehl ausführen
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        Console.ReadLine();
                    }



                    string adresse = (textBox1.Text);
                    string text = bestellung.DruckeBestellung();
                    text += "\nLieferadresse: " + adresse;
                    DialogResult result = MessageBox.Show(text, "Bestellung");
                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonBestellHistorie_Click(object sender, EventArgs e)
        {
            var myForm3 = new Form3(connectorstring);
            myForm3.FormClosed += Form2_FormClosed;
            myForm3.Show();
        }
    }
}
