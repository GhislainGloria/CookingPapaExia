using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GiveItem : ACommand
    {
        public GiveItem(AbstractActor self, AbstractActor giveto, ACarriableItem item)
        {
            Self = self;
            Giveto = giveto;
            Item = item;
        }

        public AbstractActor Giveto { get; private set; }
        public ACarriableItem Item { get; private set; }

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
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine(Self.Name + ": I'm too far away !");
            }
        }
    }
}
