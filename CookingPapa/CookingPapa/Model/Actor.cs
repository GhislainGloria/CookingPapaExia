using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Actor : AbstractActor
    {            
		public override void NextTick(List<AbstractActor> AllActors)
		{
			Strategy.Behavior(this, AllActors);
		}
    }
}
