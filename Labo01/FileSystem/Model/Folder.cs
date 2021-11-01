using System;
using System.Collections.Generic;

namespace FileSystem.Model
{
    public class Folder : File
    {
        HashSet<File> files;

        public Folder(string name) : base(name)
        {
            this.files = new HashSet<File>();
        }

        public File GetFile(string name)
        {
            File retValue = null;
            foreach (File temp in files)
            {
                if (temp.Name.Equals(name))
                    retValue = temp;
            }
            return retValue;
        }

        public TextFile CreateTextFile(string name)
        {
            this.CheckName(name);
            TextFile t = new TextFile(name, "");
            this.AddFile(t);
            return t;
        }

        public Folder CreateFolder(string name)
        {
            this.CheckName(name);
            Folder f = new Folder(name);
            this.AddFile(f);
            return f;
        }


        private void CheckName(string name)
        {
            if (name == "")
                throw new FileSystemException("Lege naam niet toegelaten");
            if (this.GetFile(name) != null)
                throw new FileSystemException("Map bevat al bestand met naam '" + name + "'");
        }

        private void AddFile(File file)
        {
            files.Add(file);
            file.Parent = this; // Niet vergeten!
        }

        public override string ListName
        {
            get => this.Name + '/';
        }

        public void PrintList()
        {
            foreach(File temp in files)
            {
                Console.WriteLine(temp.ListName);
            }
        }

        public override void PrintTree(int indent)
        {
            base.PrintTree(indent);
            foreach(File temp in files)
            {
                temp.PrintTree(indent + 1);
            }
        }

        // Extra
        public File this[string name]
        {
            get => GetFile(name);
        }
    }
}