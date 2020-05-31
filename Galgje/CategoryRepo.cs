using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Galgje
{
    class CategoryRepo
    {
        private List<Categorie> categories = new List<Categorie>();

        public List<List<string>> GetAllCategories()
        {
            var listCategories = new List<List<string>>();
            foreach(var c in categories)
            {
                var listCategory = new List<string>();
                listCategory.AddRange(new[] { c.GetNaam(),c.GetOmschrijving(),c.GetMoeilijkheidsGraad().ToString() });
                listCategories.Add(listCategory);
            }
            return listCategories;
        }
        public Categorie GetCategorie(string naam)
        {
            var cat =  categories.Where(c => c.GetNaam() == naam).FirstOrDefault();
            if (cat == null)
                throw new Exception("The category is not found");
            return cat;
        }
        public void AddCategorie(Categorie c)
        {
            categories.Add(c);
        }

    }
}
