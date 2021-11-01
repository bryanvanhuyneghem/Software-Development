using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Model
{
    public class FileSystemException : Exception
    {
        public FileSystemException(string message) : base(message)
        {
        }
    }
}
