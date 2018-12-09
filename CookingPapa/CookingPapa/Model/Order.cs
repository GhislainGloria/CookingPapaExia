﻿using System;
using System.Collections.Generic;

namespace Model
{
    public class Order
    {
		public Table Table { get; private set; }
		public List<DishModel> Recipes { get; set; }
		public List<Dish> DishInstances { get; set; }
		private int CompletedDishes = 0;
        
		public Order(Table table, List<DishModel> dishModels)
		{
			Recipes = dishModels;
			DishInstances = new List<Dish>();

			foreach (DishModel dm in Recipes)
			{
				DishInstances.Add(new Dish(dm, this));
			}
		}

		public void MarkDishCompleted()
		{
			if(CompletedDishes++ >= Recipes.Count)
			{
				Console.WriteLine("Order completed for table #{0}", "TODO");
			}
		}

		public bool Completed()
		{
			return CompletedDishes >= Recipes.Count;
		}
    }
}
