using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Linq;
using Model;

namespace Controller
{
    public class RestaurantMap
    {

		public Size MapSize;
		public List<AbstractActor> Actors { get; set; }
		protected List<Tuple<string, Point>> CachedDictionnary;

		public RestaurantMap()
		{
			Actors = new List<AbstractActor>();
			CachedDictionnary = new List<Tuple<string, Point>>();

			if (MessageBox.Show(
				"Cliquez sur Oui pour la cuisine, Non pour la salle",
				"Sélection de la salle", 
				MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
				// Load the kitchen map
				MapSize = new Size(15, 15);
                AbstractActor actor2 = null;

				AbstractActor actor = ActorFactory.CreateActor("diver");
				actor.Position = new Point(10, 11);
				Actors.Add(actor);

				actor2 = ActorFactory.CreateActor("server counter");
				actor2.Position = new Point(0, 7);
				Actors.Add(actor2);

				actor = ActorFactory.CreateActor("partyleader");
				actor.Position = new Point(13, 13);
				Actors.Add(actor);

				actor = ActorFactory.CreateActor("partyleader");
                actor.Position = new Point(14, 13);
                Actors.Add(actor);

				actor = ActorFactory.CreateActor("kitchenclerk");
				actor.Position = new Point(1, 10);
				Actors.Add(actor);

				actor = ActorFactory.CreateActor("kitchenclerk");
                actor.Position = new Point(1, 11);
                Actors.Add(actor);

				actor = ActorFactory.CreateActor("stock");
                actor.Position = new Point(5, 5);
				for (int _ = 0; _ < 40; _++)
				{
					actor.Items.Add(IngredientFactory.CreateIngredient("carrot"));
					actor.Items.Add(IngredientFactory.CreateIngredient("tomato"));
				}
                Actors.Add(actor);

				actor = ActorFactory.CreateActor("furnace");
                actor.Position = new Point(3, 10);
                Actors.Add(actor);

				actor = ActorFactory.CreateActor("cookingplate");
                actor.Position = new Point(5, 10);
                Actors.Add(actor); 

				actor = ActorFactory.CreateActor("shed");
				actor.Position = new Point(2, 2);
				for (int _ = 0; _ < 3; _++)
                {
					actor.Items.Add(UtensilFactory.CreateUtensil("fork"));
					actor.Items.Add(UtensilFactory.CreateUtensil("fork"));
					actor.Items.Add(UtensilFactory.CreateUtensil("blender"));
                }
				Actors.Add(actor);

				actor = ActorFactory.CreateActor("dishwasher");
                actor.Position = new Point(3, 2);
                Actors.Add(actor);

                actor = ActorFactory.CreateActor("chef"); // Immobile
                actor.Position = new Point(10, 10);
                actor2.EventGeneric += actor.StrategyCallback;
                Actors.Add(actor);
            }
            else
            {
                // Load the room map
                MapSize = new Size(30, 15);

                AbstractActor actor = ActorFactory.CreateActor("clientspawner");
                actor.Position = new Point(15, 1);
                Actors.Add(actor);

				actor = ActorFactory.CreateActor("client counter");
				actor.Position = new Point(10, 14);        
                Actors.Add(actor);

                actor = ActorFactory.CreateActor("receptionnist");
                actor.Position = new Point(5, 11);
                Actors.Add(actor);

            }
		}

		public List<Tuple<string, Point>> DisplayableData() {         
			CachedDictionnary.Clear();
			foreach(AbstractActor actor in Actors.ToList()) {
				CachedDictionnary.Add(new Tuple<string, Point>(actor.Name, actor.Position));
			}

			return CachedDictionnary;
		}

		public void NextActorsTick()
		{
			foreach (AbstractActor actor in Actors.ToList())
			{
				Task task = Task.Factory.StartNew(() => actor.NextTick(Actors));
				ThreadPool.AddTask(task);
			}
		}
    }
}