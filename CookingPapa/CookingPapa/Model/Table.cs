using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingPapa
{
    class Table : ActorStatic
    {
        public int _place;
        public GroupActor _grp;

        public Table(int place, GroupActor grp)
        {
            _place = place;
            _grp = grp;
        }

        public void CallStrategy()
        {

        }
    }
}
