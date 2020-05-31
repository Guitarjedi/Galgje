using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Galgje
{
    public class UI
    {
        private DomeinController controller;
        public UI()
        {
            controller = new DomeinController();
        }
        public void StartConsoleApp()
        {
            string categorieNaam;
            do
            {
                Console.WriteLine("Welkom bij galgje");
                Console.WriteLine("==================");
                Console.WriteLine();

                PrintPossibleCategories();

                Console.Write("Kies een categorie: ");
                categorieNaam = Console.ReadLine();
                Console.Clear();
            }
            while (!controller.GetCategories().Select(x => x).Select(x => x[0]).Contains(categorieNaam));

            controller.KiesCategorie(categorieNaam);

            do
            {
                PrintTitleGame(controller.GetWoordInfo());
                Console.Write("Kies een letter : ");
                var letters = Console.ReadLine().ToCharArray();
                controller.KiesLetter(letters[0]);
                Console.Clear();
            } while (!controller.IsEindeSpel());
            Console.WriteLine($"You have {controller.GetWoordAndFinalStatus()[1]}");
            Console.WriteLine($"The word was : {controller.GetWoordAndFinalStatus()[0]}");
            Console.WriteLine("=========================================================");

        }
        private void PrintPossibleCategories()
        {
             var cat = controller.GetCategories();
            foreach(var c in cat )
            {
                Console.WriteLine("Naam : " + c[0]);
                Console.WriteLine("Omschrijving : " + c[1]);
                Console.WriteLine("Moeilijkheidsgraad : " + c[2]);
                Console.WriteLine();
            }
        }
        private void PrintTitleGame(List<string> info)
        {
            Console.WriteLine("Aantal pogingen : "+ info[0]);
            Console.WriteLine("Gezochte letters : " + info[2]);
            Console.WriteLine("Woord : " + info[1]);
            Console.WriteLine("++++++++++++++++++++++++++++++++");
            Console.WriteLine();
        }
    }
}
