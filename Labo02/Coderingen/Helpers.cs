using Coderingen.Pattern;

namespace Coderingen
{
    public class Helpers
    {

        // Netjes:
        /// <summary>
        /// Hulpmethode om meerdere coderingen na elkaar uit te voeren op een gegeven component
        /// </summary>
        /// <param name="coderingen"></param>
        /// <param name="types">de verschillenden coderingen, gescheiden door een spatie (bv. blok wissel blok)</param>
        /// <returns>Het resultaat van de verschillende coderingen</returns>

        // Basic:
        // Hulpmethode om meerdere coderingen na elkaar uit te voeren op een gegeven component
        // De verschillenden coderingen, gescheiden door een spatie (bv. blok wissel blok)
        // Het resultaat van de verschillende coderingen
        public static ICodering MeerdereCoderingen(ICodering codering, string coderingen)
        {
            if (coderingen != null)
            {
                // verschillende coderingen toepassen
                string[] types = coderingen.Split(' ');
                foreach (string type in types)
                {
                    // type blok
                    if (type == "blok")
                    {
                        codering = new BlokCodering(codering);
                    }
                    // type wissel
                    else if (type == "wissel")
                    {
                        codering = new WisselCodering(codering);
                    }
                    // type cijfer
                    else
                    {
                        codering = new CijferCodering(codering);
                    }
                }
            }
            return codering;
        }

    }
}
