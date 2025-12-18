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
        public BestellPos(Pizzeria Name, int index, Pizzagroesse groesse)
        {
            _pizzeria = Name;
            _kartenindex = index;
            _anzahl = 1;
            _groesse = groesse;
            _zutatenindex = [];
        }
        public Pizzeria Pizzeria
        {
            get { return _pizzeria; }
        }
        public int Anzahl
            { 
            get { return _anzahl; }
            set { _anzahl = value; }
            }
        public Pizza Pizza
        {
            get { return _pizzeria.Speisekarte[_kartenindex]; }
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
        private double GetGroessenFaktor()
        {
            double groessenFaktor;
            switch (_groesse)
            {
                case Pizzagroesse.klein:
                    groessenFaktor = 0.75;
                    break;
                case Pizzagroesse.normal:
                    groessenFaktor = 1;
                    break;
                case Pizzagroesse.groß:
                    groessenFaktor = 1.33;
                    break;
                default:
                    groessenFaktor = 1;
                    break;
            }
            return groessenFaktor;
        }
        public double BerechnePosPreis()
        {
            double preis = 0;

            if (_kartenindex < _pizzeria.Speisekarte.Length)
            {
                preis = _pizzeria.Speisekarte[_kartenindex].Preis * GetGroessenFaktor();
                foreach (int zutat in _zutatenindex)
                {
                    preis += _pizzeria.ExtraZutaten[zutat].Preis;
                }

                preis = preis * _anzahl;
            }
            return preis;
        }
        public string DruckePos()
        {
            string output = string.Empty;
            output = $"\n- {_anzahl}x {_pizzeria.Speisekarte[_kartenindex].Name} {_groesse}  {(_pizzeria.Speisekarte[_kartenindex].Preis * GetGroessenFaktor()):0.00}€";
            foreach (int pos in _zutatenindex)
            {
                output += $"\n      extra {_pizzeria.ExtraZutaten[pos].Name}  {_pizzeria.ExtraZutaten[pos].Preis:0.00}€";
            }
            return output;
        }
    }
}