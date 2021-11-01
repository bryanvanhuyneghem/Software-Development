using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            Person p = new Student(Console.ReadLine(), 2013215);
            Console.WriteLine(p.WelcomeMessage);

            // instanceof Java -> is in C#

            if(p is Student)
            {
                Console.WriteLine(" - Is student");
            }
            else if (p is Person)
            {
                Console.WriteLine(" - Is Person");
            }

            // type (namespace and class name)
            Console.WriteLine("Type: " + p.GetType());

            Console.ReadKey();
        }
    }
}
