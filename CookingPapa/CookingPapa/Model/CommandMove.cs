using System.Drawing;

namespace Model
{
    public class CommandMove : ACommand
    {

        public CommandMove(AbstractActor self)
        {
            Self = self;
        }

        /**
         * Changes the actor's position. Makes it move toward its target.
         */
        public override void Execute()
        {
            if (Self.Target == null)
            {
				IsCompleted = true;
                return;
            }

			if (Self.EvaluateDistanceTo(Self.Target) < 2)
            {
                // We are on point
                Self.BusyWalking = false;
                Self.Target = null;
                IsCompleted = true;
				return;
            }

            Self.BusyWalking = true;
            Point targetPosition = Self.Target.Position;
            if (Self.Position.X > targetPosition.X)
            {
                Self.Position = new Point(Self.Position.X - 1, Self.Position.Y);
            }
            else if (Self.Position.X < targetPosition.X)
            {
                Self.Position = new Point(Self.Position.X + 1, Self.Position.Y);
            }
            else if (Self.Position.Y < targetPosition.Y)
            {
                Self.Position = new Point(Self.Position.X, Self.Position.Y + 1);
            }
            else if (Self.Position.Y > targetPosition.Y)
            {
                Self.Position = new Point(Self.Position.X, Self.Position.Y - 1);
            }
        }
    }
}
