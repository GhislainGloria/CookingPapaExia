using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingPapa
{
    class GroupActor
    {
        private List<ActorMobile> _clients;

        public List<ActorMobile> Clients { get => _clients; set => _clients = value; }
    }
}
