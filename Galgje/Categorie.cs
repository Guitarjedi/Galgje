using System;
using System.Collections.Generic;

namespace Galgje
{
    public class Categorie
    {
        private string naam;
        private string omschrijving;
        private int moeilijkheidsgraad;
        private List<string> woorden;

        public Categorie(string naam, string omschrijving, int moeilijkheidsgraad, List<string> woorden)
        {
            this.naam = naam;
            this.omschrijving = omschrijving;
            this.moeilijkheidsgraad = moeilijkheidsgraad;
            this.woorden = woorden;
        }
        public string GetNaam() => naam;
        public string GetOmschrijving() => omschrijving;
        public int GetMoeilijkheidsGraad() => moeilijkheidsgraad;

        public string GetRandomWoord()
        {
            var rnd = new Random();
            return woorden[rnd.Next(woorden.Count)];
        }

    }
}