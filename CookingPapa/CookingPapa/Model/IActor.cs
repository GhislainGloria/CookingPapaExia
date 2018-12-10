using System;
using System.Collections.Generic;
using System.Drawing;

namespace Model
{
    public interface IActor
    {      
		bool Busy { get; set; }
		bool BusyWaiting { get; set; }
        bool BusyWalking { get; set; }
		bool Initialized { get; set; }
        string Name { get; set; }
        IActor Target { get; set; }
        Point Position { get; set; }
        IStrategy Strategy { get; set; }
        int MaxInventorySize { get; set;}
        List<ACarriableItem> Items { get; set; }
		List<object> Stack { get; set; } // For all purposes
        List<ACommand> CommandList { get; set; }

        void CallStrategy();      
        void NextTick(List<IActor> AllActors);
		IActor FindNearestCarriableItem(string itemName, List<IActor> allActors);
        void TriggerEvent(string name, object arg);
		void StrategyCallback(object sender, EventArgs args);
        IActor FindClosest(string Name, List<IActor> AllActors);

        event EventHandler EventGeneric;
    } 
}
