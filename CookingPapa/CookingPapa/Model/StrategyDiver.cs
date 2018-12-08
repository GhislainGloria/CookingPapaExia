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
            //self.Position = new System.Drawing.Point(self.Position.X, self.Position.Y + 1);
		}
	}
}
