using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekenProject.Pattern.Command
{
    public abstract class ADoubleKeyCommand : NoCommand
    {
        public ADoubleKeyCommand(Helper helper, MainWindow window) : base(helper, window)
        {
        }

        public override int NumberKeys => 2;

    }
}
