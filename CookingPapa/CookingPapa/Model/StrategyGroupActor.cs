using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class StrategyGroupActor : Strategy
    {

        private static readonly StrategyGroupActor Instance = new StrategyGroupActor();
        public static StrategyGroupActor GetInstance()
        {
            return Instance;
        }
        private StrategyGroupActor() { }
        public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {
            foreach(AbstractActor client in ((GroupActor)self).Clients)
            {
                client.Strategy.Behavior(client, all);
            }
            if (self.CommandList.Count > 0)
            {
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

        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
