using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public abstract class Strategy: IStrategy
    {
		public abstract void Behavior(AbstractActor self, List<AbstractActor> all);
		public abstract void ReactToEvent(AbstractActor self, MyEventArgs args);
    }
}
