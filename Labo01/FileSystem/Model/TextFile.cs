using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystem.Model
{
    public class TextFile : File
    {
        string content;

        public TextFile(string name, string content) : base(name)
        {
            this.Content = content;
        }

        public string Content { get => this.content; set => this.content = value; }

        public override string ListName { get => this.Name; }
    }
}
