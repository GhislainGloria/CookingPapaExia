using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class StrategyTable : Strategy
    {

		private static readonly StrategyTable Instance = new StrategyTable();
        public static StrategyTable GetInstance()
        {
            return Instance;
        }

        private StrategyTable() { }
		private const int TIME_TO_EAT_TMP = 10;

        /**
         * Stack[0] : Time clients have sit to the table since the order was delivered
         */
        public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {
			Table castedSelf = (Table)self;
            foreach (Order order in self.Items.ToList())
            {
				int timeSpentEating = (int)self.Stack[0];
				self.Stack[0] = timeSpentEating + 1;
				if (timeSpentEating > TIME_TO_EAT_TMP)
                {
					AbstractActor exitActor = self.FindClosest("clientspawner", all);
					GroupActor group = castedSelf.Grp;
					self.Items.Remove(order);
					self.Stack[0] = 0;
					castedSelf.RemoveGroupActor();

					group.CommandList.Add(new CommandSetTarget(group, exitActor));
					group.CommandList.Add(new CommandMove(group));
					group.CommandList.Add(new CommandRemoveFromWorld(group, all));
                    
					Console.WriteLine(self + ": My group of clients are done.");
                }
				else
				{
					Console.WriteLine(self + ": My clients have been eating for " + (int)self.Stack[0]);
				}
            }
        }

        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
