using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
   public interface IActor
    {
        List<ICarriableItem> Items { get; set; }
        Point Position { get; set; }
        IActor Target { get; set; }
        bool Busy { get; set; }
        Thread Thread { get; set; }
        int MaxInventorySize { get; set;}
		string Name { get; set; }
        IStrategy Strategy { get; set; }

        void CallStrategy();
		void NextTick(List<IActor> AllActors);
    }

    
}
