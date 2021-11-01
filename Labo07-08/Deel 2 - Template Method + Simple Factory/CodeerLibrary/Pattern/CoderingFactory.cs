using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeerLibrary.Pattern
{
    // Deze klasse is optioneel
    public class CoderingFactory
    {
        private Dictionary<String, ICodering> factory = new Dictionary<string, ICodering>();

        public CoderingFactory()
        {
            factory.Add("blok", new BlokCodering());
            factory.Add("wissel", new WisselCodering());
            factory.Add("cijfer", new CijferCodering());
        }

        public ICodering this[string type]
        {
            get
            {
                if (!factory.ContainsKey(type))
                {
                    type = "cijfer"; //  default codering
                }
                return factory[type];
            }
        }
    }
}
