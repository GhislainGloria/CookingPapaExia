using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Linq;

namespace Model
{
	public abstract class AbstractActor : IActor
    {
		public List<ICarriableItem> Items { get; set; }
		public Point Position { get; set; }
		public IActor Target { get; set; }
        public bool Busy { get; set; }
        public Thread Thread { get; set; }
        public int MaxInventorySize { get; set; }
        public string Name { get; set; }
        public IStrategy Strategy { get; set; }
        
        
		public abstract void NextTick(List<IActor> AllActors);
		public abstract void CallStrategy();
        public abstract void SetStrategy(Strategy strategy);

		public IActor FindClosest(string Name, List<IActor> AllActors)
        {
            List<IActor> filteredActors = AllActors.Where(a => a.Name == Name).ToList();
            IActor nearest = null;
            int lowestDistance = 10000000;
            int currentDistance = 0;

            foreach (IActor actor in filteredActors)
            {
                currentDistance = EvaluateDistanceTo(actor);
				if (currentDistance < lowestDistance && !ReferenceEquals(this, actor))
                {
                    lowestDistance = currentDistance;
                    nearest = actor;
                }
            }

            if (nearest == null)
            {
                Console.WriteLine("Unable to find another " + Name);
                nearest = this;
            }

            return nearest;
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
                Target = this;
            }
        }

		// Actors can only move in straight vertical or horizontal lines,
        // therefore calculating the distance of a straight diagonal line is useless.
        protected int EvaluateDistanceTo(IActor OtherActor)
        {
            int X = Math.Abs(OtherActor.Position.X - Position.X);
            int Y = Math.Abs(OtherActor.Position.Y - Position.Y);
            return X + Y;
        }
    }
}
