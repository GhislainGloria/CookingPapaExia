using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GroupActor : AbstractActor
    {
		private List<Actor> _clients = new List<Actor>();

        public List<Actor> Clients { get; set; }

        public override void CallStrategy()
        {
            throw new NotImplementedException();
        }

        public override void NextTick(List<AbstractActor> AllActors)
        {
            Strategy.Behavior(this, AllActors);
        }
    }
}
