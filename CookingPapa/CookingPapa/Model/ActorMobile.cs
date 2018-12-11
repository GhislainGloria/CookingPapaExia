using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class ActorMobile : AbstractActor
    {      
        public override void CallStrategy()
        {
			// To be removed?
        }

		public override void NextTick(List<AbstractActor> AllActors)
		{
			Strategy.Behavior(this, AllActors);
		}
    }
}
