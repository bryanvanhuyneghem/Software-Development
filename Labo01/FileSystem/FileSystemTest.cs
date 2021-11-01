using System;

namespace FileSystem
{
    class FileSystemTest
    {
        static void Main(string[] args)
        {
            FileSystem.Model.FileSystem bs = new FileSystem.Model.FileSystem();

            bs.mktext("tekst1");
            bs.mktext("");
            bs.mkdir("map1");
            bs.dir();
            bs.cd("map1");
            bs.mkdir("map2");
            bs.cd("map2");
            bs.mktext("tekst2");
            bs.mkdir("tekst2");
            bs.dir();
            bs.cd("tekst2");
            bs.cd("..");
            bs.tree();
            bs.cd("/");
            bs.tree();

            Console.ReadKey(); // Verwijder commentaar zodat het venster niet automatisch sluit
        }
    }
}

