using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StrategyHeadWaiter : IStrategy
    {
        private static StrategyHeadWaiter Instance = new StrategyHeadWaiter();
        public static StrategyHeadWaiter GetInstance() { return Instance; }
        private StrategyHeadWaiter() { }

        public void Behavior(AbstractActor actor, List<AbstractActor> allActors)
        {
            throw new NotImplementedException();
        }

        public void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
