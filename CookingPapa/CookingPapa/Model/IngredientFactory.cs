using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class IngredientFactory
    {
		public static Ingredient CreateIngredient(string ingredient, bool updateDatabase = true)
        {
            switch (ingredient)
            {
                case "ingredient":
					return new Ingredient(ingredient, 1, 1, updateDatabase);

				case "carrot":
					return new Ingredient(ingredient, 1, 1, updateDatabase);

				case "tomato":
					return new Ingredient(ingredient, 1, 1, updateDatabase);

                default:
					Console.WriteLine("Cet ingredient n'existe pas: " + ingredient);
                    return null;
            }
        }
    }
}
