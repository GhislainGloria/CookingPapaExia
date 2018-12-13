using System.Collections.Generic;
using System.Linq;
using System;

namespace Model
{
	public class StrategyChef : Strategy
    {
		private static readonly StrategyChef Instance = new StrategyChef();
		public static StrategyChef GetInstance()
		{
			return Instance;
		}

		private StrategyChef() {}

		public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {
            lock (self.Stack)
            {
                if (self.Stack.Count > 0)
                {
                    Console.WriteLine(self + ": I must complete {0} more orders.", self.Stack.Count);
                    List<AbstractActor> partyLeaders = all.Where(a => a.Name == "partyleader").ToList();

                    foreach (Order o in self.Stack.ToList())
                    {
                        if (o.Completed())
                        {
                            Console.WriteLine(self + ": I completed an order");
                            // TODO Fire an event or something
                            self.Stack.Remove(o);
                        }
                        else
                        {
                            // We look for non-completed step, and assign it to a party leader
                            foreach (Dish d in o.DishInstances.ToList())
                            {
                                foreach (Step s in d.Steps.ToList())
                                {
                                    if (!s.Prepared && !s.Assigned)
                                    {
                                        foreach (AbstractActor a in partyLeaders)
                                        {
                                            if (!a.Busy)
                                            {
                                                s.Assigned = true;
                                                a.Stack.Add(s);
                                                a.Busy = true;
                                                Console.WriteLine(self + ": I dispatched a step to " + a);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            // end foreach nest
                        }
                    }
                }
            }
        }

		public override void ReactToEvent(AbstractActor self, MyEventArgs args)
		{
			switch(args.EventName)
			{
				case "order received":
					// Ici on ajoute la nouvelle Order (avec args.Arg) dans la liste
					// des trucs à faire du chef. Le process se fera par la suite
					// dans Behavior()
					self.Stack.Add(args.Arg);
					break;
			}
		}
	}
}
