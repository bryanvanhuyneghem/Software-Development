using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bestandsbeheer.Pattern;

namespace Bestandsbeheer
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2 soorten users: een user en een admin
            Dictionary<string, User> users = new Dictionary<string, User>();
            users.Add("user", new User("user", false));
            users.Add("admin", new User("admin", true));

            // Username ingeven
            Console.WriteLine("Enter username:");
            string currentUser = Console.ReadLine();
            // Geldige username?
            while (!users.ContainsKey(currentUser))
            {
                Console.Out.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Out.Write("[ERR] ");
                Console.ResetColor();
                Console.Out.WriteLine("User not found. Please enter a valid username.");
                currentUser = Console.ReadLine();
            }

            // Open bestand
            Console.WriteLine("Enter file name or STOP to exit");
            string filename = Console.ReadLine();
            while(filename != "STOP")
            {
                try
                {
                    string fileContent = new AccessProxy(users[currentUser], filename).Content;
                    Console.Out.WriteLine();
                    Console.WriteLine("====== " + filename + " ======");
                    Console.WriteLine(fileContent);
                    Console.WriteLine("============================");
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Out.Write("[ERR] ");
                    Console.ResetColor();
                    Console.Out.WriteLine(e.Message);
                }
                Console.WriteLine();
                Console.WriteLine("Enter a file name or STOP to exit");
                filename = Console.ReadLine();
            }   // indien STOP ingegeven wordt dan wordt de while-loop beëindigd
                // en stopt het programma.
        }
    }
}
