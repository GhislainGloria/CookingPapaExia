using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Linq;

namespace Model
{
	public abstract class AbstractActor
    {
		public List<ACarriableItem> Items { get; set; }
		public List<ACommand> CommandList { get; set; }
		public List<object> Stack { get; set; }
		public Point Position { get; set; }
		public AbstractActor Target { get; set; }
		public IStrategy Strategy { get; set; }

        public bool Busy { get; set; }
		public bool Initialized { get; set; }
        public int MaxInventorySize { get; set; }
        public string Name { get; set; }
		public bool BusyWaiting { get; set; }
		public bool BusyWalking { get; set; }

        public abstract void NextTick(List<AbstractActor> AllActors);
        public abstract void CallStrategy();

		public event EventHandler EventGeneric;

        /**
         * Constructor to init basic properties
         */
		protected AbstractActor()
		{
			Initialized = false;
			Busy = false;
			BusyWaiting = false;
			BusyWalking = false;
			Items = new List<ACarriableItem>();
			Stack = new List<object>();
            CommandList = new List<ACommand>();

        }

        /**
         * Find the closest actor of a certain type, relatively to the instance's
         * position. Can return 'this' if no actor is found.
         */
		public AbstractActor FindClosest(string Name, List<AbstractActor> AllActors)
        {
            List<AbstractActor> filteredActors = AllActors.Where(a => a.Name == Name).ToList();
            AbstractActor nearest = null;
            int lowestDistance = 10000000;
            int currentDistance = 0;

            foreach (AbstractActor actor in filteredActors)
            {
                currentDistance = EvaluateDistanceTo(actor);
				if (currentDistance < lowestDistance && !ReferenceEquals(this, actor))
                {
                    lowestDistance = currentDistance;
                    nearest = actor;
                }
            }

            if (nearest == null)
            {
                Console.WriteLine("Unable to find another " + Name);
                nearest = this;
            }

            return nearest;
        }

		// Actors can only move in straight vertical or horizontal lines,
        // therefore calculating the distance of a straight diagonal line is useless.
        public int EvaluateDistanceTo(AbstractActor OtherActor)
        {
            int X = Math.Abs(OtherActor.Position.X - Position.X);
            int Y = Math.Abs(OtherActor.Position.Y - Position.Y);
            return X + Y;
        }

        /**
         * Triggers an event, usually only called from Strategies
         */
        public void TriggerEvent(string name, object arg)
        {
            MyEventArgs eventArgs = new MyEventArgs(name, arg);
            EventGeneric?.Invoke(this, eventArgs);
        }

        /**
         * Get an item from AbstractActor where and give it to the AbstractActor actor
         */
        public void FetchItem(ACarriableItem item, AbstractActor actor, List<AbstractActor> allActors)
        {
            if (!Busy)
            {
                Busy = true;
                Target = FindNearestCarriableItem(item.Name, allActors);
            }

        }

        /**
         * When an event is triggered, this method will be the callback
         */
        public void StrategyCallback(object sender, EventArgs args)
		{
			Strategy.ReactToEvent(this, (MyEventArgs)args);
		}

		public AbstractActor FindNearestCarriableItem(string itemName, List<AbstractActor> allActors)      
		{
			foreach(AbstractActor a in allActors.ToList())
			{
				foreach (ACarriableItem i in a.Items.ToList())
				{
					if (i.Name == itemName && i.Clean)
					{
						return a;
					}
				}
			}
			Console.WriteLine(Name + ": I could not find a " + itemName);
			return null;
		}
	}

	public class MyEventArgs : EventArgs
	{
		public object Arg { get; set; }
		public string EventName { get; set; }

		public MyEventArgs(string eventName, object arg) 
		{
			Arg = arg;
			EventName = eventName;
		}
	}
}
