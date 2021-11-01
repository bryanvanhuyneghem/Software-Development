using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TekenProject.Pattern.Command
{
    public class ControlCommand : ADoubleKeyCommand
    {
        public ControlCommand(Helper helper, MainWindow window) : base(helper, window)
        {
        }

        public override void Execute(Key secondkey)
        {
            if (secondkey == Key.Z)
            {
                helper.RemoveLast();
                helper.Draw(window.canvas);
            }
        }
    }
}
