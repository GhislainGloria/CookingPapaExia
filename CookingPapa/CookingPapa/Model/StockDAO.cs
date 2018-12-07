using MySql.Data.MySqlClient;
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

        private static MySqlConnection connection = new MySqlConnection(getDatabaseString());

        public static void initializeStockModel()
        {
            string query = "SELECT `id_model_ingr`, `nom_ingr`, `inventory-size` FROM `model_ingredient` LEFT JOIN `model_stockage` ON `model_ingredient`.`id_mod_stock` = `model_stockage`.`id_mod_stock`";

            connection.Open();

            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            //Read the data and store them in the list
            while (dataReader.Read())
            {
                listIngredients.Add(new ModelIngredient(dataReader["nom_ingr"] + "", Int32.Parse(dataReader["inventory-size"] + ""), Int32.Parse(dataReader["id_model_ingr"] + "")));
            }

            //close Data Reader
            dataReader.Close();

            //close Connection
            connection.Close();
        }

        public static void deleteFromStock(Ingredient ingredient)
        {
            if (listIngredients == null)
            {
                initializeStockModel();
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
                        MySqlCommand cmd = connection.CreateCommand();

                        // Requête SQL
                        cmd.CommandText = "DELETE FROM stock_ingredient WHERE `stock_ingredient`.`idk` = @id";

                        // utilisation de l'objet contact passé en paramètre
                        cmd.Parameters.AddWithValue("@id", ingredient.ID);

                        // Exécution de la commande SQL
                        cmd.ExecuteNonQuery();

                        // Fermeture de la connexion
                        connection.Close();
                    }
                    catch
                    {
                        // Gestion des erreurs :
                        // Possibilité de créer un Logger pour les exceptions SQL reçus
                        // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
                    }
                }
            }


        }

        public static void addToStock(Ingredient ingredient)
        {

            if (listIngredients == null)
            {
                initializeStockModel();
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
                        MySqlCommand cmd = connection.CreateCommand();

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
                    catch
                    {
                        // Gestion des erreurs :
                        // Possibilité de créer un Logger pour les exceptions SQL reçus
                        // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
                    }
                }
            }

        }

        public static void addToStock(List<Ingredient> ingredients)
        {

            if (listIngredients == null)
            {
                initializeStockModel();
            }

            foreach (ModelIngredient model in listIngredients)
            {
                foreach (Ingredient ingredient in ingredients)
                {
                    if (model.Name.Equals(ingredient.Name) && model.InventorySize == ingredient.InventorySize)
                    {
                      try
                      {
                            // Ouverture de la connexion SQL
                            connection.Open();

                            // Création d'une commande SQL en fonction de l'objet connection
                            MySqlCommand cmd = connection.CreateCommand();

                            // Requête SQL
                            cmd.CommandText = "INSERT INTO stock_ingredient (quantite, id_model_ingr) VALUES (@quantite, @id_model_ingr)";

                            // utilisation de l'objet contact passé en paramètre
                            cmd.Parameters.AddWithValue("@quantite", 1);
                            cmd.Parameters.AddWithValue("@id_model_ingr", model.ID);

                            // Exécution de la commande SQL
                            cmd.ExecuteNonQuery();

                            // Fermeture de la connexion
                            connection.Close();
                        }
                        catch
                        {
                            // Gestion des erreurs :
                            // Possibilité de créer un Logger pour les exceptions SQL reçus
                            // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
                        }
                    }
                } // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
            }
        }


        public static string getDatabaseString()
        {
            return File.ReadAllText(Directory.GetCurrentDirectory() + "/../../../../resources/config/database.conf");
        }

    }
}
