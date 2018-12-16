using System.Data.Odbc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class StockDAO
    {

        private static List<ModelIngredient> ListIngredientModels = null;
		private static List<Ingredient> ListIngredientInstances = null;
		private static OdbcConnection connection = null;

        private static void InitializeStockModel()
        {
			try 
			{
				connection = new OdbcConnection(GetDatabaseString());            
			} 
			catch (Exception e) 
			{
				Console.WriteLine("Impossible de se connecter a la BDD!");
				Console.WriteLine(e);
				return;
			}

			ListIngredientModels = new List<ModelIngredient>();
            ListIngredientInstances = new List<Ingredient>();         

            // Retrieve models
            string query = "SELECT `id_model_ingr`, `nom_ingr`, `inventory-size` FROM `model_ingredient` LEFT JOIN `model_stockage` ON `model_ingredient`.`id_mod_stock` = `model_stockage`.`id_mod_stock`";
         
            connection.Open();

            //Create Command
			using(OdbcCommand cmd = new OdbcCommand(query, connection))
			{
				//Create a data reader and Execute the command
                OdbcDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    ListIngredientModels.Add(
                        new ModelIngredient(
                            dataReader["nom_ingr"].ToString(),
                            Int32.Parse(dataReader["inventory-size"].ToString()),
                            Int32.Parse(dataReader["id_model_ingr"].ToString())
                        )
                    );
                }

				dataReader.Close();

                // Retrieve stocks
                query = "SELECT * FROM stock_ingredient;";            
				cmd.CommandText = query;            

				dataReader = cmd.ExecuteReader();
				//Read the data and store them in the list
                while (dataReader.Read())
                {
					int stock = Int32.Parse(dataReader["quantite"].ToString());
					int modelId = 0;
					string name = String.Empty;
					bool found = false;

					for (int i = 0; i < stock; i++)
					{
						modelId = Int32.Parse(dataReader["id_model_ingr"].ToString());
						found = false;

						foreach(ModelIngredient mi in ListIngredientModels)
						{
							if(mi.ID == modelId)
							{
								name = mi.Name;                        
								found = true;
								break;
							}
						}
						if (!found) continue;

						ListIngredientInstances.Add(IngredientFactory.CreateIngredient(name, false));
					}
                }

                //close Data Reader
                dataReader.Close();

			}                     

            //close Connection
            connection.Close();
        }

        public static void DeleteFromStock(Ingredient ingredient)
        {
            if (ListIngredientModels == null)
            {
                InitializeStockModel();
            }

            foreach (ModelIngredient model in ListIngredientModels)
            {
                if (model.Name.Equals(ingredient.Name) && model.InventorySize == ingredient.InventorySize)
                {
                    try
                    {
                        // Ouverture de la connexion SQL
                        connection.Open();

                        // Création d'une commande SQL en fonction de l'objet connection
						OdbcCommand cmd = connection.CreateCommand();

                        // Requête SQL
                        cmd.CommandText = "DELETE FROM stock_ingredient WHERE `stock_ingredient`.`idk` = @id";

                        // utilisation de l'objet contact passé en paramètre
                        cmd.Parameters.AddWithValue("@id", ingredient.ID);

                        // Exécution de la commande SQL
                        cmd.ExecuteNonQuery();

                        // Fermeture de la connexion
                        connection.Close();
                    }
					catch(Exception e)
                    {
						// Gestion des erreurs :
						// Possibilité de créer un Logger pour les exceptions SQL reçus
						// Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
						Console.WriteLine("Could not delete from stock in DB!");
						Console.WriteLine(e);
                    }
                }
            }


        }

        public static void AddToStock(Ingredient ingredient)
        {

            if (ListIngredientModels == null)
            {
                InitializeStockModel();
            }

            foreach(ModelIngredient model in ListIngredientModels)
            {
                if (model.Name.Equals(ingredient.Name))
                {
                    try
                    {
                        // Ouverture de la connexion SQL
                        connection.Open();

                        // Création d'une commande SQL en fonction de l'objet connection
						using(OdbcCommand cmd = connection.CreateCommand())
						{
							// Requête SQL
                            cmd.CommandText = "UPDATE stock_ingredient SET quantite = quantite + 1 WHERE id_model_ingr = " + model.ID + ";";

                            // utilisation de l'objet contact passé en paramètre
                            // Sometimes work, sometimes doesn't.. Weird
                            //cmd.Parameters.Add("@id_model_ingr", OdbcType.Int).Value = 1;//model.ID;
                            //cmd.Parameters.Add("@id_model_ingr", OdbcType.Int).Value = 1;//model.ID;

                            // Exécution de la commande SQL
                            cmd.ExecuteNonQuery();

                            // Now request addition if none were in db
                            cmd.CommandText = "INSERT IGNORE INTO stock_ingredient(quantite, id_model_ingr) VALUES(1, " + model.ID + ");";
                            cmd.ExecuteNonQuery();
						}

                        // Fermeture de la connexion
                        connection.Close();
                    }
					catch(Exception e)
                    {
						// Gestion des erreurs :
						// Possibilité de créer un Logger pour les exceptions SQL reçus
						// Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
						Console.WriteLine("Could not add to stock in DB!");
						Console.WriteLine(e);
                    }
                }
            }

        }

        public static void AddToStock(List<Ingredient> ingredients)
        {
			foreach(Ingredient i in ingredients) {
				AddToStock(i);
			}
        }


        public static string GetDatabaseString()
        {
			return File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/CookingPapa/resources/config/database.conf");
        }

		public static int GetIngredientModelDatabaseId(string name)
		{
			if (ListIngredientModels == null)
            {
                InitializeStockModel();
            }

			foreach(ModelIngredient mi in ListIngredientModels)
			{
				if(mi.Name == name)
				{
					return mi.ID;
				}
			}

			return 0;
		}

		public static List<Ingredient> GetStock()
		{
			if (ListIngredientModels == null)
            {
                InitializeStockModel();
			}

			return ListIngredientInstances;
		}
    }
}
