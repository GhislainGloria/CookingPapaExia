using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
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

#pragma warning disable CS0108 // 'Table.CallStrategy()' masque le membre hérité 'ActorStatic.CallStrategy()'. Utilisez le mot clé new si le masquage est intentionnel.
        public void CallStrategy()
#pragma warning restore CS0108 // 'Table.CallStrategy()' masque le membre hérité 'ActorStatic.CallStrategy()'. Utilisez le mot clé new si le masquage est intentionnel.
        {

        }
    }
}
