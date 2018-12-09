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
        TimeManager Time;
		private static Universe _univers = new Universe();

		private Universe() {
			Map = new RestaurantMap();
			Time = new TimeManager();
		}

        public static Universe GetInstance()
        {
			return _univers;          
        }

        public void NextTick()
        {
			Console.WriteLine("====== New Universe tick =======");
			Time.Forward();
			Map.NextActorsTick();
			ThreadPool.WaitCompletion();
        }
    }
}
