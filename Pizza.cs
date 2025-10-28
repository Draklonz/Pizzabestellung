using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzabestellung
{
    public class Pizza
    {
        private string _Name;
        private int _Preis;
        public Pizza(string Name, int Preis)
        {
            _Name = Name;
            _Preis = Preis;
        }
        public string Name
        {
            get { return _Name; }
        }
        public int Preis
        {
            get { return _Preis; }
        }
    }
}