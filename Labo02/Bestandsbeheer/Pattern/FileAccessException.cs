using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestandsbeheer.Pattern
{
    class FileAccessException : Exception
    {
        public FileAccessException(string message) : base(message)
        {
        }
    }
}
