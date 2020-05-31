using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

namespace Galgje
{
    public class DomeinController
    {
        public DomeinController()
        {
            categoryRepo = new CategoryRepo();
            initializeData();
        }
        private CategoryRepo categoryRepo;
        private Galgje galgje;

        public List<List<string>> GetCategories()
        {
           return categoryRepo.GetAllCategories();
        }
        public void KiesCategorie(string naam)
        {
            galgje = new Galgje();
            var cat = categoryRepo.GetCategorie(naam);
            galgje.SetCategorie(cat);

        }
        
        public List<string> GetWoordInfo()
        {
            var woordInfo = new List<string>();

           woordInfo.Add(galgje.GetAantalPogingen().ToString());
            woordInfo.Add(galgje.GetGemaskeerdWoord());
            string chosenLetters = String.Empty;
            foreach(var c in galgje.GetGekozenLetters())
            {
                chosenLetters += c;
            }
            woordInfo.Add(chosenLetters);

            return woordInfo;


        }
        public void KiesLetter(char c)
        {
            galgje.VoegLetterToe(c);
        }
        public bool IsEindeSpel()
        {
           return  galgje.isEindeSpel();
        }
        public List<string> GetWoordAndFinalStatus()
        {
            var list = new List<string>();
            list.AddRange(new[] { galgje.GetWoord(), galgje.GetStatus() } );
            return list;
        }
        private void initializeData()
        {
            categoryRepo.AddCategorie(new Categorie("Muziek", "Muziek", 10, new List<string> { "gitaar", "piano", "sax" }));
            categoryRepo.AddCategorie(new Categorie("Boten", "Woorden over de scheepsvaart", 10, new List<string> { "wal", "stuurboord", "roer" }));
            categoryRepo.AddCategorie(new Categorie("Bedsport", "Woorden m.b.t. uw bed", 10, new List<string> { "kussen", "deken", "sex" }));
        }
    }
}