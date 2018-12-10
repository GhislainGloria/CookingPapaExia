using System;
using System.Collections.Generic;

namespace Model
{
	public static class DishModelList
    {
		private static List<DishModel> Dishes = new List<DishModel>();
		private static bool Initialized = false;

		private static void Init()
		{
			DishModel dishModel = new DishModel();
			StepModel modelStep = new StepModel();

			modelStep.Duration = 10;
			modelStep.Ingredient = "carrot";
			modelStep.Utensil = "spoon";
			modelStep.Workboard = "Furnace";

			dishModel.ModelSteps.Add(modelStep);

			Dishes.Add(dishModel);

			Initialized = true;
		}

		public static List<DishModel> GetAvailableDishes()
		{
			if (!Initialized) Init();
			return Dishes;
		}
    }
}
