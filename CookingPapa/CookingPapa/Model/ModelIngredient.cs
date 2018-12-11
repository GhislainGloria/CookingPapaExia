using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelIngredient : ACarriableItem
    {
		public ModelIngredient(string name, int inventorySize, int id) : base(name, inventorySize)
        {
            ID = id;
        }
    }
}
