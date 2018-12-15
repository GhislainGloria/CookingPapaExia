using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ingredient : ACarriableItem
    {
		public int DatabaseModelId { get; set; }
		public int TimeSpentInStock { get; set; }
		private bool TrackedByDatabase = true;
        
        /**
         * If you set the database ID to 0, the database will not update
         */
		public Ingredient(string name, int inventorySize, int databaseModelId = 1, bool updateDatabase = true) : base(name, inventorySize)
        {
			DatabaseModelId = databaseModelId;
			TimeSpentInStock = 0;
			TrackedByDatabase = updateDatabase;
			if(databaseModelId > 0 && updateDatabase) StockDAO.AddToStock(this);         
        }

		~Ingredient()
		{
			if (DatabaseModelId > 0 && TrackedByDatabase) StockDAO.DeleteFromStock(this);
		}
    }
}
