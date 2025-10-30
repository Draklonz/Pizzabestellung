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

        public string Name
        {
            get { return _name; }
        }

        public Pizzeria(String Name, int Anzahl)
        {
            _name = Name;
            _speisekarte = new Pizza[Anzahl];
        }

        public Pizza[] Speisekarte
        {
            get { return _speisekarte; }
            set { _speisekarte = value; }
        }
    }
}