using System;
using System.Collections.Generic;

namespace Model
{
	public static class DishModelList
    {
		private static List<DishModel> Dishes = new List<DishModel>();
		private static bool SingletonInitialized = false;

		private static void Init()
		{
			DishModel dishModel = new DishModel();
			StepModel modelStep = new StepModel();

			modelStep.Duration = 10;
			modelStep.Ingredient = "carrot";
			modelStep.Utensil = "fork";
			modelStep.Workboard = "Furnace";

			dishModel.ModelSteps.Add(modelStep);
			dishModel.Name = "Generic recipe";

			Dishes.Add(dishModel);

			SingletonInitialized = true;
		}

		public static List<DishModel> GetAvailableDishes()
		{
			if (!SingletonInitialized) Init();
			return Dishes;
		}
    }
}
