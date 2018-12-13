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

            //  #1
			modelStep.Duration = 10;
			modelStep.Ingredient = "carrot";
			modelStep.Utensil = "fork";
			modelStep.Workboard = "furnace";

			dishModel.ModelSteps.Add(modelStep);
			dishModel.Name = "Generic recipe";

			Dishes.Add(dishModel);

            // #2
			dishModel = new DishModel();
            modelStep = new StepModel();

            modelStep.Duration = 5;
            modelStep.Ingredient = "tomato";
            modelStep.Utensil = "blender";
            modelStep.Workboard = "cookingplate";

            dishModel.ModelSteps.Add(modelStep);
            dishModel.Name = "Generic recipe 2";

            Dishes.Add(dishModel);

			SingletonInitialized = true;
		}

		public static List<DishModel> GetAvailableDishes()
		{
			if (!SingletonInitialized) Init();
			return Dishes;
		}

		public static DishModel GetModelByName(string name)
		{
			foreach(DishModel dm in GetAvailableDishes())
			{
				if(dm.Name == name)
				{
					return dm;
				}
			}

			return null;
		}
    }
}
