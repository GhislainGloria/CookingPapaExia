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

		private bool HasEverythingNeededToCook(AbstractActor self, Step step, List<AbstractActor> all)
		{
			try
			{            
				AbstractActor nearest = self.FindClosest(step.Model.Workboard, all);
				bool hasUtensil = self.Items.Where(i => i.Name == step.Model.Utensil && i.Clean).ToList().Count > 0;
				bool hasIngredient = self.Items.Where(i => i.Name == step.Model.Ingredient).ToList().Count > 0;

				return self.EvaluateDistanceTo(nearest) <= 2 && hasUtensil && hasIngredient;            
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return false;
			}
		}

		public override void Behavior(AbstractActor self, List<AbstractActor> all)
		{         
			// In the stack, there is the current step to execute
			if(self.Stack.Count > 0)
			{
				if(self.Stack.Count == 1)
				{
					// At this point, we know self just received the order, but didn't ask anything
					// Stack[0] -> the step to finish
					// Stack[1] -> PL has ordered the utensil
					// Stack[2] -> PL has ordered the ingredient

					self.Stack.Add(false); // Stack[1]
					self.Stack.Add(false); // Stack[2]
				}

				self.Busy = true;
				Step step = (Step)self.Stack[0];
                
				// Check if we:
                //  Don't have ordered an utensil
                //  Don't have the utensil in the inventory
                // If this applies, then order the utensil
				if(!(bool)self.Stack[1] && self.Items.Where(i => i.Name == step.Model.Utensil).ToList().Count == 0)
				{
					List<AbstractActor> kc = all.Where(a => a.Name == "kitchenclerk" && !a.Busy).ToList();
					foreach(AbstractActor a in kc)
					{                  
						AbstractActor target = a.FindNearestCarriableItem(step.Model.Utensil, all);
						if(target != null)
						{
							Console.WriteLine(self + ": I asked " + a + " to fetch me a " + step.Model.Utensil);

							a.Busy = true;
							a.AcceptItemExchange = false;
							a.CommandList.Add(new CommandSetTarget(a, target));
							a.CommandList.Add(new CommandMove(a));
							a.CommandList.Add(new CommandGetItem(a, target, step.Model.Utensil));
							a.CommandList.Add(new CommandSetTarget(a, self));
							a.CommandList.Add(new CommandMove(a));
							a.CommandList.Add(new CommandGiveItem(a, self, step.Model.Utensil));
							a.CommandList.Add(new CommandSetAvailable(a));

                            // We want to know if the clerk failed
							a.EventGeneric += self.StrategyCallback;
							self.Stack[1] = true;
							break;
						}
					}
				}

				// Check if we:
                //  Don't have ordered the ingredient
                //  Don't have the ingredient in the inventory
                // If this applies, then order the ingredient
				if (!(bool)self.Stack[2] && self.Items.Where(i => i.Name == step.Model.Ingredient).ToList().Count == 0)
                {
					List<AbstractActor> kc = all.Where(a => a.Name == "kitchenclerk" && !a.Busy).ToList();
                    foreach (AbstractActor a in kc)
                    {
						AbstractActor target = a.FindNearestCarriableItem(step.Model.Ingredient, all);
                        if (target != null)
                        {
							Console.WriteLine(self + ": I asked " + a + " to fetch me a " + step.Model.Ingredient);

							a.Busy = true;
							a.AcceptItemExchange = false;
                            a.CommandList.Add(new CommandSetTarget(a, target));
                            a.CommandList.Add(new CommandMove(a));
							a.CommandList.Add(new CommandGetItem(a, target, step.Model.Ingredient));
                            a.CommandList.Add(new CommandSetTarget(a, self));
                            a.CommandList.Add(new CommandMove(a));
							a.CommandList.Add(new CommandGiveItem(a, self, step.Model.Ingredient));
							a.CommandList.Add(new CommandSetAvailable(a));

                            // We want to know if the clerk failed
                            a.EventGeneric += self.StrategyCallback;
							self.Stack[2] = true;
							break;
                        }
                    }
                }

                // Get to the workbench
				if(self.BusyWalking)
				{
					if(self.CommandList.Count > 0)
					{
						self.CommandList[0].Execute();
						if(self.CommandList[0].IsCompleted)
						{
							self.CommandList.RemoveAt(0);
						}
					}
					else
					{
						Console.WriteLine("PL walking but no cmd? :thinking:");
					}
				}
				else
				{
					AbstractActor target = self.FindClosest(step.Model.Workboard, all);

					// If there's no closest, then fuck don't move, nothing can be done
					if(target == null)
					{
						return;
					}

					if(self.EvaluateDistanceTo(target) > 2)
					{
						self.BusyWalking = true;
						self.Target = target;
						self.CommandList.Add(new CommandMove(self));
						return;
					}
				}

                // If we have everything needed to cook, then let's cook
				if(HasEverythingNeededToCook(self, step, all))
				{
					self.AcceptItemExchange = false;
					step.TimeSpentSoFar++;
					Console.WriteLine(self + ": I've been cooking for {0} tick, {1} required", step.TimeSpentSoFar, step.Model.Duration);
                                   
					if(step.TimeSpentSoFar >= step.Model.Duration)
					{
						step.Complete();
                        Console.WriteLine("Party Leader: I completed a step");

                        // Delete the ingredient
						foreach(ACarriableItem i in self.Items)
						{
							if(i.Name == step.Model.Ingredient)
							{
								self.Items.Remove(i);
								break;
							}
						}

                        // Utensil isn't clean anymore
						foreach (ACarriableItem i in self.Items)
                        {
							if (i.Name == step.Model.Utensil)
                            {
								i.Clean = false;
                                break;
                            }
                        }

						self.Stack.Clear();
                        self.Busy = false;	
					}
				}
			}
			else
			{
				// The stack is empty, no more steps to process
				self.AcceptItemExchange = true;
				self.Busy = false;
			}

            // Whether we're busy or not, we can always ask the divers to wash our dirty utensils
			if (!self.BusyWaiting && self.Items.Where((i => !i.Clean)).ToList().Count > 0)
			{
				self.AcceptItemExchange = true;
				Console.WriteLine(self + ": I must find a diver to wash my utensils");
				foreach (AbstractActor a in all.Where(a => a.Name == "diver" && !a.Busy))
				{
					self.BusyWaiting = true;
					Console.WriteLine("Same " + self + ": Okay I found one!");
					AbstractActor dishwasher = a.FindClosest("dishwasher", all);
					a.Target = self;
					a.CommandList.Add(new CommandMove(a));
					a.CommandList.Add(new CommandGetItemsWhere(a, self, c => !c.Clean));
					a.CommandList.Add(new CommandCustomActorMod(self, s => s.BusyWaiting = false));
					a.CommandList.Add(new CommandSetTarget(a, dishwasher));
					a.CommandList.Add(new CommandMove(a));
					a.CommandList.Add(new CommandGiveItemsWhere(a, dishwasher, c => !c.Clean));
				}
			}
		}
        // => Behavior

        /**
         * React to events
         */
		public override void ReactToEvent(AbstractActor self, MyEventArgs args)
		{
			switch (args.EventName)
			{
				case "CommandQueueFailed":
					string missingItem = (string)args.Arg2;

					AbstractActor failureMan = ((AbstractActor)args.Arg);
					failureMan.EventGeneric -= self.StrategyCallback;

					Console.WriteLine(self + ": Fuck, my " + failureMan + " failed to get me a " + missingItem);

					if (self.Stack.Count == 3)
					{
						if (missingItem == ((Step)self.Stack[0]).Model.Ingredient)
						{
							Console.WriteLine(self + ": Nevermind, I'll ask for another one of this ingredient");
							self.Stack[2] = false;
						}
						else if (missingItem == ((Step)self.Stack[0]).Model.Utensil)
						{
							Console.WriteLine(self + ": Nevermind, I'll ask for another one of this utensil");
                            self.Stack[1] = false;
						}
						else
						{
							Console.WriteLine(self + ": But WTF, I don't need that anyway?? Pls fix or think");                     
						}
					}
					else
					{
						Console.WriteLine(self + ": But WTF I'm not initialized??");                  
					}

					break;
			}
		}
	}
}
