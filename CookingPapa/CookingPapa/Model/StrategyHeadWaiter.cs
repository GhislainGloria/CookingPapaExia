using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StrategyHeadWaiter : Strategy
    {
        private static readonly StrategyHeadWaiter Instance = new StrategyHeadWaiter();
        public static StrategyHeadWaiter GetInstance()
        {
            return Instance;
        }
        public StrategyHeadWaiter() { }

        public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {
           
        }

        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
            switch (args.EventName)
            {
                
            }
        }
    }
}
