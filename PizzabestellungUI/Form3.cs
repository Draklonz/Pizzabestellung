using MySql.Data.MySqlClient;
using Pizzabestellung;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzabestellungUI
{
    public partial class Form3 : Form
    {
        string _connectorstring;
        public Form3(string connector)
        {

            _connectorstring = connector;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bestellungen.Items.Clear();
            int kundennummer = Convert.ToInt32(numericUpDown1.Value);
            using (var connection = new MySqlConnection(_connectorstring))
            {
                // Datenbank-Kommando zusammenbauen
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = $"SELECT BNR, DATUM, RABATT FROM Bestellungen WHERE KNR={kundennummer};";
                command.CommandType = CommandType.Text;
                try
                {
                    connection.Open(); // Verbindung öffnen
                    MySqlDataReader reader = command.ExecuteReader(); // SQL-Befehl ausführen
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);
                        Bestellungen.Columns.Add(columnName, Bestellungen.Width / reader.FieldCount, HorizontalAlignment.Left);
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
                            Bestellungen.Items.Add(lvi);
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
        }

        private void Bestellungen_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (Bestellungen.SelectedItems.Count > 0)
            {
                // Erste ausgewählte Zeile holen
                ListViewItem item = Bestellungen.SelectedItems[0];

                // Erste Spalte (BNR)
                int bestellnr = Convert.ToInt32(item.Text);
                using (var connection = new MySqlConnection(_connectorstring))
                {
                    // Datenbank-Kommando zusammenbauen
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = $"SELECT Bestelllisten.BNR, PName, Anzahl FROM Bestelllisten LEFT JOIN Pizzen ON pizzen.PNR = bestelllisten.PNR  WHERE BNR={bestellnr};";
                    command.CommandType = CommandType.Text;
                    try
                    {
                        connection.Open(); // Verbindung öffnen
                        MySqlDataReader reader = command.ExecuteReader(); // SQL-Befehl ausführen
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);
                            listView1.Columns.Add(columnName, listView1.Width / reader.FieldCount, HorizontalAlignment.Left);
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
                                listView1.Items.Add(lvi);
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
            }
        }
    }
}
