using System;
using System.Collections.Generic;

namespace Model
{
	public abstract class ACarriableItem
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public int InventorySize { get; private set; }
		public bool Clean { get; set; }
        
		protected ACarriableItem(string name, int size)
		{
			ID++;
			InventorySize = size;
			Name = name;
			Clean = true;
		}
    }
}