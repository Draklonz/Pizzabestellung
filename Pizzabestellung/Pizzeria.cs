using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzabestellung
{
    public class Pizzeria
    {
        private String _name;
        private Pizza[] _speisekarte;
        private Zutat[] _extraZutaten;

        public string Name
        {
            get { return _name; }
        }

        public Pizzeria(String Name, int AnzahlPizzen, int AnzahlExtraZutaten)
        {
            _name = Name;
            _speisekarte = new Pizza[AnzahlPizzen];
            _extraZutaten = new Zutat[AnzahlExtraZutaten];
        }

        public Pizza[] Speisekarte
        {
            get { return _speisekarte; }
            set { _speisekarte = value; }
        }
        public Zutat[] ExtraZutaten
        {
            get { return _extraZutaten; }
            set { _extraZutaten= value; }
        }
    }
}