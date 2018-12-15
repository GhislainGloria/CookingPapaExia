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
            StepModel modelStep1 = new StepModel();
            StepModel modelStep2 = new StepModel();
            StepModel modelStep3 = new StepModel();
            StepModel modelStep4 = new StepModel();

            //  #1
            modelStep1.Duration = 100;
			modelStep1.Ingredient = "carrot";
			modelStep1.Utensil = "fork";
			modelStep1.Workboard = "furnace";

			dishModel.ModelSteps.Add(modelStep1);
			dishModel.Name = "Carottes au four";

			Dishes.Add(dishModel);

            // #2
            dishModel = new DishModel();
            modelStep1 = new StepModel();

            modelStep1.Duration = 100;
            modelStep1.Ingredient = "tomato";
            modelStep1.Utensil = "blender";
            modelStep1.Workboard = "cookingplate";

            dishModel.ModelSteps.Add(modelStep1);
            dishModel.Name = "Soupe de tomate";

            Dishes.Add(dishModel);

            // #3
            dishModel = new DishModel();
            modelStep1 = new StepModel();
            modelStep2 = new StepModel();
            modelStep3 = new StepModel();
            modelStep4 = new StepModel();

            modelStep1.Duration = 20;
            modelStep1.Ingredient = "onion";
            modelStep1.Utensil = "kitchen knife";
            modelStep1.Workboard = "workplan";

            modelStep2.Duration = 20;
            modelStep2.Ingredient = "pork";
            modelStep2.Utensil = "pan";
            modelStep2.Workboard = "cookingplate";

            modelStep3.Duration = 20;
            modelStep3.Ingredient = "potato";
            modelStep3.Utensil = "kitchen knife";
            modelStep3.Workboard = "workplan";

            modelStep4.Duration = 20;
            modelStep4.Ingredient = "potato";
            modelStep4.Utensil = "curved plate";
            modelStep4.Workboard = "furnace";

            dishModel.ModelSteps.Add(modelStep1);
            dishModel.ModelSteps.Add(modelStep2);
            dishModel.ModelSteps.Add(modelStep3);
            dishModel.ModelSteps.Add(modelStep4);
            dishModel.Name = "tartiflette";

            Dishes.Add(dishModel);

            // #4
            dishModel = new DishModel();
            modelStep1 = new StepModel();
            modelStep2 = new StepModel();
            modelStep3 = new StepModel();
            modelStep4 = new StepModel();

            modelStep1.Duration = 20;
            modelStep1.Ingredient = "onion";
            modelStep1.Utensil = "kitchen knife";
            modelStep1.Workboard = "workplan";

            modelStep2.Duration = 20;
            modelStep2.Ingredient = "tomato";
            modelStep1.Utensil = "kitchen knife";
            modelStep1.Workboard = "workplan";

            modelStep3.Duration = 20;
            modelStep3.Ingredient = "meat";
            modelStep3.Utensil = "kitchen knife";
            modelStep3.Workboard = "workplan";

            modelStep4.Duration = 20;
            modelStep4.Ingredient = "meat";
            modelStep4.Utensil = "curved plate";
            modelStep4.Workboard = "furnace";

            dishModel.ModelSteps.Add(modelStep1);
            dishModel.ModelSteps.Add(modelStep2);
            dishModel.ModelSteps.Add(modelStep3);
            dishModel.ModelSteps.Add(modelStep4);
            dishModel.Name = "shepherds pie";

            Dishes.Add(dishModel);

            // #5
            dishModel = new DishModel();
            modelStep1 = new StepModel();
            modelStep2 = new StepModel();
            modelStep3 = new StepModel();
            modelStep4 = new StepModel();

            modelStep1.Duration = 20;
            modelStep1.Ingredient = "egg";
            modelStep1.Utensil = "mixer";
            modelStep1.Workboard = "workplan";

            modelStep2.Duration = 20;
            modelStep2.Ingredient = "butter";
            modelStep1.Utensil = "spatula";
            modelStep1.Workboard = "workplan";

            modelStep3.Duration = 20;
            modelStep3.Ingredient = "egg";
            modelStep3.Utensil = "plate";
            modelStep3.Workboard = "furnace";

            dishModel.ModelSteps.Add(modelStep1);
            dishModel.ModelSteps.Add(modelStep2);
            dishModel.ModelSteps.Add(modelStep3);
            dishModel.Name = "scrambled eggs";

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
