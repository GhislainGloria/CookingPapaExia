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
			this.Strategy.Behavior();
        }

		public override void NextTick()
		{
			throw new NotImplementedException();
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
