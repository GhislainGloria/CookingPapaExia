using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Ingredient : ACarriableItem
    {
		public int TimeToLive { get; private set; }
        
		public Ingredient(string name, int inventorySize, int timeToLive) : base(name, inventorySize)
        {
			TimeToLive = timeToLive;
        }
    }
}
