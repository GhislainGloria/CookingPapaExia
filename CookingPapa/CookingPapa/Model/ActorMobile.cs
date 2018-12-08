using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class ActorMobile : AbstractActor
    {
        public ActorMobile() : base()
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
        

        public override void SetStrategy(Strategy strategy)
        {
            this.Strategy = strategy;
        }
    }
}
