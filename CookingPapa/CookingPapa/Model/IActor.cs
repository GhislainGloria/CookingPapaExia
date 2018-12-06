using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
   public interface IActor
    {
        string Name { get; set; }
        List<ICarriableItem> Items { get; set; }
        Position Position { get; set; }
        IActor Target { get; set; }
        bool Busy { get; set; }
        Thread Thread { get; set; }
        int MaxInventorySize { get; set;}
        Strategy Strategy { get; set; }

        void CallStrategy();

        void SetStrategy(Strategy strategy);

        void NextTick();

        void Event();
    }

    
}
