using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestandsbeheer.Pattern
{
    class CachingProxy : IFile
    {
        private string filename;
        private IFile file;
        // Static dictionary containing all cached files
        private static Dictionary<string, IFile> cachedFiles = new Dictionary<string, IFile>();

        // Afgeschermde constructor
        internal CachingProxy(string filename)
        {
            this.filename = filename;
        }

        public string Content
        {
            get
            {
                if(file == null)
                {
                    // Check to see if the file is already in the dictionary (== cached)
                    if (!cachedFiles.ContainsKey(filename))
                    {
                        // maak een nieuwe RealFile aan en voeg deze toe aan de dictionary
                        cachedFiles.Add(filename, new RealFile(filename));
                    }
                    // The file exists and is fetched from the dictionary
                    file = cachedFiles[filename];
                }
                return file.Content;
            }
        }
    }
}
