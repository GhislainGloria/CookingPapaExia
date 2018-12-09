using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Utensil : ICarriableItem
    {
        private bool _isSmallItem;
        private Step _lastUsedFor;

        public bool IsSmallItem { get => _isSmallItem; set => _isSmallItem = value; }
        internal Step LastUsedFor { get => _lastUsedFor; set => _lastUsedFor = value; }

        public Utensil(string name, int inventorySize)
        {
            this.InventorySize = inventorySize;
            this.Name = name;
        }

    }
}
