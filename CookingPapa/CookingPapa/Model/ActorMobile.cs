using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class ActorMobile : AbstractActor
    {
        public ActorMobile()
        {
            
        }

        public override void CallStrategy()
        {
			//Strategy.Behavior();
        }

		public override void NextTick(List<IActor> AllActors)
		{
			Strategy.Behavior(this, AllActors);
		}

		public void Move()
        {
            throw new NotImplementedException();
        }

        public override void SetStrategy(Strategy strategy)
        {
            this.Strategy = strategy;
        }
    }
}
