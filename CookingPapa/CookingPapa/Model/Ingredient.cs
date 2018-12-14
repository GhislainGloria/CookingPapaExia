using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Ingredient : ACarriableItem
    {
		public int TimeToLive { get; set; }
        
		public Ingredient(string name, int inventorySize) : base(name, inventorySize)
        {
            InventorySize = StockDAO.GetModelIngredient(name).InventorySize;
            TimeToLive = StockDAO.GetModelIngredient(name).TimeToLive;
        }
    }
}
