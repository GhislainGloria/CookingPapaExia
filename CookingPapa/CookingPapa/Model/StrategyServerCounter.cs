using System;
using System.Collections.Generic;

namespace Model
{
	public class StrategyServerCounter : Strategy
    {
		protected static StrategyServerCounter Instance = new StrategyServerCounter();
		public static StrategyServerCounter GetInstance() { return Instance; }
		protected StrategyServerCounter() { }

		public override void Behavior(AbstractActor self, List<AbstractActor> all)
		{
			Random random = new Random();
			if(random.Next(0, 2) == 1)
			{
				Table table = new Table(10);
                Order order = new Order(table, DishModelList.GetAvailableDishes());
                self.TriggerEvent("order received", order);
			}
		}

		public override void ReactToEvent(AbstractActor self, MyEventArgs args)
		{
			throw new NotImplementedException();
		}
	}
}
