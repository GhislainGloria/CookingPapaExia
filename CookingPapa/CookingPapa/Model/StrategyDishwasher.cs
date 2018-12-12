using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	class StrategyDishwasher : Strategy
	{
        private static readonly StrategyDishwasher Instance = new StrategyDishwasher();
        private int TimeSpentWashing;
		private readonly int TIME_TO_WASH_ALL = 10;

        public static StrategyDishwasher GetInstance()
        {
            return Instance;
        }

        private StrategyDishwasher()
        {

        }

        public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {         
			if (TimeSpentWashing == 0 && self.Items.Count >= 5)
            {
				TimeSpentWashing++;
				self.Busy = true;
				self.AcceptItemExchange = false;
            }

			if(TimeSpentWashing++ >= TIME_TO_WASH_ALL)
			{
				TimeSpentWashing = 0;
				self.Busy = true;
				self.AcceptItemExchange = true;

				self.Items.ForEach(i => i.Clean = true);
			}         
        }

        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {

        }
    }
}
