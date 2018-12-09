using System;
using System.Collections.Generic;

namespace Model
{
    public class DishModel
    {
		public List<StepModel> ModelSteps { get; set; }
		public string Name { get; set; }

        public DishModel()
        {
			ModelSteps = new List<StepModel>();
        }
    }
}
