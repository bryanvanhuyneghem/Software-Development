using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestandsbeheer.Pattern
{
    public class AccessProxy : IFile
    {
        private User user;
        private string filename;
        private IFile file;

        public AccessProxy(User user, string filename)
        {
            this.user = user;
            this.filename = filename;
        }

        public string Content
        {
            get
            {
                if (filename.StartsWith(".") && !user.IsAdmin)
                {
                    throw new FileAccessException("User '" + user.Username + "' has no access to this file.");
                }
                // om aan caching te kunnen doen; anders gebruik je gewoon RealFile
                if (file == null)
                {
                    file = new CachingProxy(filename);
                }
                return file.Content;
            }
        }
    }
}
