using System;
using System.Collections.Generic;
using System.Drawing;
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

		public bool Initialized { get; set; }
		public int MaxInventorySize { get; set; }
        public int InventorySize { get; set; }
        public string Name { get; set; }
		public bool Busy { get; set; }
		public bool BusyWaiting { get; set; }
		public bool BusyWalking { get; set; }
		public bool AcceptItemExchange { get; set; }

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
			InventorySize = 0;
			MaxInventorySize = 10;
			AcceptItemExchange = true;
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
                nearest = null;
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
         * Same as above, but with an additionnal argument
         */
		public void TriggerEvent(string name, object arg, object arg2)
        {
            MyEventArgs eventArgs = new MyEventArgs(name, arg, arg2);
            EventGeneric?.Invoke(this, eventArgs);
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

		public bool CanCarry(ACarriableItem item)
		{
			return InventorySize + item.InventorySize <= MaxInventorySize;
		}

		public bool GiveItemTo(AbstractActor giveTo, string item)
		{
			if(!giveTo.AcceptItemExchange)
			{
				Console.WriteLine(
					Name + ": Can't give my " + item + " because " + giveTo.Name + " doesn't accept item trades at the moment."
				);
				return false;
			}

			if (EvaluateDistanceTo(giveTo) <= 2)
            {
                foreach (ACarriableItem itemFrom in Items)
                {
					if (itemFrom.Name.Equals(item))
                    {
						if(giveTo.CanCarry(itemFrom))
						{
							Items.Remove(itemFrom);
                            giveTo.Items.Add(itemFrom);
							InventorySize -= itemFrom.InventorySize;
							giveTo.InventorySize += itemFrom.InventorySize;
                            Console.WriteLine(
								Name + ": I gave my " + item + " to " + giveTo.Name
                            );
                            return true;
						}
						else
						{
							Console.WriteLine(
								Name + ": I cannot give a " + item + " to " + giveTo.Name + " because he doesn't have enough inventory space."
							);
							return false;
						}                  
                    }
                }

				Console.WriteLine(
					Name + ": I cannot give a " + item + " to " + giveTo.Name + " because I don't have any in my inventory."
				);
				return false;
            }

			Console.WriteLine(
				Name + ": I cannot give a " + item + " to " + giveTo.Name + " because I'm too far away!"
			);
			return false;
		}

		public bool GetItemFrom(AbstractActor getFrom, string item)
        {         
			if (!getFrom.AcceptItemExchange)
            {
                Console.WriteLine(
					Name + ": Can't grab a " + item + " because " + getFrom.Name + " doesn't accept item trades at the moment."
                );
                return false;
            }


			if (EvaluateDistanceTo(getFrom) <= 2)
            {
                foreach (ACarriableItem itemFrom in getFrom.Items)
                {
                    if (itemFrom.Name.Equals(item))
                    {
                        if (CanCarry(itemFrom))
                        {
							getFrom.Items.Remove(itemFrom);
                            Items.Add(itemFrom);
							InventorySize += itemFrom.InventorySize;
							getFrom.InventorySize -= itemFrom.InventorySize;
                            Console.WriteLine(
								Name + ": I took a " + item + " from " + getFrom.Name
                            );
                            return true;
                        }
                        else
                        {
                            Console.WriteLine(
								Name + ": I cannot grab a " + item + " from " + getFrom.Name + " because I don't have enough inventory space."
                            );
                            return false;
                        }
                    }
                }

                Console.WriteLine(
					Name + ": I cannot grab a " + item + " from " + getFrom.Name + " because he doesn't have any in his inventory."
                );
                return false;
            }

            Console.WriteLine(
				Name + ": I cannot grab a " + item + " from " + getFrom.Name + " because I'm too far away!"
            );
            return false;
        }
	}
}
