using System;
using System.Collections.Generic;

namespace Model
{
	public class StrategyServerCounter : Strategy
    {
		protected static StrategyServerCounter Instance = new StrategyServerCounter();
		public static StrategyServerCounter GetInstance() { return Instance; }
		protected StrategyServerCounter() { }

        /**
         * Serialization format:
         * "utensil:name:clean"
         * "order:tableid:nbdishes:name[:name]"
         * 
         * eg:
         * "utensil:tablecloth:clean"
         * "utensil:fork:dirty"
         * "order:69:5:recipe 1:recipe 2"
         */
		private void ProcessReceivedData(ActorSocket self, string data)
		{
			// Remove EOF tag and split
			string[] explode = data.Replace("<EOF>", "").Split(':');
            
			try
			{
				switch (explode[0])
                {
                    case "utensil":
						Utensil utensil = UtensilFactory.CreateUtensil(explode[1]);
						if(explode[2] == "dirty")
						{
							utensil.Clean = false;
						}
						self.Items.Add(utensil);
						break;

					case "order":
						List<DishModel> dishModels = new List<DishModel>();
						int numberOfDishes = Int32.Parse(explode[2]);

						DishModel dishModel = null;
						for (int i = 0; i < numberOfDishes; i++)
						{
							dishModel = DishModelList.GetModelByName(explode[i + 3]);
							if(dishModel != null)
							{
								dishModels.Add(dishModel);
							}
						}

						Order order = new Order(Int32.Parse(explode[1]), dishModels);

						self.TriggerEvent("order received", order);
						break;
						
                }
			}
			catch (Exception e)
			{
				Console.WriteLine("Deserialization failure");
				Console.WriteLine(e);
				return;
			}

		}

		protected void Init(ActorSocket s)
		{
			s.EventGeneric += s.StrategyCallback;
			s.Initialized = true;
		}

		public override void Behavior(AbstractActor self, List<AbstractActor> all)
		{
			ActorSocket castedSelf = (ActorSocket)self;         
			if (!castedSelf.Initialized) Init(castedSelf);
		}

		public override void ReactToEvent(AbstractActor self, MyEventArgs args)
		{
			switch(args.EventName)
			{
				case "DataReceived":
					//Console.WriteLine(self + ": I received data: " + args.Arg);
					ProcessReceivedData((ActorSocket)self, (string)args.Arg);

					break;
			}
		}
	}
}
