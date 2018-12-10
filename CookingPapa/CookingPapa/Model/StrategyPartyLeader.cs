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
				if (self.BusyWaiting) return;
				if(self.Items.Where(i => i.Name == step.Model.Utensil).ToList().Count == 0)
				{
					List<IActor> kc = all.Where(a => a.Name == "kitchenclerk").ToList();
					foreach(IActor a in kc)
					{
						if(!a.Busy)
						{
							// TODO: find nearest carriable
							IActor target = a.FindClosest(step.Model.Utensil, all);
							if(target != null)
							{
								Console.WriteLine("Party Leader: I asked a clerk to fetch me a " + step.Model.Utensil);
								a.Target = target;
								self.BusyWaiting = true;
								return;
							}
						}
					}
				}


				if(step.TimeSpentSoFar++ >= step.Model.Duration)
				{
					step.Complete();
					Console.WriteLine("Party Leader: I completed a step");
					self.Stack.RemoveAt(0);
					self.Busy = false;
				}
			}
		}

		public override void ReactToEvent(IActor self, MyEventArgs args)
		{

		}
	}
}
