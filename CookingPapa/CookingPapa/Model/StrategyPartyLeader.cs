using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	class StrategyPartyLeader : Strategy
	{
		private static StrategyPartyLeader Instance = new StrategyPartyLeader();
        public static StrategyPartyLeader GetInstance()
        {
            return Instance;
        }      
        private StrategyPartyLeader() {} 

		public override void Behavior(IActor self, List<IActor> all)
		{
			if(self.Stack.Count > 0)
			{
				Console.WriteLine("Party Leader: I'm busy");
				self.Busy = true;
				Step step = (Step)self.Stack[0];
				//TODO ask for required utensils and ingredients
				if(step.TimeSpentSoFar++ >= step.Model.Duration)
				{
					step.Complete();
					Console.WriteLine("Party Leader: I completed a step");
					self.Busy = false;
				}
			}
		}

		public override void ReactToEvent(IActor self, MyEventArgs args)
		{

		}
	}
}
