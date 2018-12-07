using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Model
{
	public abstract class AbstractActor : IActor
    {
		public List<ICarriableItem> Items { get; set; }
		public Point Position { get; set; }
		public IActor Target { get; set; }
        public bool Busy { get; set; }
        public Thread Thread { get; set; }
        public int MaxInventorySize { get; set; }
        public string Name { get; set; }
        public IStrategy Strategy { get; set; }
        

		public abstract void NextTick();
		public abstract void CallStrategy();
        public abstract void SetStrategy(Strategy strategy);
    }
}
