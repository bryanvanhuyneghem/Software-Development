using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TekenProject.Pattern.Command
{
    public class RCommand : NoCommand
    {
        public RCommand(Helper helper, MainWindow window) : base(helper, window)
        {
        }

        public override void Execute(Key key)
        {
            helper.ClearAll();
            helper.Draw(window.canvas);
        }

        public override int NumberKeys => 1; //direct uitvoeren
    }
}
