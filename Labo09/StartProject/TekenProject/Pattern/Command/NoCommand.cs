using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TekenProject.Pattern.Command
{
    public class NoCommand : ICommand
    {
        protected Helper helper;
        protected MainWindow window;

        public NoCommand(Helper helper, MainWindow window)
        {
            this.helper = helper;
            this.window = window;
        }

        public virtual void Execute(Key key)
        {

        }

        public virtual int NumberKeys => 0;

        public virtual bool SimpleCommand()
        {
            return false; // meestal dubbele sleutel
        }
    }
}
