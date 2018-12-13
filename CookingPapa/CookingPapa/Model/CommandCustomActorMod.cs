using System;
namespace Model
{
	public class CommandCustomActorMod : ACommand
    {
		private Func<AbstractActor, bool> Func;

        /**
         * The bool return type is here for show.
         * Return whatever you want
         */
		public CommandCustomActorMod(AbstractActor self, Func<AbstractActor, bool> func)
        {
			Self = self;
			Func = func;
        }

		public override void Execute()
		{
			Func(Self);
			IsCompleted = true;
		}
	}
}
