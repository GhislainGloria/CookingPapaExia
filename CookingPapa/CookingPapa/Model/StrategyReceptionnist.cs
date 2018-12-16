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

            for (int i = all.Count - 1; i >= 0; i--)
            {
				if (all[i].Name == "customergroup" && all[i].Target == null && !all[i].Busy)
                {
                    Client = (GroupActor)all[i];
					Console.WriteLine(self + ": A new group of clients is here waiting for a table");
                    break;
                }
            }

			if (Client == null) return;

            for (int i = all.Count - 1; i >= 0; i--)
            {
                if (all[i].Name == "headwaiter" && all[i].Target == null)
                {
                    Headwaiter = (Actor)all[i];
					Console.WriteLine(self + ": A headwaiter is available to take care of the client group");
					break;
                }
            }

			if (Headwaiter == null) return;

            for (int i = all.Count - 1; i >= 0; i--)
            {
                if (all[i].Name == "table" && ((Table)all[i]).Grp == null)
                {
                    if (((Table)all[i]).Place > Client.Clients.Count && (closestTable == null || ((Table)all[i]).Place < closestTable.Place))
                    {
                        closestTable = ((Table)all[i]);
						Console.WriteLine(self + ": A table is available for the clients group.");
						break;
                    }
                }
            }

			if (closestTable == null) return;

            // At this point we know a client group has arrived and the staff to guide
            // the group to destination.
            
            closestTable.SetGroupActor(Client);
            Headwaiter.Target = Client;
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
            Headwaiter.CommandList.Add(new CommandSetTarget(Headwaiter, Headwaiter.FindClosest("shed", all)));
            Headwaiter.CommandList.Add(new CommandMove(Headwaiter));
            foreach (Actor client in Client.Clients)
            {
                Headwaiter.CommandList.Add(new CommandGetItem(Headwaiter, Headwaiter.FindClosest("shed", all), "card"));
            }
            Headwaiter.CommandList.Add(new CommandSetTarget(Headwaiter, Client));
            Headwaiter.CommandList.Add(new CommandMove(Headwaiter));
			foreach (Actor client in Client.Clients)
			{
				Headwaiter.CommandList.Add(new CommandGiveItem(Headwaiter, Client, "card"));
			}

			List<DishModel> orderDishes = new List<DishModel>();
			orderDishes.Add(DishModelList.GetAvailableDishes()[0]);
			Order order = new Order(closestTable.ID, orderDishes);
			order.Clean = false; // Needed for the counter to send over to the kitchen
			Client.Items.Add(order);

			foreach (Actor client in Client.Clients)
			{
				Headwaiter.CommandList.Add(new CommandGetItem(Headwaiter, Client, "card"));
			}

			Headwaiter.CommandList.Add(new CommandGetItem(Headwaiter, Client, "order"));
            Headwaiter.CommandList.Add(new CommandSetTarget(Headwaiter, Headwaiter.FindClosest("counter", all)));
            Headwaiter.CommandList.Add(new CommandMove(Headwaiter));
			Headwaiter.CommandList.Add(new CommandGiveItem(Headwaiter, Headwaiter.FindClosest("counter", all), "order"));
            Headwaiter.CommandList.Add(new CommandSetTarget(Headwaiter, Headwaiter.FindClosest("shed", all)));
            Headwaiter.CommandList.Add(new CommandMove(Headwaiter));

            foreach (Actor client in Client.Clients)
            {
                Headwaiter.CommandList.Add(new CommandGiveItem(Headwaiter, Headwaiter.FindClosest("shed", all), "card"));               
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
