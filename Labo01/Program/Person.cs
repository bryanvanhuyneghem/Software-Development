using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    abstract class Person
    {
        string name; // default access is private

        public Person(string name)
        {
            this.name = name;
        }

        // Read-only Property
        public string Name { get => name; }

        // Read-only Property [virtual]
        public virtual string WelcomeMessage { get => "Hello " + name; }
    }
}
