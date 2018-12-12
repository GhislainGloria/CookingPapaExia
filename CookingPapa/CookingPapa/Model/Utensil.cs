using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Utensil : ACarriableItem
    {
		private Step LastUsedFor { get; set; }

		public Utensil(string name, int inventorySize) : base(name, inventorySize)
		{
		}

    }
}
