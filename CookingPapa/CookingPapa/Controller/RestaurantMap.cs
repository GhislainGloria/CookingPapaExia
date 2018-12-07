using System;
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
		protected Dictionary<string, Point> CachedDictionnary = new Dictionary<string, Point>();

		public RestaurantMap()
		{
			Actors = new List<IActor>();
			IActor testActor = ActorFactory.CreateActor("butler");
			testActor.Name = "bibi";
			testActor.Position = new Point(10, 10);
			Actors.Add(testActor);
		}
        
		public IActor GetClosest(IActor CurrentActor, string ActorName)
        {
            return null;
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
				actor.NextTick();
			}
		}
    }
}