using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StrategyFurnace : Strategy
    {
        private static readonly StrategyFurnace Instance = new StrategyFurnace();
        public static StrategyFurnace GetInstance()
        {
            return Instance;
        }

        private StrategyFurnace()
        {

        }

        public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {

        }

        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {

        }
    }
}
