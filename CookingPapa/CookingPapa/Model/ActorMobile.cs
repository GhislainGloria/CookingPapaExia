using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class ActorMobile : AbstractActor
    {
        public override void CallStrategy()
        {
			Strategy.Behavior();
        }

		public override void NextTick()
		{
			CallStrategy();
		}

		public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
