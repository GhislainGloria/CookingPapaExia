using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Utensil : ICarriableItem
    {
        private Step _lastUsedFor;

        internal Step LastUsedFor { get => _lastUsedFor; set => _lastUsedFor = value; }

        public Utensil(string name, int inventorySize)
        {
            this.Name = name;
            this.InventorySize = inventorySize;
        }
    }
}
