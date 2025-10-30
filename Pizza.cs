using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzabestellung
{
    public class Pizza
    {
        private string _Name;
        private double _Preis;
        public Pizza(string Name, double Preis)
        {
            _Name = Name;
            _Preis = Preis;
        }
        public string Name
        {
            get { return _Name; }
        }
        public double Preis
        {
            get { return _Preis; }
        }
    }
}