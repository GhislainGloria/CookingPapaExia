using System;
using System.Collections.Generic;

namespace Model
{
    public static class CounterStringProcessor
    {
		/**
		 * Everything received ends up in the recipient's inventory.
		 * 
         * Serialization format:
         * "utensil:name"
         * "order:tableid:nbdishes:name[:name]"
         * 
         * eg:
         * "utensil:tablecloth:clean"
         * "utensil:fork:dirty"
         * "order:69:5:recipe 1:recipe 2"
         */
		public static void ProcessReceivedData(ActorSocket self, string data, bool asServer)
        {
            // Remove EOF tag and split
            string[] explode = data.Replace("<EOF>", "").Split(':');

            try
            {
                switch (explode[0])
                {
                    case "utensil":
                        Utensil utensil = UtensilFactory.CreateUtensil(explode[1]);

						if (utensil == null)
							return;

						utensil.Clean = !asServer;

                        self.Items.Add(utensil);
                        break;

                    case "order":
                        List<DishModel> dishModels = new List<DishModel>();
                        int numberOfDishes = Int32.Parse(explode[2]);

                        DishModel dishModel = null;
                        for (int i = 0; i < numberOfDishes; i++)
                        {
                            dishModel = DishModelList.GetModelByName(explode[i + 3]);
                            if (dishModel != null)
                            {
                                dishModels.Add(dishModel);
                            }
                        }

                        Order order = new Order(Int32.Parse(explode[1]), dishModels);
						// TODO: set dirty

                        self.TriggerEvent("order received", order);
                        break;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Deserialization failure");
                Console.WriteLine(e);
                return;
            }
        }

        /**
         * Serialize an item into a string so that it can be sent over
         * sockets
         */
		public static string Serialize(ACarriableItem item)
		{
			string type = item.GetType().ToString();

			if(type.Contains("Utensil"))
			{
				return "utensil:" + item.Name;
			}

			if (type.Contains("Order"))
			{
				Order cast = (Order)item;
				string ret = "order:" + cast.TableID + ":" + cast.Recipes.Count;

				foreach(DishModel dm in cast.Recipes)
				{
					ret += ":" + dm.Name;
				}

				return ret;
			}

			Console.WriteLine("Could not serialize item " + item?.Name);

			return String.Empty;
		}
    }
}
