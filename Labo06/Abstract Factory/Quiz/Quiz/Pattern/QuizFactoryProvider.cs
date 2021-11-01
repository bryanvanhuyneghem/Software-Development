using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pattern
{
    public class QuizFactoryProvider
    {
        // beschikbare Types //
        public static string[] inputTypes = { "csv", "txt" };
        private IList<ICategory> categories;

        private Dictionary<ICategory, IQuizFactory> factories;
        private string type;

        public QuizFactoryProvider(string type)
        {
            this.type = type;
            factories = new Dictionary<ICategory, IQuizFactory>();
            //kan ook volledig in deze klasse uitgewerkt worden.
            if (type.Equals(inputTypes[0])) // csv
            {
                Categories = CSVCategoryFactory.Categories;
            }
            else if (type.Equals(inputTypes[1])) // txt
            {
                Categories = TXTCategoryFactory.Categories;
            }
        }

        public IQuizFactory this[ICategory cat]
        {
            get
            {
                if (!factories.ContainsKey(cat)) // als hij nog niet bestaat
                {
                    // de factory in de dictionary aanmaken aan de hand van de categorie
                    if (type.Equals(inputTypes[0])) // txt
                    {
                        factories[cat] = new CSVQuizFactory(cat);
                    }
                    else if (type.Equals(inputTypes[1])) // csv
                    {
                        factories[cat] = new TXTQuizFactory(cat);
                    }
                }
                return factories[cat];
            }
        }

        public IList<ICategory> Categories { get => categories; set => categories = value; }
    }
}
