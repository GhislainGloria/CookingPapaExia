using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StrategyFurnace : Strategy
    {
        private static StrategyFurnace Instance = new StrategyFurnace();
        public static StrategyFurnace GetInstance()
        {
            return Instance;
        }

        private StrategyFurnace()
        {

        }

        private void InitFurnace(AbstractActor furnace, List<AbstractActor> all)
        {
<<<<<<< HEAD
=======
            List<AbstractActor> allCounters = all.Where(a => a.Name == "counter").ToList();
            foreach (AbstractActor a in allCounters)
            {
                a.EventGeneric += furnace.StrategyCallback;
            }
>>>>>>> origin/master
            furnace.Initialized = true;
            Console.WriteLine("Furnace Init");
        }

        public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {
            if (!self.Initialized) InitFurnace(self, all);

<<<<<<< HEAD
        //Item contient les ingredients
        //Stack contient les etapes
=======
            if (self.Stack.Count > 0)
            {
                Console.WriteLine("Chef: I must complete {0} more orders.", self.Stack.Count);
                Order topOrder = (Order)self.Stack[0];
                List<AbstractActor> partyLeaders = all.Where(a => a.Name == "partyleader").ToList();
>>>>>>> origin/master

            if (self.Items.Count == 1 && self.Stack.Count == 1)
            {
                Ingredient ingredient = (Ingredient)self.Items[0];
                Step step = (Step)self.Stack[0];
                
                if (step.TimeSpentSoFar == 0)
                {
                    self.Busy = true;
                    Console.WriteLine("Furnace On");
                }
                step.TimeSpentSoFar++;
                if (step.TimeSpentSoFar >= step.TimeNeed)
                {
<<<<<<< HEAD
                    self.Busy = false;
                    Console.WriteLine("Furnace Off");

                    self.TriggerEvent("Dring", all);

                    self.Items.Clear();
                    self.Stack.Clear();
                }

                
=======
                    // We look for non-completed step, and assign it to a party leader
                    foreach (Dish d in topOrder.DishInstances.ToList())
                    {
                        foreach (Step s in d.Steps.ToList())
                        {
                            if (!s.Prepared)
                            {
                                foreach (AbstractActor a in partyLeaders)
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
>>>>>>> origin/master
                    // end foreach nest
                }
            }

        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
