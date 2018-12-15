using System;
using System.Collections.Generic;

namespace Model
{
    public class Order : ACarriableItem
    {
		public int TableID { get; private set; }
		public List<DishModel> Recipes { get; set; }
		public List<Dish> DishInstances { get; set; }
		private int CompletedDishes = 0;
        



        public Order(int tableID, List<DishModel> dishModels) : base("commande", 1)
        {
            Recipes = dishModels;
			DishInstances = new List<Dish>();
			TableID = tableID;

			foreach (DishModel dm in Recipes)
			{
				DishInstances.Add(new Dish(dm, this));
			}
		}

        public void MarkDishCompleted()
		{
			CompletedDishes++;
			if(CompletedDishes >= Recipes.Count)
			{
				Console.WriteLine("Order completed for table #{0}", TableID);
			}
		}

		public bool Completed()
		{
			return CompletedDishes >= Recipes.Count;
		}
    }
}
