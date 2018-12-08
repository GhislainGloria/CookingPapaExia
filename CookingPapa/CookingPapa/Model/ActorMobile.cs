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
			//Strategy.Behavior();
        }

		public override void NextTick(List<IActor> AllActors)
		{
			Strategy.Behavior(this, AllActors);
		}

		public void Move()
		{
			Busy = true;
			Point targetPosition = Target.Position;         
			if (Position.X > targetPosition.X)
			{
				Position = new Point(Position.X - 1, Position.Y);
			}
			else if (Position.X < targetPosition.X)
			{
				Position = new Point(Position.X + 1, Position.Y);
			}
			else if (Position.Y < targetPosition.Y)
			{
				Position = new Point(Position.X, Position.Y + 1);
			}
			else if (Position.Y > targetPosition.Y)
			{
				Position = new Point(Position.X, Position.Y - 1);
			}
			else
			{
				// We are on point
				Busy = false;
			}
        }

        public override void SetStrategy(Strategy strategy)
        {
            this.Strategy = strategy;
        }
    }
}
