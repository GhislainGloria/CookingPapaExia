using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Universe
    {

		public RestaurantMaps Map { get; set; }
        TimeManager time;
        private float _DeltaTime;
		private static Universe _univers = new Universe();

        ThreadPool threadPool; 

		private Universe() {
			Map = new RestaurantMaps();
			Map.MapSize = new Size(100, 50);
		}

        public static Universe GetInstance()
        {
			return _univers; 

        }

        public void NextTick()
        {
            
        }      
    }
}
