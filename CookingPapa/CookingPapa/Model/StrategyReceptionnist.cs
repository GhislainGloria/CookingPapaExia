using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StrategyReceptionnist : Strategy
    {

        private static readonly StrategyReceptionnist Instance = new StrategyReceptionnist();
        public static StrategyReceptionnist GetInstance()
        {
            return Instance;
        }
        private StrategyReceptionnist() { }

        public override void Behavior(AbstractActor self, List<AbstractActor> all)
		{
            GroupActor Client = null;
            Table closestTable = null;
            AbstractActor Headwaiter = null;

            foreach (AbstractActor group in all.Where(n => n.Name == "clientgroup" && n.Target == null))
            {
                Client = (GroupActor)group;
                break;
            }

            foreach (AbstractActor headwaiter in all.Where(n => n.Name == "headwaiter" && n.Target == null))
            {
                Headwaiter = headwaiter;
                break;
            }

            foreach (AbstractActor table in all.Where(n => n.Name == "table" && ((Table)n).Grp != null))
            {
                if(((Table)table).Place > Client.Clients.Count && (closestTable == null || ((Table)table).Place < closestTable.Place))
                {
                    closestTable = ((Table)table);
                }
            }

            if(closestTable != null && Client != null && Headwaiter != null)
            {
                closestTable.SetGroupActor(Client);
                Headwaiter.Target = Client;
                Headwaiter.Stack.Add(Client);
                Headwaiter.Stack.Add(closestTable);
                Headwaiter.CommandList.Add(new CommandMove(Headwaiter));
                Headwaiter.CommandList.Add(new CommandSetTarget(Client, closestTable));
                Headwaiter.CommandList.Add(new CommandSetTarget(Headwaiter, closestTable));
                Headwaiter.CommandList.Add(new CommandCustomActorMod(
                    Client, 
                    (c) => {
                        c.CommandList.Add(new CommandMove(c));
                        return true;
                    })
                );
                Headwaiter.CommandList.Add(new CommandMove(Headwaiter));

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
