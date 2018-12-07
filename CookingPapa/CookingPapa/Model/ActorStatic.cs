using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ActorStatic : AbstractActor { 
    
        public ActorStatic()
        {
			
        }

        override public void CallStrategy()
        {
			throw new NotImplementedException();
        }

		public override void NextTick()
		{
			throw new NotImplementedException();
		}
	}
}
