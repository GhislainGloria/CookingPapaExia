using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GroupActor
    {
		private List<ActorMobile> _clients = new List<ActorMobile>();

        public List<ActorMobile> Clients { get => _clients; set => _clients = value; }
    }
}
