﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class CarriableItemFactory
    {

        public static ICarriableItem CreateCarriableItem(string type)
        {
            string carriable = type.Substring(0, type.IndexOf(":"));

            switch (carriable)
            {
                case "utensil":
                    return UtensileFactory.createUtensil(type);

                case "ingredient":
                    return IngredientFactory.createIngredient(type);

                default:
                    Console.WriteLine("Cet acteur n'existe pas");
                    return null;
            }
        }
    }
}
