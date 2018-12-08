using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ingredient : ICarriableItem
    {
        private int _timeToLive;
        private string ingredient;
        private int v;

        public int TimeToLive { get => _timeToLive; set => _timeToLive = value; }
        public Ingredient(string name, int inventorySize, int timeToLive)
        {
            this.InventorySize = inventorySize;
            this.Name = name;
            this.ID = Instance;
            this.TimeToLive = timeToLive;
            Instance++;
        }
    }
}
