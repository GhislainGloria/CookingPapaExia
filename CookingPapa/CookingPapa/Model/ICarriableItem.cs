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
        private int iD;
        private int inventorySize;
        private static int instance;


        public override void CallStrategy()
        {
            throw new NotImplementedException();
        }

		public override void NextTick(List<IActor> AllActors)
		{
			throw new NotImplementedException();
		}
        
        public int ID { get => iD; set => iD = value; }
        public int InventorySize { get => inventorySize; set => inventorySize = value; }
        public static int Instance { get => instance; set => instance = value; }
    }
}
