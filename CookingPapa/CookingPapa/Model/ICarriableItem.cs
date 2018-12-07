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
        private string name;
        private int iD;
        private int inventorySize;
        private static int instance;

        public string Name { get => name; set => name = value; }
        public int ID { get => iD; set => iD = value; }
        public int InventorySize { get => inventorySize; set => inventorySize = value; }
        public static int Instance { get => instance; set => instance = value; }
    }
}
