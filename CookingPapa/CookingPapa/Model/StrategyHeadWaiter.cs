using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StrategyHeadWaiter : IStrategy
    {
        private static readonly StrategyHeadWaiter Instance = new StrategyHeadWaiter();
        public static StrategyHeadWaiter GetInstance() { return Instance; }
        private StrategyHeadWaiter() { }



        public void Behavior(AbstractActor self, List<AbstractActor> all)
        {
            GroupActor groupActor = (GroupActor)self.Stack[0];
            Table table = (Table)self.Stack[1];

            if (self.CommandList.Count == 0)
            {
                self.Busy = false;
                self.CommandList.Add(new CommandSetTarget(self, self.FindClosest("counter", all)));
                self.CommandList.Add(new CommandMove(self));
            }
        
            if (self.CommandList.Count > 0)
            {
                self.Busy = true;

                if (self.CommandList[0].IsCompleted)
                {
                    self.CommandList.RemoveAt(0);
                }
                else
                {
                    self.CommandList[0].Execute();
                }
            }

            if (self.EvaluateDistanceTo(groupActor) < 2 && self.EvaluateDistanceTo(table) < 2)
            {
                self.CommandList.Add(new CommandSetTarget(self, self.FindNearestCarriableItem("card", all)));
                self.CommandList.Add(new CommandMove(self));
                foreach (Actor actor in groupActor.Clients)
                {
                    self.CommandList.Add(new CommandGetItem(self, self.FindClosest("stock", all), "card"));
                }

            }

            
        }

        public void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
