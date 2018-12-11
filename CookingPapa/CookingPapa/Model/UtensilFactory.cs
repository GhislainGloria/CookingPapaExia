using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class UtensilFactory
    {
        public static Utensil CreateUtensil(string utensil)
        {
            switch (utensil)
            {
                case "pan":
                    return new Utensil(utensil, 7);

                case "stoves":
                    return new Utensil(utensil, 7);

                case "wooden spoon":
                    return new Utensil(utensil, 3);

                case "blender":
                    return new Utensil(utensil, 8);

                case "salad bowl":
                    return new Utensil(utensil, 6);

                case "pressure cooker":
                    return new Utensil(utensil, 8);

                case "juicer":
                    return new Utensil(utensil, 8);

                case "sieve":
                    return new Utensil(utensil, 5);

                case "funnel":
                    return new Utensil(utensil, 3);

                case "kitchen knife":
                    return new Utensil(utensil, 3);

                case "small plate":
                    return new Utensil(utensil, 2);

                case "plate":
                    return new Utensil(utensil, 4);

                case "curved plate":
                    return new Utensil(utensil, 4);

                case "dessert plate":
                    return new Utensil(utensil, 3);

                case "fork":
                    return new Utensil(utensil, 1);

                case "knife":
                    return new Utensil(utensil, 1);

                case "soop spoon":
                    return new Utensil(utensil, 1);

                case "coffee spoon":
                    return new Utensil(utensil, 1);

                case "water glass":
                    return new Utensil(utensil, 2);

                case "wine glass":
                    return new Utensil(utensil, 3);

                case "champagne glass":
                    return new Utensil(utensil, 3);

                case "coffee cup":
                    return new Utensil(utensil, 2);

                case "coffee plate":
                    return new Utensil(utensil, 2);

                case "cloth napkins":
                    return new Utensil(utensil, 1);

                case "tablecloths":
                    return new Utensil(utensil, 4);

                default:
                    Console.WriteLine("Cet ustensile n'existe pas");
                    return null;
            }
        }
    }
}
