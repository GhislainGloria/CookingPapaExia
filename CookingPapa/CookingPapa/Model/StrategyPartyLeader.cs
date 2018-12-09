using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	class StrategyPartyLeader : Strategy
	{
		public override void Behavior(IActor self, List<IActor> all)
		{
			throw new NotImplementedException();
		}

		public override void ReactToEvent(IActor self, MyEventArgs args)
		{
			throw new NotImplementedException();
		}
	}
}
