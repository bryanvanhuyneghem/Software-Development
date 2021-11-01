using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Model
{
    public class FileSystem
    {
        Folder root;
        Folder currentFolder;

        public FileSystem()
        {
            root = new Folder("");
            currentFolder = root;
        }

        public void cd(string path)
        {
            if (path.Equals("/"))
                currentFolder = root;
            else if (path.Equals(".."))
                if (!currentFolder.IsRoot)
                    currentFolder = currentFolder.Parent;
                else
                    Console.WriteLine("Ongeldig pad");
            else
            {
                File f = currentFolder.GetFile(path);
                if (f is Folder)
                    currentFolder = (Folder)f;
                else
                    Console.WriteLine("Ongeldig pad");
            }
        }

        public void pwd() // print working directory
        {
            Console.WriteLine(currentFolder.PathName);
        }

        public void dir()
        {
            currentFolder.PrintList();
        }

        public void tree()
        {
            currentFolder.PrintTree(0);
        }

        public void mktext(string name)
        {
            try
            {
                currentFolder.CreateTextFile(name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void mkdir(string name)
        {
            try
            {
                currentFolder.CreateFolder(name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
