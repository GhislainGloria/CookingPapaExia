using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Dish
    {      
		public List<Step> Steps { get; set; }
		public int CompletedSteps { get; set; }
		protected Order Order;

		public Dish(DishModel model, Order order)
		{
			Steps = new List<Step>();
			CompletedSteps = 0;
			Order = order;

			foreach(StepModel sm in model.ModelSteps)
			{
				Step step = new Step(sm, this, 5);
				Steps.Add(step);
			}
		}

        public Dish(List<Step> steps, int completedSteps, Order order)
        {
            Steps = steps;
            CompletedSteps = completedSteps;
            Order = order;
        }

        public Dish()
        {
        }

        public void MarkStepCompleted()
		{
			CompletedSteps++;
			if (CompletedSteps >= Steps.Count)
			{
				Order.MarkDishCompleted();
			}
		}
    }
}
