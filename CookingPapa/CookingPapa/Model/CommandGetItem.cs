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
			if (!Self.GetItemFrom(Getfrom, Item))
            {
                Self.Busy = false;
                Self.CommandList.Clear();
                Self.TriggerEvent("CommandQueueFailed", Self, Item);
            }
        }
    }
}
