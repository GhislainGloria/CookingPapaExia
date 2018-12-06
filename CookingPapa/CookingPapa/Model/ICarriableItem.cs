using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class ICarriableItem
    {
        private int _id;
        private string _name;
        private int _inventorySize;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int InventorySize { get => _inventorySize; set => _inventorySize = value; }

        public void CallStrategy()
        {
            throw new NotImplementedException();
        }

        public void Event()
        {
            throw new NotImplementedException();
        }

        public void NextTick()
        {
            throw new NotImplementedException();
        }
    }
}
