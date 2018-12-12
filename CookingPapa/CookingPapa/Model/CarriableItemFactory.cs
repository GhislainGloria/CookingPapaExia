using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class CarriableItemFactory
    {
        /**
         * Usage: 
         * @param type: like: type:name
         * 
         * e.g: utensil:carrot
         */
        public static ACarriableItem CreateCarriableItem(string type)
        {
			string[] explode = type.Split(':');
			if(explode.Length != 2)
			{
				Console.WriteLine("Wrong format: " + type);
				return null;
			}

			switch (explode[0])
            {
                case "utensil":
					return UtensilFactory.CreateUtensil(explode[1]);

                case "ingredient":
					return IngredientFactory.CreateIngredient(explode[1]);

                default:
					Console.WriteLine("L'item " + type + " ne peut etre instancie.");
                    return null;
            }
        }
    }
}
