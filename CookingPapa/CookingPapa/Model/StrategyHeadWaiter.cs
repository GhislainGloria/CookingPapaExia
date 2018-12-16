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
			else
			{
				foreach (ACarriableItem order in self.Items.Where(i => i.Name == "order" && i.Clean).ToList())
				{
					Order orderCast = (Order)order;
					Table table = null;

					foreach(Table tableCast in all.Where(a => a.Name == "table" && a.ID == orderCast.TableID).ToList())
					{
						table = tableCast;
						break;
					}

					if (table == null)
					{
						Console.WriteLine(self + ": I have an order for table " + orderCast.TableID + " but I could not find it..");
						break;
					}

					self.CommandList.Add(new CommandSetTarget(self, table));
					self.CommandList.Add(new CommandMove(self));
					self.CommandList.Add(new CommandGiveItemsWhere(self, table, i => i.Name == "order" && ((Order)i).TableID == table.ID));
				}

				AbstractActor counter = self.FindClosest("counter", all);
				bool preparedOrders = counter?.Items.Where(i => i.Name == "order" && i.Clean).ToList().Count > 0;

				if (preparedOrders)
				{
					self.CommandList.Add(new CommandSetTarget(self, counter));
					self.CommandList.Add(new CommandMove(self));
					self.CommandList.Add(new CommandGetItemsWhere(self, counter, i => i.Name == "order" && i.Clean));
				}
			}
        }

        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {

        }
    }
}
