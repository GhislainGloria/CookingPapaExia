using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Step
    {
		public bool Prepared { get; private set; }
		public StepModel Model { get; }
		public Dish Dish { get; }
		public int TimeSpentSoFar = 0;

		public Step(StepModel model, Dish dish)
		{
			Model = model;
			Dish = dish;
			Prepared = false;
		}

		public void Complete()
		{
			Prepared = true;
			Dish.MarkStepCompleted();
		}
    }
}
