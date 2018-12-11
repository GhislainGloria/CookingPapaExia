using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Table : Actor
    {
        private int _place;
        private GroupActor _grp;

        public int Place { get => _place; set => _place = value; }
        public GroupActor Grp { get => _grp; set => _grp = value; }

        public Table(int place)
        {
            Place = place;
        }

        public void setGroupActor(GroupActor grp)
        {
            if (Place >= grp.Clients.Count)
            {
                Grp = grp;
            }
            else
            {
                throw new Exception("Too many clients for this table.");
            }
        }

        public void removeGroupActor()
        {
            Grp = null;
        }
    }
}
