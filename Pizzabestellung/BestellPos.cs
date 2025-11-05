using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzabestellung
{
    public class BestellPos
    {
        private Pizzeria _pizzeria;
        private int _kartenindex;
        private int _anzahl;
        public BestellPos(Pizzeria Name, int index)
        {
            _pizzeria = Name;
            _kartenindex = index;
            _anzahl = 1;
        }
        public int Anzahl
            { 
            get { return _anzahl; }
            set { _anzahl = value; }
            }
        public int Kartenindex
        {
            get { return _kartenindex; }
        }   
    }
}