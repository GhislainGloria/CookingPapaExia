using System;
namespace Model
{
	public class CommandSetTarget : ACommand
    {
		private AbstractActor Target;

		public CommandSetTarget(AbstractActor self, AbstractActor target)
		{
			Self = self;
			Target = target;
		}

		public override void Execute()
		{
			Self.Target = Target;
			IsCompleted = true;
		}
	}
}
