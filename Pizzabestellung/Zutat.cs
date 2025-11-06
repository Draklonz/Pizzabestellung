using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzabestellung
{
    public class Zutat
    {
        private string _name;
        private double _preis;

        public Zutat(string name, double preis) 
        { 
            _name = name;
            _preis = preis;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Preis
        {
            get { return _preis; }
            set { _preis = value; } 
        }
    }
}
