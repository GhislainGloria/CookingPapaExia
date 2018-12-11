using System.Collections.Generic;
using System;
using System.Linq;

namespace Model
{
    class StrategyDiver : Strategy
    {
		private static StrategyDiver Instance = new StrategyDiver();
		public static StrategyDiver GetInstance()
        {
            
            return Instance;
        }

		private StrategyDiver() {}


        private void InitDiver(IActor diver, List<IActor> all)
        {
           
            List<IActor> allCounters = all.Where(a => a.Name == "counter").ToList();
            foreach (IActor a in allCounters)

            {
                a.EventGeneric += diver.StrategyCallback; 

            }
            diver.Initialized = true; 


        }


		public override void Behavior(IActor self, List<IActor> all)
		{
            if (!self.Initialized) InitDiver(self,all);

            //prend les truc salle sur le coomptoir
            // repli le lave vaiselle 
            // vide la la vaiselle 

            //va cherche les truc a laver aupres des autres
            // lave a la main un petit truc 
            // lave a la main un gros truc 



            /*if (!self.Busy)
			{
				self.Target = self.FindClosest("chef", all);
			}
			self.Move();*/
        }

		public override void ReactToEvent(IActor self, MyEventArgs args)
		{
			throw new System.NotImplementedException();
		}
	}
}
