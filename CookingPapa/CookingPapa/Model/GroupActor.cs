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
        private Table _table = null;

        public List<Actor> Clients { get => _clients; set => _clients = value; }
        public Table Table { get => _table; set => _table = value; }

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
