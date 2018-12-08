using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
			Strategy.Behavior();
        }

		public override void NextTick()
		{
			CallStrategy();
		}

		public void Move(IActor actor)
        {
            while(actor.Position.X != this.Position.X)
            {
                if(actor.Position.X > this.Position.X)
                {
                    this.Position = new Point(this.Position.X + 1, this.Position.Y);
                    NextTick();
                }
                if (actor.Position.X < this.Position.X)
                {
                    this.Position = new Point(this.Position.X - 1, this.Position.Y);
                    NextTick();
                }
            }

            while (actor.Position.Y != this.Position.Y)
            {
                if (actor.Position.Y > this.Position.Y)
                {
                    this.Position = new Point(this.Position.X, this.Position.Y + 1);
                    NextTick();
                }
                if (actor.Position.Y < this.Position.Y)
                {
                    this.Position = new Point(this.Position.X, this.Position.Y - 1);
                    NextTick();
                }
            }
        }

        public override void SetStrategy(Strategy strategy)
        {
            this.Strategy = strategy;
        }
    }
}
