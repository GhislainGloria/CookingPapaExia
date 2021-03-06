﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace Model
{
    public class StrategyCounterClient : Strategy
    {
		protected static StrategyCounterClient Instance = new StrategyCounterClient();
		public static StrategyCounterClient GetInstance() { return Instance; }
		protected StrategyCounterClient() { }

		protected void Init(ActorSocket s)
        {
            s.EventGeneric += s.StrategyCallback;
            s.Initialized = true;
        }

        public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {
            ActorSocket castedSelf = (ActorSocket)self;
            if (!castedSelf.Initialized) Init(castedSelf);

            // Send over to the kitchen the dirty items
            foreach (ACarriableItem i in self.Items.Where(ii => !ii.Clean).ToList())
            {
				Console.WriteLine(self + ": sending over to the kitchen " + CounterStringProcessor.Serialize(i));
                castedSelf.Send(CounterStringProcessor.Serialize(i));
				self.Items.Remove(i);
            }
        }

        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
			switch (args.EventName)
            {
                case "DataReceived":
                    Console.WriteLine(self + ": I received data: " + args.Arg);
                    CounterStringProcessor.ProcessReceivedData((ActorSocket)self, (string)args.Arg, false);
                    break;
            }
        }
    }
}
