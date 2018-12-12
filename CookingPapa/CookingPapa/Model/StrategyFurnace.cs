using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StrategyWorkingFridge : Strategy
    {
        private static readonly StrategyWorkingFridge Instance = new StrategyWorkingFridge();
        public static StrategyWorkingFridge GetInstance()
        {
            return Instance;
        }

        private StrategyWorkingFridge()
        {

        }

        private void InitFurnace(AbstractActor furnace, List<AbstractActor> all)
        {

            furnace.Initialized = true;
        }

        public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {
            if (!self.Initialized) InitFurnace(self, all);         

            //Item contient les ingredients
            //Stack contient les etapes         
            if (self.Items.Count == 1 && self.Stack.Count == 1)
            {
                Ingredient ingredient = (Ingredient)self.Items[0];
                Step step = (Step)self.Stack[0];
                List<AbstractActor> partyLeaders = all.Where(a => a.Name == "partyleader").ToList();

                if (step.TimeSpentSoFar == 0)
                {
                    self.Busy = true;
                    Console.WriteLine("Furnace On");
                }
                step.TimeSpentSoFar++;

			    if (step.TimeSpentSoFar >= step.Model.Duration)
                {

                    self.Busy = false;
                    Console.WriteLine("Furnace Off");

                    
                    self.TriggerEvent("Dring", partyLeaders);

                    self.Items.Clear();
                    self.Stack.Clear();
                }
            }
        }

        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
