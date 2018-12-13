using System;
using System.Collections.Generic;

namespace Model
{
    public class StrategyCounterClient : Strategy
    {
		protected static StrategyCounterClient Instance = new StrategyCounterClient();
		public static StrategyCounterClient GetInstance() { return Instance; }
		protected StrategyCounterClient() { }

        public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {
			ActorSocket castedSelf = (ActorSocket)self;

            Random random = new Random();
            if (random.Next(0, 2) == 1)
            {
				castedSelf.SendToServer("Hello<EOF>");
            }
        }

        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
