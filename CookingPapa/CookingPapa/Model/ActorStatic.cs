using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class ActorStatic : AbstractActor { 
    
        public ActorStatic()
        {
			
        }

        override public void CallStrategy()
        {
			throw new NotImplementedException();
        }

		public override void NextTick()
		{
			this.Strategy.Behavior(); // Todo add this
		}

        public override void SetStrategy(Strategy strategy)
        {
            this.Strategy = strategy;
        }
    }
}
