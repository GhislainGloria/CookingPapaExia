using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ActorStatic : AbstractActor { 
    
        public ActorStatic() : base()
        {
			
        }

        override public void CallStrategy()
        {
            Strategy.Behavior();
        }

		public override void NextTick()
		{
            CallStrategy();// Todo add this
		}

        public override void SetStrategy(Strategy strategy)
        {
            this.Strategy = strategy;
        }
    }
}
