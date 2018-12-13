using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CommandGetItem : ACommand
    {
        public CommandGetItem(AbstractActor self, AbstractActor getfrom, string item)
        {
            Self = self;
            Getfrom = getfrom;
            Item = item;
        }

        public AbstractActor Getfrom { get; private set; }
        public string Item { get; private set; }

        public override void Execute()
        {
            IsCompleted = true;
            if (Self.EvaluateDistanceTo(Getfrom) < 2)
            {
                foreach (ACarriableItem itemFrom in Getfrom.Items)
                {
                    if (itemFrom.Name.Equals(Item))
                    {
                        Getfrom.Items.Remove(itemFrom);
                        Self.Items.Add(itemFrom);

						Console.WriteLine(
							Self + ": I picked up a " + Item + " from " + Getfrom.Name
						);
                        return;
                    }
                }
            }
            else
            {
				Console.WriteLine(
					Self + ": I'm too far away to get item " + Item + " from " + Getfrom.Name
				);
            }

			Console.WriteLine(
				Self + ": I failed to get the " + Item + " from " + Getfrom.Name
			);
			Self.Busy = false;
			Self.CommandList.Clear();         
			Self.TriggerEvent("CommandQueueFailed", Self, Item);
        }
    }
}
