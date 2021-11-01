using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TekenProject.Pattern.Command
{
    public class MCommand : ADoubleKeyCommand
    {
        public MCommand(Helper helper, MainWindow window) : base(helper, window)
        {
        }

        public override void Execute(Key secondkey)
        {
            int selected = secondkey - Key.D0; // nummeren vanaf 1
            window.SetStrategy(selected);
        }
    }
}
