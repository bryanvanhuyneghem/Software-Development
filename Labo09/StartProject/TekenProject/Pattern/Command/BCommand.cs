using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TekenProject.Pattern.Command
{
    public class BCommand : ADoubleKeyCommand
    {
        public BCommand(Helper helper, MainWindow window) : base(helper, window)
        {
        }

        public override void Execute(Key secondkey)
        {
            helper.StrokeNr = secondkey - Key.D0; // nummer ingegeven
            window.brushFill.Color = helper.StrokeColor.Color;
        }
    }
}
