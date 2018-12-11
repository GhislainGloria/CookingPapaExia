using System;
namespace Model
{
	public class CommandSetTarget : ACommand
    {

		public CommandSetTarget(AbstractActor self, AbstractActor target)
		{
			self.Target = target;
			IsCompleted = true;
		}

		public override void Execute()
		{
			
		}
	}
}
