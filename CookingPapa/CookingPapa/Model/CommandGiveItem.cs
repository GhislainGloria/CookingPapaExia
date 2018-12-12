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
			if (!Self.GiveItemTo(Giveto, Item))
            {
                Self.Busy = false;
                Self.CommandList.Clear();
                Self.TriggerEvent("CommandQueueFailed", Self, Item);
            }
        }
    }
}
