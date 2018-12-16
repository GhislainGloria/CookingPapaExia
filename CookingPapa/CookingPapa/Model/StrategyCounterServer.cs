using System;
using System.Linq;
using System.Collections.Generic;

namespace Model
{
	public class StrategyServerCounter : Strategy
    {
		protected static StrategyServerCounter Instance = new StrategyServerCounter();
		public static StrategyServerCounter GetInstance() { return Instance; }
		protected StrategyServerCounter() { }

		protected void Init(ActorSocket s)
		{
			s.EventGeneric += s.StrategyCallback;
			s.Initialized = true;
		}

		public override void Behavior(AbstractActor self, List<AbstractActor> all)
		{
			ActorSocket castedSelf = (ActorSocket)self;
			if (!castedSelf.Initialized) Init(castedSelf);

            // Send over to the room the clean items
			foreach(ACarriableItem i in self.Items.Where(ii => ii.Clean).ToList())
			{
				Console.WriteLine(self + ": I sent to kitchen " + CounterStringProcessor.Serialize(i));
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
					CounterStringProcessor.ProcessReceivedData((ActorSocket)self, (string)args.Arg, true);
					break;
			}
		}
	}
}
