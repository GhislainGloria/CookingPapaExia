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

        private void InitFurnace(IActor furnace, List<IActor> all)
        {
            furnace.Initialized = true;
            Console.WriteLine("Furnace Init");
        }

        public override void Behavior(IActor self, List<IActor> all)
        {
            if (!self.Initialized) InitFurnace(self, all);

        //Item contient les ingredients
        //Stack contient les etapes

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
                    self.Busy = false;
                    Console.WriteLine("Furnace Off");

                    self.TriggerEvent("Dring", all);

                    self.Items.Clear();
                    self.Stack.Clear();
                }

                
                    // end foreach nest
                }
            }

        public override void ReactToEvent(IActor self, MyEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
