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
            foreach(BestellPos item in _pos)
            {
                if(item.Kartenindex <= _pizzeria.Speisekarte.Length)
                {
                    preis += _pizzeria.Speisekarte[item.Kartenindex].Preis * item.Anzahl;
                }
                else
                {
                    return 0;
                }
            };
            return preis;
        }

        public static double berechnePreisMitRabatt(double preis, string rabattcode)
        {
            switch (rabattcode)
            {
                case "STUDENT10":
                    preis -= preis * 0.1;
                    preis = Math.Round(preis, 2, MidpointRounding.ToPositiveInfinity);
                    return preis;
                case "60MINUS12":
                    if (preis >= 60.0)
                    {
                        preis -= preis * 0.12;
                    }
                    preis = Math.Round(preis, 2, MidpointRounding.ToPositiveInfinity);
                    return preis;
                case "TOPOrder":
                    if(preis >= 150.0)
                    {
                        preis -= preis * 0.15;
                    }
                    preis = Math.Round(preis, 2, MidpointRounding.ToPositiveInfinity);
                    return preis;
                default:
                    return preis;
            }
        }

        public string DruckeBestellung()
        {
            string output = "Der Kunde Nr. ";
            output += _kunde.Kundennummer;
            output += " hat für ";
            output += Math.Round(BerechnePreis(), 2).ToString("0.00");
            output += " Euro bestellt bei Pizzeria ";
            output += _pizzeria.Name;
            output += ":";
            foreach (BestellPos item in _pos)
            {
                
                if (item.Kartenindex <= _pizzeria.Speisekarte.Length)
                {
                    output += "\n" + item.Anzahl + "x " + _pizzeria.Speisekarte[item.Kartenindex].Name;
                }
                else
                {
                    return "0.00";
                }
            }
            return output;
        }
    }
}