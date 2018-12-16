using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Table : AbstractActor
    {
        private int square;
        private int _place;
        private GroupActor _grp = null;
        
        public int Place { get => _place; set => _place = value; }
        public GroupActor Grp { get => _grp; set => _grp = value; }
        public int Square { get => square; set => square = value; }

		public Table(int place, int square)
        {
			Name = "table";
            Place = place;
            Square = square;
        }

        public void SetGroupActor(GroupActor grp)
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

        public void RemoveGroupActor()
        {
            Grp = null;
        }

        public override void NextTick(List<AbstractActor> AllActors)
        {

        }
    }
}
