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

		public override void Behavior(AbstractActor self, List<AbstractActor> all)
		{         
			// In the stack, there is the current step to execute
			if(self.Stack.Count > 0)
			{
				if (self.BusyWaiting) return;
                
				self.Busy = true;
				Step step = (Step)self.Stack[0];
                
				if(self.Items.Where(i => i.Name == step.Model.Utensil).ToList().Count == 0)
				{
					List<AbstractActor> kc = all.Where(a => a.Name == "kitchenclerk").ToList();
					foreach(AbstractActor a in kc)
					{
						if(!a.Busy)
						{                     
							AbstractActor target = a.FindNearestCarriableItem(step.Model.Utensil, all);
							if(target != null)
							{
								Console.WriteLine("Party Leader: I asked a clerk to fetch me a " + step.Model.Utensil);

								a.CommandList.Add(new CommandSetTarget(a, target));
								a.CommandList.Add(new CommandMove(a));
								a.CommandList.Add(new CommandGetItem(a, target, step.Model.Utensil));
								a.CommandList.Add(new CommandSetTarget(a, self));
								a.CommandList.Add(new CommandMove(a));

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

		public override void ReactToEvent(AbstractActor self, MyEventArgs args)
		{

		}
	}
}
