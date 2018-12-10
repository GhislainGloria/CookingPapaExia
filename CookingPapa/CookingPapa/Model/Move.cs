using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Move : ACommand
    {

        public Move(AbstractActor self)
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
            else
            {
                // We are on point
                Self.BusyWalking = false;
                Self.Target = null;
                IsCompleted = true;
            }
        }
    }
}
