using System;
using System.Collections.Generic;

namespace Model
{
	/**
	 * This is a strategy for container objects. It does nothing.
	 */
    public class StrategyIdle : Strategy
    {
		private static StrategyIdle Instance = new StrategyIdle();
		public static StrategyIdle GetInstance() { return Instance; }
		private StrategyIdle() {}

  		public override void Behavior(AbstractActor self, List<AbstractActor> all)
		{
		}

		public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
        }
    }
}
