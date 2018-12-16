using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CommandRemoveFromWorld : ACommand
    {
		List<AbstractActor> All = null;

		public CommandRemoveFromWorld(AbstractActor self, List<AbstractActor> all)
        {
            Self = self;
			All = all;
        }

        public override void Execute()
        {
            IsCompleted = true;
			All.Remove(Self);
        }
    }
}
