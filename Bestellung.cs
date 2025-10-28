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
        public void fuegePositionHinzu(int pizzanummer)
        {
            
            for (int i = 0; i < _pos.Count; i++)
            {
                if (_pos[i].Kartenindex == pizzanummer)
                {

                }
            }

            _pos.Add(new BestellPos(_pizzeria, pizzanummer));
        }
        private int berechnePreis()
        {
            int preis = 0;
            _pos.ForEach(position =>
            {
                preis += _pizzeria.Speisekarte[position.Kartenindex].Preis * position.Anzahl;
            });
            return preis;
        }
        //public Pizzeria Pizzeria
        //{
        //    get { return _Pizzeria; }
        //}
    }
}