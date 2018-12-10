using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class StrategyFurnace : Strategy
    {
        private static StrategyFurnace Instance = new StrategyFurnace();
        public static StrategyFurnace GetInstance()
        {
            return Instance;
        }

        private StrategyFurnace()
        {

        }

        private void InitFurnace(IActor furnace, List<IActor> all)
        {
            List<IActor> allCounters = all.Where(a => a.Name == "counter").ToList();
            foreach (IActor a in allCounters)
            {
                a.EventGeneric += furnace.StrategyCallback;
            }
            furnace.Initialized = true;
        }

        public override void Behavior(IActor self, List<IActor> all)
        {
            if (!self.Initialized) InitFurnace(self, all);

            if (self.Stack.Count > 0)
            {
                Console.WriteLine("Chef: I must complete {0} more orders.", self.Stack.Count);
                Order topOrder = (Order)self.Stack[0];
                List<IActor> partyLeaders = all.Where(a => a.Name == "partyleader").ToList();

                if (topOrder.Completed())
                {
                    Console.WriteLine("Chef has completed an order");
                    // Fire an event or something
                    self.Stack.RemoveAt(0);
                }
                else
                {
                    // We look for non-completed step, and assign it to a party leader
                    foreach (Dish d in topOrder.DishInstances.ToList())
                    {
                        foreach (Step s in d.Steps.ToList())
                        {
                            if (!s.Prepared)
                            {
                                foreach (IActor a in partyLeaders)
                                {
                                    if (!a.Busy)
                                    {
                                        a.Stack.Add(s);
                                        a.Busy = true;
                                        Console.WriteLine("Chef has dispatched a step");
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

        public override void ReactToEvent(IActor self, MyEventArgs args)
        {
            switch (args.EventName)
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
