using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class IngredientFactory
    {
        public static Ingredient CreateIngredient(string ingredient)
        {
            switch (ingredient)
            {

				case "carrot":
					return new Ingredient(ingredient, 0);

                case "tomato":
                    return new Ingredient(ingredient, 0);

                case "onion":
                    return new Ingredient(ingredient, 0);

                case "pork":
                    return new Ingredient(ingredient, 0);

                case "potato":
                    return new Ingredient(ingredient, 0);

                case "meat":
                    return new Ingredient(ingredient, 0);

                case "egg":
                    return new Ingredient(ingredient, 0);

                case "butter":
                    return new Ingredient(ingredient, 0);

                default:
					Console.WriteLine("Cet ingredient n'existe pas: " + ingredient);
                    return null;
            }
        }
    }
}
