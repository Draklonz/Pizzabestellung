using Pizzabestellung;

namespace PizzabestellungUI
{
    public partial class Form1 : Form
    {
        private Bestellung bestellung;
        public Form1()
        {
            InitializeComponent();
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
            FillSpeisekarte(pizzen);
            for (int i = 0; i < pizzen.Length; i++)
            {
                pizzeria1.Speisekarte[i] = pizzen[i];
            }
            for (int i = 0; i < 4; i++)
            {
                pizzeria1.ExtraZutaten[i] = zutaten[i];
            }
            Kunde kunde1 = new(123456);
            bestellung = new(pizzeria1, kunde1);

        }
        public void FillSpeisekarte(Pizza[] PizzaArray)
        {
            Speisekarte.Items.Clear();
            foreach (Pizza p in PizzaArray)
            {
                var item = new ListViewItem(p.Name);
                item.SubItems.Add($"{p.Preis:0.00} €");

                Speisekarte.Items.Add(item);
            }
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
            if (textBox1.Text == "")
            {
                textBox1.BackColor = Color.Red;
            }
            else
            {
                string adresse = textBox1.Text;
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
}
