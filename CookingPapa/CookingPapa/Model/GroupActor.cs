using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GroupActor : AbstractActor
    {      
        public List<Actor> Clients { get; set; }

		public GroupActor()
		{
			Clients = new List<Actor>();
		}

        public override void NextTick(List<AbstractActor> AllActors)
        {
            Strategy.Behavior(this, AllActors);
        }
    }
}
