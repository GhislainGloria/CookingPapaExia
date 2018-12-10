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

        public override void Behavior(IActor self, List<IActor> all)
		{

		}

		public override void ReactToEvent(IActor self, MyEventArgs args)
		{

		}
	}
}
