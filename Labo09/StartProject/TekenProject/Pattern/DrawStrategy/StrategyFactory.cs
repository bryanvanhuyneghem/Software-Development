using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TekenProject.Pattern.DrawStrategy
{
    public class StrategyFactory
    {
        private Dictionary<int, IStrategy> strategies = new Dictionary<int, IStrategy>();

        public StrategyFactory(Helper helper, Canvas canvas)
        {
            strategies.Add(1, new PointStrategy(helper, canvas));
            strategies.Add(2, new LineStrategy(helper, canvas));
            strategies.Add(3, new RectangleStrategy(helper, canvas));
            strategies.Add(4, new EllipsStrategy(helper, canvas));
        }

        public IStrategy this[int nr]
        {
            get
            {
                if (strategies.ContainsKey(nr))
                {
                    return strategies[nr];
                }
                else
                {
                    return strategies[2]; // lijn
                }
            }
        }
    }
}
