using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzabestellung
{
    public enum Pizzagroesse 
    {
        klein,
        normal,
        groß
    }
    public class BestellPos
    {
        private Pizzeria _pizzeria;
        private int _kartenindex;
        private int _anzahl;
        private Pizzagroesse _groesse;
        public BestellPos(Pizzeria Name, int index)
        {
            _pizzeria = Name;
            _kartenindex = index;
            _anzahl = 1;
            _groesse = Pizzagroesse.normal;
        }
        public BestellPos(Pizzeria Name, int index, Pizzagroesse groesse)
        {
            _pizzeria = Name;
            _kartenindex = index;
            _anzahl = 1;
            _groesse = groesse;
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
        public Pizzagroesse Groesse
        {
            get { return _groesse; }
        }
    }
}