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



        public void Behavior(AbstractActor self, List<AbstractActor> allActors)
        {
            AbstractActor idle = ActorFactory.CreateActor("idle");
            if (self.CommandList == null)
            {
                self.Busy = false;
                idle.Position = new Point(2,8);
                self.CommandList.Add(new CommandSetTarget(self,idle));
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
            
        }

        public void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
