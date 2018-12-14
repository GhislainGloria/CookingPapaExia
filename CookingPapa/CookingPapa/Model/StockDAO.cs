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

        private static List<ModelIngredient> listIngredients = null;

		private static OdbcConnection connection = null;

        private static void InitializeStockModel()
        {
			try {
				connection = new OdbcConnection(GetDatabaseString());            
			} catch (Exception e) {
				Console.WriteLine("Impossible de se connecter a la BDD!");
				Console.WriteLine(e);
				return;
			}

            const string query = "SELECT `id_model_ingr`, `nom_ingr`, `inventory-size` FROM `model_ingredient` LEFT JOIN `model_stockage` ON `model_ingredient`.`id_mod_stock` = `model_stockage`.`id_mod_stock`";

            connection.Open();

            //Create Command
			OdbcCommand cmd = new OdbcCommand(query, connection);
            //Create a data reader and Execute the command
			OdbcDataReader dataReader = cmd.ExecuteReader();
            //Read the data and store them in the list
            while (dataReader.Read())
            {
				listIngredients.Add(
					new ModelIngredient(
						dataReader["nom_ingr"].ToString(), 
						Int32.Parse(dataReader["inventory-size"].ToString()), 
						Int32.Parse(dataReader["id_model_ingr"].ToString())
					)
				);
            }

            //close Data Reader
            dataReader.Close();

            //close Connection
            connection.Close();
        }

        public static void DeleteFromStock(Ingredient ingredient)
        {
            if (listIngredients == null)
            {
                InitializeStockModel();
            }

            foreach (ModelIngredient model in listIngredients)
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

            if (listIngredients == null)
            {
                InitializeStockModel();
            }

            foreach(ModelIngredient model in listIngredients)
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
                        cmd.CommandText = "INSERT INTO stock_ingredient (id, quantite, id_model_ingr) VALUES (@id, @quantite, @id_model_ingr)";

                        // utilisation de l'objet contact passé en paramètre
                        cmd.Parameters.AddWithValue("@id", ingredient.ID);
                        cmd.Parameters.AddWithValue("@quantite", 1);
                        cmd.Parameters.AddWithValue("@id_model_ingr", model.ID);

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
			return File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/.CookingPapa/resources/config/database.conf");
        }

    }
}
