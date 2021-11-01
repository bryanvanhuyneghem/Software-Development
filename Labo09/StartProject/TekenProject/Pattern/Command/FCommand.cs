using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TekenProject.Pattern.Command
{
    public class FCommand : ADoubleKeyCommand
    {
        public FCommand(Helper helper, MainWindow window) : base(helper, window)
        {
        }

        public override void Execute(Key secondkey)
        {
            helper.FillNr = secondkey - Key.D0; // nummer ingegeven
            window.brushStroke.Color = helper.FillColor.Color;
        }
    }
}
