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
        private readonly Pizzeria _pizzeria;
        private readonly int _kartenindex;
        private int _anzahl;
        private Pizzagroesse _groesse;
        private readonly List<int> _zutatenindex;
        //legacy Methode
        public BestellPos(Pizzeria Name, int index)
        {
            _pizzeria = Name;
            _kartenindex = index;
            _anzahl = 1;
            _groesse = Pizzagroesse.normal;
            _zutatenindex = [];
        }
        public BestellPos(Pizzeria Name, int index, Pizzagroesse groesse)
        {
            _pizzeria = Name;
            _kartenindex = index;
            _anzahl = 1;
            _groesse = groesse;
            _zutatenindex = [];
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
            set { _groesse = value; }
        }
        public List<int> ExtraZutat
        {
            get { return _zutatenindex; }
        }
        public void FuegeZutatHinzu(int zutat)
        {
            _zutatenindex.Add(zutat);
        }
        public void EntferneZutat(int position)
        {
            _zutatenindex.Remove(_zutatenindex[position]);
        }
        public double BerechnePosPreis()
        {
            double preis = 0;
            double groessenFactor;
            if (_kartenindex < _pizzeria.Speisekarte.Length)
            {
                preis = _pizzeria.Speisekarte[_kartenindex].Preis;
                foreach (int zutat in _zutatenindex)
                {
                    preis += _pizzeria.ExtraZutaten[zutat].Preis;
                }
                switch (_groesse)
                {
                    case Pizzagroesse.klein:
                        groessenFactor = 0.75;
                        break;
                    case Pizzagroesse.normal:
                        groessenFactor = 1;
                        break;
                    case Pizzagroesse.groß:
                        groessenFactor = 1.33;
                        break;
                    default:
                        groessenFactor = 1;
                        break;
                }
                preis = preis * _anzahl * groessenFactor;
            }
            return preis;
        }
    }
}