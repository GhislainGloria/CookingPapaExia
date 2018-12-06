using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class ActorStatic : AbstractActorStatic { 
    
        public ActorStatic()
        {
        }

#pragma warning disable CS0108 // 'ActorStatic.CallStrategy()' masque le membre hérité 'AbstractActorStatic.CallStrategy()'. Utilisez le mot clé new si le masquage est intentionnel.
        public void CallStrategy()
#pragma warning restore CS0108 // 'ActorStatic.CallStrategy()' masque le membre hérité 'AbstractActorStatic.CallStrategy()'. Utilisez le mot clé new si le masquage est intentionnel.
        {
           
        }
    }
}
