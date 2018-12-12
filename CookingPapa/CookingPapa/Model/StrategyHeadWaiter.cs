using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StrategyHeadWaiter : Strategy
    {

        private static readonly StrategyHeadWaiter Instance = new StrategyHeadWaiter();
        public static StrategyHeadWaiter GetInstance()
        {
            return Instance;
        }
        private StrategyHeadWaiter() { }
        public override void Behavior(AbstractActor self, List<AbstractActor> all)
		{
            GroupActor Client = null;
            Table closestTable = null;
            foreach (AbstractActor group in all.Where(n => n.Name == "clientgroup" && n.Busy == false))
            {
                Client = (GroupActor)group;
                break;
            }
            foreach (AbstractActor table in all.Where(n => n.Name == "table"))
            {
                if(((Table)table).Place > Client.Clients.Count && (closestTable == null || ((Table)table).Place < closestTable.Place))
                {
                    closestTable = ((Table)table);
                }
            }
            if(closestTable != null)
            {
                Client.Target = closestTable;
                Client.CommandList.Add(new CommandMove(Client));
            }
        }

		public override void ReactToEvent(AbstractActor self, MyEventArgs args)
		{
			switch (args.EventName)
            {
                case "clientSpawned":
                    GroupActor newClients = ((GroupActor)args.Arg);
                    newClients.Target = self;
                    newClients.CommandList.Add(new CommandMove(newClients));
                    break;
            }
		}
	}
}
