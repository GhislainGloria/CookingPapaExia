using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CommandGetItemsWhere : ACommand
    {
		public AbstractActor Getfrom { get; private set; }
		public Func<ACarriableItem, bool> WhereCondition { get; private set; }

		public CommandGetItemsWhere(AbstractActor self, AbstractActor getfrom, Func<ACarriableItem, bool> whereCondidtion)
        {
            Self = self;
            Getfrom = getfrom;
			WhereCondition = whereCondidtion;
        }

        public override void Execute()
        {
            IsCompleted = true;
			foreach (ACarriableItem i in Getfrom.Items.Where(WhereCondition).ToList())
            {
				Self.GetItemFrom(Getfrom, i.Name);
            }
        }
    }
}
