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
        private int washing;

        public static StrategyDishwasher GetInstance()
        {
            return Instance;
        }

        private StrategyDishwasher()
        {

        }

        private void InitDishwasher(AbstractActor self, List<AbstractActor> all)
        {

            self.Initialized = true;

            Console.WriteLine("Dishwasher Init");
        }

        public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {
            if (!self.Initialized) InitDishwasher(self, all);

            if (self.Items == null)
            {
                washing = 15 * 60;
                self.Busy = false;
            }


            if (self.Items != null && self.Stack != null)
            {

                self.Busy = true;
                washing--;

                if (washing == 0)
                {
                    foreach (ACarriableItem item in self.Items)
                    {
                        item.Clean = true;

                    }
                }
            }


        }

        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
            switch (args.EventName)
            {
                case "on":
                    
                    self.Stack.Add(args.Arg);
                    break;
            }
        }
    }
}
