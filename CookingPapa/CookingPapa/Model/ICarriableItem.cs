using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
	public class ICarriableItem : AbstractActor
    {
        private string name;
        private int iD;
        private int inventorySize;
        private static int instance;


        public override void CallStrategy()
        {
            throw new NotImplementedException();
        }

		public override void NextTick()
        {
            throw new NotImplementedException();
        }

        public override void SetStrategy(Strategy strategy)
        {
            throw new NotImplementedException();
        }
        public string Name { get => name; set => name = value; }
        public int ID { get => iD; set => iD = value; }
        public int InventorySize { get => inventorySize; set => inventorySize = value; }
        public static int Instance { get => instance; set => instance = value; }
    }
}
