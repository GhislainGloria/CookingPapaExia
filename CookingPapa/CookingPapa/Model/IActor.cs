using System;
using System.Collections.Generic;
using System.Drawing;

namespace Model
{
    public interface IActor
    {      
        bool Busy { get; set; }
		bool Initialized { get; set; }
        string Name { get; set; }
        IActor Target { get; set; }
        Point Position { get; set; }
        IStrategy Strategy { get; set; }
        int MaxInventorySize { get; set;}
        List<ICarriableItem> Items { get; set; }

        void Move();
        void CallStrategy();      
        void NextTick(List<IActor> AllActors);
        void TriggerEvent(string name, object arg);
		void StrategyCallback(object sender, EventArgs args);
        IActor FindClosest(string Name, List<IActor> AllActors);

        event EventHandler EventNewOrder;
        event EventHandler EventCookingFinished;
    } 
}
