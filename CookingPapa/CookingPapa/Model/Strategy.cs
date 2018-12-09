using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public abstract class Strategy: IStrategy
    {
		public abstract void Behavior(IActor self, List<IActor> all);
		public abstract void ReactToEvent(IActor self, MyEventArgs args);
    }
}
