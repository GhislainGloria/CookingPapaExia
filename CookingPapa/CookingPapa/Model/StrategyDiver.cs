using System.Collections.Generic;
using System.Threading.Tasks;

namespace Model
{
    class StrategyDiver : Strategy
    {
		private static StrategyDiver Instance = new StrategyDiver();
		public static StrategyDiver GetInstance() { return Instance; }
		private StrategyDiver() {}

		public override void Behavior(IActor self, List<IActor> all)
		{
			/*if (!self.Busy)
			{
				self.Target = self.FindClosest("chef", all);
			}
			self.Move();*/
		}

		public override void ReactToEvent(IActor self, MyEventArgs args)
		{
			throw new System.NotImplementedException();
		}
	}
}
