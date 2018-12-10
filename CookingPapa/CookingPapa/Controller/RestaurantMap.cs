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
		public List<IActor> Actors { get; set; }
		protected Dictionary<string, Point> CachedDictionnary;

		public RestaurantMap()
		{
			Actors = new List<IActor>();
            CachedDictionnary = new Dictionary<string, Point>();

			if (MessageBox.Show(
				"Cliquez sur Oui pour la cuisine, Non pour la salle",
				"Sélection de la salle", 
				MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
				// Load the kitchen map
				MapSize = new Size(50, 50);

				IActor actor = ActorFactory.CreateActor("chef"); // Immobile
				actor.Position = new Point(10, 10);
				Actors.Add(actor);

				actor = ActorFactory.CreateActor("diver"); // Mobile
				actor.Position = new Point(10, 20);
				Actors.Add(actor);

				actor = ActorFactory.CreateActor("server counter");
				actor.Position = new Point(15, 15);
				Actors.Add(actor);

				actor = ActorFactory.CreateActor("partyleader");
				actor.Position = new Point(25, 25);
				Actors.Add(actor);

				actor = ActorFactory.CreateActor("kitchenclerk");
				actor.Position = new Point(30, 30);            
				Actors.Add(actor);

				actor = ActorFactory.CreateActor("shed");
				actor.Position = new Point(2, 2);
				actor.Items.Add(UtensileFactory.createUtensil("fork")); // TODO
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
			foreach(IActor actor in Actors) {
				CachedDictionnary.Add(actor.Name, actor.Position);
			}

			return CachedDictionnary;
		}

		public void NextActorsTick()
		{
			foreach (IActor actor in Actors)
			{
				Task task = Task.Factory.StartNew(() => actor.NextTick(Actors));
				ThreadPool.AddTask(task);            
			}
		}
    }
}