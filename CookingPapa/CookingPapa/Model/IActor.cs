using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CookingPapa
{
    interface IActor
    {
        List<ICarriableItem> Items { get; set; }
        Position Position { get; set; }
        IActor Target { get; set; }
        bool Busy { get; set; }
        Thread Thread { get; set; }
        int MaxInventorySize { get; set;}
        //Strategy strategy { get; set; }

        void CallStrategy();

        void NextTick();

        void Event();
    }

    
}
