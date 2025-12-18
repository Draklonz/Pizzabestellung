using Pizzabestellung;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzabestellungUI
{
    public partial class Form2 : Form
    {
        private Bestellung bestellung;
        private int bestellPos;
        public Form2(Bestellung bestell, int pos)
        {
            InitializeComponent();
            bestellung = bestell;
            bestellPos = pos;

            // extraZutaten definieren
            comboBoxExtraZutaten.Items.Clear();
            for (int i = 0; i < bestellung.Pizzeria.ExtraZutaten.Length; i++)
            {
                comboBoxExtraZutaten.Items.Add(bestellung.Pizzeria.ExtraZutaten[i].Name);
            }

        }
        private void UpdateExtraZutaten()
        {
            listExtraZutaten.Items.Clear();
            foreach (var x in bestellung.BestellPosList[bestellPos].ExtraZutat)
            {
                listExtraZutaten.Items.Add(bestellung.Pizzeria.ExtraZutaten[x].Name);
            }
        }
        private void buttonRemoveZutat_Click(object sender, EventArgs e)
        {
            if (listExtraZutaten.SelectedIndex != -1)
            {
                bestellung.BestellPosList[bestellPos].EntferneZutat(listExtraZutaten.SelectedIndex);
                UpdateExtraZutaten();
            }
        }

        private void buttonAddZutat_Click(object sender, EventArgs e)
        {
            if (comboBoxExtraZutaten.SelectedIndex != -1)
            {
                bestellung.BestellPosList[bestellPos].FuegeZutatHinzu(comboBoxExtraZutaten.SelectedIndex);
                UpdateExtraZutaten();
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            bestellung.EntfernePosition(bestellPos);
            this.Close();
        }
    }
}
