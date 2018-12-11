using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class RestaurantMap
    {

		public Size MapSize;
		public List<AbstractActor> Actors { get; set; }
		protected Dictionary<string, Point> CachedDictionnary;

		public RestaurantMap()
		{
			Actors = new List<AbstractActor>();
            CachedDictionnary = new Dictionary<string, Point>();

			if (MessageBox.Show(
				"Cliquez sur Oui pour la cuisine, Non pour la salle",
				"Sélection de la salle", 
				MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
				// Load the kitchen map
				MapSize = new Size(20, 20);

				AbstractActor actor = ActorFactory.CreateActor("chef"); // Immobile
				actor.Position = new Point(10, 10);
				Actors.Add(actor);

				actor = ActorFactory.CreateActor("diver"); // Mobile
				actor.Position = new Point(10, 19);
				Actors.Add(actor);

				actor = ActorFactory.CreateActor("server counter");
				actor.Position = new Point(15, 15);
				Actors.Add(actor);

				actor = ActorFactory.CreateActor("partyleader");
				actor.Position = new Point(13, 13);
				Actors.Add(actor);

				actor = ActorFactory.CreateActor("kitchenclerk");
				actor.Position = new Point(1, 18);
				Actors.Add(actor);

				actor = ActorFactory.CreateActor("stock");
                actor.Position = new Point(5, 5);
				actor.Items.Add(IngredientFactory.CreateIngredient("carrot"));
                Actors.Add(actor);

				actor = ActorFactory.CreateActor("furnace");
                actor.Position = new Point(3, 18);
                Actors.Add(actor);

				actor = ActorFactory.CreateActor("shed");
				actor.Position = new Point(2, 2);
				actor.Items.Add(UtensilFactory.CreateUtensil("fork"));
				Actors.Add(actor);
            }
            else
            {
				// Load the room map
				MapSize = new Size(100, 50);
            }
		}

		public Dictionary<string, Point> DisplayableData() {         
			CachedDictionnary.Clear();
			foreach(AbstractActor actor in Actors) {
				CachedDictionnary.Add(actor.Name, actor.Position);
			}

			return CachedDictionnary;
		}

		public void NextActorsTick()
		{
			foreach (AbstractActor actor in Actors)
			{
				Task task = Task.Factory.StartNew(() => actor.NextTick(Actors));
				ThreadPool.AddTask(task);
			}
		}
    }
}