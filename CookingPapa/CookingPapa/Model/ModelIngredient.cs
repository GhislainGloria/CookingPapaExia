using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelIngredient : ACarriableItem
    {
        public int TimeToLive { get; private set; }
		public ModelIngredient(string name, int inventorySize, int id, int timeToLive) : base(name, inventorySize)
        {
            TimeToLive = TimeToLive;
            ID = id;
        }
    }
}
