using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class StrategyChef : Strategy
    {
		private static StrategyChef Instance = new StrategyChef();
		public static StrategyChef getInstance()
		{
			return Instance;
		}

		private StrategyChef() {}
        
		public override void Behavior(IActor actor, List<IActor> actors)
        {

        }
    }
}
