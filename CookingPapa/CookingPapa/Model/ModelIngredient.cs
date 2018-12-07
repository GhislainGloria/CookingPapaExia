using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelIngredient : ICarriableItem
    {
        public ModelIngredient(string name, int inventorySize, int ID)
        {
            this.InventorySize = inventorySize;
            this.Name = name;
            this.ID = ID;
        }
    }
}
