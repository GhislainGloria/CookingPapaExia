using System.Collections.Generic;
using System.Linq;

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

		private void InitChef(IActor chef, List<IActor> all)
		{
			List<IActor> allCounters = all.Where(a => a.Name == "counter").ToList();
			foreach(IActor a in allCounters)
			{
				a.EventNewOrder += chef.StrategyCallback;
			}
			chef.Initialized = true;
		}

		public override void Behavior(IActor self, List<IActor> all)
        {
			if (!self.Initialized) InitChef(self, all);
        }

		public override void ReactToEvent(IActor self, MyEventArgs args)
		{
			switch(args.EventName)
			{
				case "order received":
					// Ici on ajoute la nouvelle Order (avec args.Arg) dans la liste
                    // des trucs à faire du chef. Le process se fera par la suite
					// dans Behavior()
					break;
			}
		}
	}
}
