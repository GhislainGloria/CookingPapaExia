using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	class StrategyHeadWaiter : Strategy
	{
		public override void Behavior(AbstractActor self, List<AbstractActor> all)
		{
			throw new NotImplementedException();
		}

		public override void ReactToEvent(AbstractActor self, MyEventArgs args)
		{
			throw new NotImplementedException();
		}
	}
}
