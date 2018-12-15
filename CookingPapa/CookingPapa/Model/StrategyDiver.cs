using System.Linq;
using System.Collections.Generic;

namespace Model
{
    class StrategyDiver : Strategy
    {
		private static readonly StrategyDiver Instance = new StrategyDiver();
		public static StrategyDiver GetInstance() { return Instance; }
		private StrategyDiver() {}

		public override void Behavior(AbstractActor self, List<AbstractActor> all)
		{
			if (self.CommandList.Count > 0)
            {
                self.Busy = true;

                if (self.CommandList[0].IsCompleted)
                {
                    self.CommandList.RemoveAt(0);
                }
                else
                {
                    self.CommandList[0].Execute();
                }
            }
            else
            {
				ActorSocket counter = (ActorSocket)self.FindClosest("counter", all);
				foreach(ACarriableItem i in counter?.Items.Where(ii => !ii.Clean && ii.Name != "order").ToList())
				{
					AbstractActor dishwasher = self.FindClosest("dishwasher", all);
					self.Target = counter;
					self.CommandList.Add(new CommandMove(self));
					self.CommandList.Add(new CommandGetItemsWhere(self, counter, d => !d.Clean && d.Name != "order"));
					self.CommandList.Add(new CommandSetTarget(self, dishwasher));
					self.CommandList.Add(new CommandMove(self));
					self.CommandList.Add(new CommandGiveItemsWhere(self, dishwasher, d => !d.Clean));
					self.CommandList.Add(new CommandSetAvailable(self, true, true, true, true));
					return;
				}
                self.Busy = false;
            }
		}

		public override void ReactToEvent(AbstractActor self, MyEventArgs args)
		{
			throw new System.NotImplementedException();
		}
	}
}
