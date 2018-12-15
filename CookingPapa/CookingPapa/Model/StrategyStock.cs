using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StrategyStock : Strategy
    {

        private static readonly StrategyStock Instance = new StrategyStock();      
        public static StrategyStock GetInstance()
        {
            return Instance;
        }

		private StrategyStock() { }

        public override void Behavior(AbstractActor self, List<AbstractActor> all)
		{
			foreach(Ingredient ingredient in self.Items.ToList())
            {
				if(ingredient.TimeSpentInStock++ > 2592000) 
                {
                    self.Items.Remove(ingredient);
					Console.WriteLine(self + ": I became too old and got thrown away");
                }
            }
		}

		public override void ReactToEvent(AbstractActor self, MyEventArgs args)
		{
			throw new NotImplementedException();
		}
	}
}
