using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Model
{
    public abstract class File
    {
        string name;
        Folder parent;

        public File(string name)
        {
            if (name == null)
            {
                throw new FileSystemException("Name can't be null!");
            }
            if (name.Contains("/"))
            {
                throw new FileSystemException("Name can't contain '/'!");
            }
            this.Name = name;
            this.parent = null;
        }

        // Properties

        public Folder Parent { get => parent; set => this.parent = value; }

        public string Name { get => name; set => this.name = value; }

        public bool IsRoot { get => this.parent == null; } // als de parent null is, dan is hij de root

        public string PathName
        {
            get
            {
                if (this.IsRoot)
                    return this.Name;
                else
                    return this.parent.PathName + "/" + this.Name;
            }
        }

        public abstract string ListName
        {
            get;
        }

        // Print the Tree [virtual]
        public virtual void PrintTree(int indent)
        {
            for(int i = 0; i < indent; i++)
            {
                Console.WriteLine(" ");
            }
            Console.WriteLine(this.ListName);
        }
         

    }
}
