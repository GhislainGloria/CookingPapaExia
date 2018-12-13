using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StrategyCustomers : Strategy
    {

        /*
         * Stack[0] = boolean isOnTable
         * Stack[1] = int waiting time for bread
         * Stack[2] = int type of client
         * Stack[3] = GroupActor
         * Stack[4] = PauseTime
         * Stack[5] = actual waiting time for bread (const)
         */


        private static readonly StrategyCustomers Instance = new StrategyCustomers();
        public static StrategyCustomers GetInstance()
        {
            return Instance;
        }
        private StrategyCustomers() { }

        public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {
            if (((bool)self.Stack[0]))
            {
                Random random = new Random();

                if (((int)self.Stack[1]/10) > (int)self.Stack[5])
                {
                    self.TriggerEvent("water and bread", self);
                    foreach (AbstractActor client in ((GroupActor)self.Stack[3]).Clients)
                    {
                        client.Stack[1] = 0;
                        client.Stack[5] = random.Next(1,100);
                    }
                }
                else
                {
                    switch (((int)self.Stack[2]))
                    {
                        case 1:
                            self.Stack[1] = ((int)self.Stack[1]) + 0.5;
                            break;

                        case 2:
                            self.Stack[1] = ((int)self.Stack[1]) + 1;
                            break;

                        case 3:
                            self.Stack[1] = ((int)self.Stack[1]) + 1.5;
                            break;
                    }
                }
                if (((bool)self.Stack[4]))
                {
                    self.Stack[4] = ((int)self.Stack[4]) - 1;
                }
            }
        }

        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
