using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Galgje
{
    public class Galgje
    {
        private List<Char> _gekozenLetters;
        private int _aantalPogingen;
        private string _teRadenWoord;
        private Categorie _categorie;

        public Galgje()
        {
            _gekozenLetters = new List<char>();
            _aantalPogingen = 0;
        }
        public string GetGemaskeerdWoord()
        {
            string maskedWord = _teRadenWoord;
            foreach (var c in maskedWord)
            {
                if (!_gekozenLetters.Contains(c))
                {
                    maskedWord = maskedWord.Replace(c, '*');
                }
            }
            return maskedWord;
        }
        public int GetAantalPogingen() => _aantalPogingen;
        public List<Char> GetGekozenLetters() => _gekozenLetters;
        public void SetCategorie(Categorie categorie)
        {
            _categorie = categorie;
            _teRadenWoord = _categorie.GetRandomWoord();
        }
        public void VoegLetterToe(char c)
        {
            if (!isEindeSpel())
            {
                if (_gekozenLetters.Contains(c))
                    IncrementAantalPogingen();
                else
                {
                    AddLetterToGekozenLetters(c);
                    if (!_teRadenWoord.Contains(c))
                        IncrementAantalPogingen();
                }
            }
        }
        public bool isEindeSpel()
        {
            if (GetStatus() == "WON" || GetStatus() == "LOST")
                return true;
            else
                return false;

        }
        public string GetWoord()
        {
            return _teRadenWoord;
        }
        public string GetStatus()
        {
            if (GetGemaskeerdWoord() == _teRadenWoord)
                return "WON";
            else if (_aantalPogingen >= _categorie.GetMoeilijkheidsGraad())
                return "LOST";
            else
                return "NOT ENDED";
        }
        private void IncrementAantalPogingen()
        {
            _aantalPogingen++;
        }
        private void AddLetterToGekozenLetters(char c)
        {
            _gekozenLetters.Add(c);
        }


    }
}
