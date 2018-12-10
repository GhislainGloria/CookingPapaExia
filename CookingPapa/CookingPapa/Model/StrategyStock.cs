using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StrategyStock : Strategy
    {

        private static StrategyStock Instance = new StrategyStock();
        public static StrategyStock GetInstance()
        {
            return Instance;
        }

        public StrategyStock() { }

        public override void Behavior(IActor self, List<IActor> all)
		{
			foreach(Ingredient ingredient in self.Items.ToList())
            {
                ingredient.TimeToLive--;
                if(ingredient.TimeToLive < 1)
                {
                    self.Items.Remove(ingredient);
                }
            }
		}

		public override void ReactToEvent(IActor self, MyEventArgs args)
		{
			throw new NotImplementedException();
		}
	}
}
