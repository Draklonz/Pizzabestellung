using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzabestellung
{
    public class Kunde
    {
        private int _Kundennummer;

        public Kunde(int Nummer)
        {
            _Kundennummer = Nummer;
        }

        public int Kundennummer
        {
            get { return _Kundennummer; }
        }

    }
}