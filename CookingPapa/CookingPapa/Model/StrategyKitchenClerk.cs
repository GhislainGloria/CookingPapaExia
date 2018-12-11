using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class StrategyKitchenClerk : Strategy
	{
        private static StrategyKitchenClerk Instance = new StrategyKitchenClerk();
        public static StrategyKitchenClerk GetInstance()
        {
            return Instance;
        }

        private StrategyKitchenClerk() { }

        public override void Behavior(AbstractActor self, List<AbstractActor> all)
		{
			if(self.CommandList.Count > 0)
			{
				if(self.CommandList[0].IsCompleted)
				{
					self.CommandList.RemoveAt(0);
				}
				else
				{
					self.CommandList[0].Execute();
				}
			}
		}

		public override void ReactToEvent(AbstractActor self, MyEventArgs args)
		{

		}
	}
}
