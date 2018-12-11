using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GroupActor
    {
		private List<Actor> _clients = new List<Actor>();

        public List<Actor> Clients { get => _clients; set => _clients = value; }
    }
}
