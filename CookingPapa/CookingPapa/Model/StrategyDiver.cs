using System.Collections.Generic;
using System.Threading.Tasks;

namespace Model
{
    class StrategyDiver : Strategy
    {
		private static StrategyDiver Instance = new StrategyDiver();
		public static StrategyDiver GetInstance() { return Instance; }
		private StrategyDiver() {}

		public override void Behavior(AbstractActor self, List<AbstractActor> all)
		{
			if (self.CommandList.Count > 0)
            {
                self.Busy = true;

                if (self.CommandList[0].IsCompleted)
                {
                    self.CommandList.RemoveAt(0);
                }
                else
                {
                    self.CommandList[0].Execute();
                }
            }
            else
            {
                self.Busy = false;
            }
		}

		public override void ReactToEvent(AbstractActor self, MyEventArgs args)
		{
			throw new System.NotImplementedException();
		}
	}
}
