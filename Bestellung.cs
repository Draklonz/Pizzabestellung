using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzabestellung
{
    public class Bestellung
    {
        private Pizzeria _pizzeria;
        private Kunde _kunde;
        private List<BestellPos> _pos;

        public Bestellung(Pizzeria pizzeria, Kunde kunde)
        {
            _pizzeria = pizzeria;
            _kunde = kunde;
            _pos = new List<BestellPos>();
        }
        public void FuegePositionHinzu(int pizzanummer)
        {
            bool unique = true;
            for (int i = 0; i < _pos.Count; i++)
            {
                if (_pos[i].Kartenindex == pizzanummer)
                {
                    _pos[i].Anzahl += 1;
                    unique = false; break;
                }
            }
            if (unique)
            {
                _pos.Add(new BestellPos(_pizzeria, pizzanummer));
            }
        }
        private double BerechnePreis()
        {
            double preis = 0;
            _pos.ForEach(position =>
            {
                preis += _pizzeria.Speisekarte[position.Kartenindex].Preis * position.Anzahl;
            });
            return preis;
        }
        public string DruckeBestellung()
        {
            string output = "Der Kunde Nr. ";
            output += _kunde.Kundennummer;
            output += " hat für ";
            output += Math.Round(BerechnePreis(), 2);
            output += " Euro bestellt bei Pizzeria ";
            output += _pizzeria.Name;
            output += ":\n";
            foreach (BestellPos item in _pos)
            {
                output += "- " + _pizzeria.Speisekarte[item.Kartenindex].Name + " x " + item.Anzahl + "\n";
            }
            return output;
        }
    }
}