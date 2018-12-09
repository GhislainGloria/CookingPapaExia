using System;
using System.Collections.Generic;

namespace Model
{
	public class StrategyServerCounter : Strategy
    {
		protected static StrategyServerCounter Instance = new StrategyServerCounter();
		public static StrategyServerCounter GetInstance() { return Instance; }
		protected StrategyServerCounter() { }

		public override void Behavior(IActor self, List<IActor> all)
		{
			Order order = new Order();
			self.TriggerEvent("order received", order);
		}

		public override void ReactToEvent(IActor self, MyEventArgs args)
		{
			throw new NotImplementedException();
		}
	}
}
