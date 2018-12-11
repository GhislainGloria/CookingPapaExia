using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CommandGiveItem : ACommand
    {
        public AbstractActor Giveto { get; private set; }
		public string Item { get; private set; }

		public CommandGiveItem(AbstractActor self, AbstractActor giveto, string item)
        {
            Self = self;
            Giveto = giveto;
            Item = item;
        }

        public override void Execute()
        {
            IsCompleted = true;
            if (Self.EvaluateDistanceTo(Giveto) < 2)
            {
                foreach(ACarriableItem itemFrom in Self.Items)
                {
                    if (itemFrom.Name.Equals(Item))
                    {
                        Self.Items.Remove(itemFrom);
                        Giveto.Items.Add(itemFrom);
						Console.WriteLine(
							Self.Name + ": I gave my " + Item + " to " + Giveto.Name
                        );
                        return;
                    }
                }
            }
            else
            {
				Console.WriteLine(
					Self.Name + ": I'm too far away to give item " + Item + " to " + Giveto.Name
                );
            }

			Console.WriteLine(
				Self.Name + ": I failed to give the " + Item + " to " + Giveto.Name
            );
            Self.Busy = false;
            Self.CommandList.Clear();
			Self.TriggerEvent("CommandQueueFailed", Self, Item);
        }
    }
}
