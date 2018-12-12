using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CommandGiveItemsWhere : ACommand
    {
        public AbstractActor GiveTo { get; private set; }
        public Func<ACarriableItem, bool> WhereCondition { get; private set; }

        public CommandGiveItemsWhere(AbstractActor self, AbstractActor giveTo, Func<ACarriableItem, bool> whereCondidtion)
        {
            Self = self;
			GiveTo = giveTo;
            WhereCondition = whereCondidtion;
        }

        public override void Execute()
        {
            IsCompleted = true;
            foreach (ACarriableItem i in Self.Items.Where(WhereCondition).ToList())
            {
				if (Self.GiveItemTo(GiveTo, i.Name))
                {
                    Console.WriteLine(
						Self.Name + ": I gave a " + i.Name + " to " + GiveTo.Name
                    );
                }
            }
        }
    }
}
