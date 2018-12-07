using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Universe
    {
        
		public RestaurantMap Map { get; set; }
        TimeManager time;
        private float _DeltaTime;
		private static Universe _univers = new Universe();

        ThreadPool threadPool; 

		private Universe() {
			Map = new RestaurantMap
			{
				MapSize = new Size(100, 50)
			};
			time = new TimeManager();
		}

        public static Universe GetInstance()
        {
			return _univers; 

        }

        public void NextTick()
        {
			time.Forward();
			Map.NextActorsTick();
        }      
    }
}
