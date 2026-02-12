using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using MySql.Data.MySqlClient;

namespace Pizzabestellung
{

    public class Bestellung
    {
        const string connectorstring = "Server=localhost;Database=pizzabestellung_jonas;Uid=root;Pwd=Ich_1998;";
        private readonly Pizzeria _pizzeria;
        private readonly Kunde _kunde;
        private readonly List<BestellPos> _pos;
        private string _lieferadresse;
        private string _rabattcode;
        private int _bestellnummer;

        public Bestellung(Pizzeria pizzeria, Kunde kunde, int bestellnummer)
        {
            _pizzeria = pizzeria;
            _kunde = kunde;
            _pos = [];
            _lieferadresse = string.Empty;
            _rabattcode = string.Empty;
            _bestellnummer = bestellnummer;
        }
        public int Bestellnummer
        {
            get { return _bestellnummer; }
        }
        public Pizzeria Pizzeria
        {
            get { return _pizzeria; }
        }
        public Kunde Kunde
        {
            get { return _kunde; }
        }
        public string Lieferadresse
        {
            get { return _lieferadresse; }
            set { _lieferadresse = value; }
        }
        public string Rabattcode
        {
            get { return _rabattcode; }
            set { _rabattcode = value; }
        }
        public List<BestellPos> BestellPosList
        {
            get { return _pos; }
        }
        public void FuegePositionHinzu(int pizzanummer)
        {
            Pizzagroesse groesse = Pizzagroesse.normal;
            bool unique = true;
            foreach (BestellPos pos in _pos)
            {
                if (pos.Kartenindex == pizzanummer && pos.Groesse == groesse)
                {
                    pos.Anzahl += 1;
                    unique = false; break;
                }
            }
            if (unique)
            {
                _pos.Add(new BestellPos(_pizzeria, pizzanummer, groesse));
            }

        }
        public void FuegePositionHinzu(int pizzanummer, Pizzagroesse groesse)
        {
            bool unique = true;
            if (pizzanummer < _pizzeria.Speisekarte.Length)
            {
                foreach (BestellPos pos in _pos)
                {
                    if (pos.Kartenindex == pizzanummer &&
                        pos.Groesse == groesse &&
                        pos.ExtraZutat.Count == 0)
                    {
                        pos.Anzahl += 1;
                        unique = false; break;
                    }
                }
                if (unique)
                {
                    _pos.Add(new BestellPos(_pizzeria, pizzanummer, groesse));
                }
            }
            }
        public void EntfernePosition(int position)
        {
            _pos.Remove(_pos[position]);
        }
        private double BerechnePreis()
        {
            double preis = 0;
            foreach(BestellPos item in _pos)
            {
                preis += item.BerechnePosPreis();
            }
            return preis;
        }

        public static double BerechnePreisMitRabatt(double preis, string rabattcode)
        {
            switch (rabattcode)
            {
                case "STUDENT10":
                    preis -= preis * 0.1;
                    preis = Math.Round(preis, 2, MidpointRounding.AwayFromZero);
                    return preis;
                case "60MINUS12":
                    if (preis >= 60.0)
                    {
                        preis -= preis * 0.12;
                    }
                    preis = Math.Round(preis, 2, MidpointRounding.AwayFromZero);
                    return preis;
                case "TOPOrder":
                    if(preis >= 150.0)
                    {
                        preis -= preis * 0.15;
                    }
                    preis = Math.Round(preis, 2, MidpointRounding.AwayFromZero);
                    return preis;
                default:
                    return preis;
            }
        }

        public string DruckeBestellung()
        {
            if (_pos.Count == 0)
            {
                return "0.00";
            }
            string output = "Der Kunde Nr. ";
            output += _kunde.Kundennummer;
            output += " hat für ";
            output += Bestellung.BerechnePreisMitRabatt(BerechnePreis(), _rabattcode).ToString("0.00");
            output += " Euro bestellt bei Pizzeria ";
            output += _pizzeria.Name;
            output += ":";
            foreach (BestellPos item in _pos)
            {
                    output += item.DruckePos();
            }
            return output;
        }
    }
}