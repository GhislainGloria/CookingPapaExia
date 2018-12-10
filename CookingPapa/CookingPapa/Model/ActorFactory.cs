using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class ActorFactory
    { 

		// TODO: Replace news by singletons
        public static IActor CreateActor(string type)
        {
			ActorMobile actorMobile = new ActorMobile();
			ActorMobileSocket counter;
			actorMobile.Name = type;

            switch(type)
            {
                case "butler":
					actorMobile.Strategy = new StrategyButler();
                    return actorMobile;

                case "chef": // AKA "Chef de cuisine"
					actorMobile.Strategy = StrategyChef.GetInstance();
                    return actorMobile;
               
                case "customer":
					actorMobile.Strategy = new StrategyCustomers();
                    return actorMobile;

                case "diver":
					actorMobile.Strategy = StrategyDiver.GetInstance();
                    return actorMobile;

                case "furnace":
					actorMobile.Strategy = new StrategyFurnace();
                    return actorMobile;

                case "dishwasher":
					actorMobile.Strategy = new StrategyDishwasher();
                    return actorMobile;

                case "washingmachine":
					actorMobile.Strategy = new StrategyWashingmachine();
                    return actorMobile;                  

                case "headwaiter":
					actorMobile.Strategy = new StrategyHeadWaiter();
                    return actorMobile;

                case "kitchenclerk":
					actorMobile.Strategy = new StrategyKitchenClerk();
                    return actorMobile;

                case "partyleader": // AKA Chef de partie
					actorMobile.Strategy = StrategyPartyLeader.GetInstance();
                    return actorMobile;

                case "roomclerks":
					actorMobile.Strategy = new StrategyRoomClerks();
                    return actorMobile;

                case "stock":
					actorMobile.Strategy = new StrategyStock();
                    return actorMobile;

                case "waiter":
					actorMobile.Strategy = new StrategyWaiter();
                    return actorMobile;

                case "workingfridge":
					actorMobile.Strategy = new StrategyWorkingFridge();
                    return actorMobile;

				case "shed": // "Armoire" in which we put all the utensils
					actorMobile.Strategy = StrategyIdle.GetInstance();
					return actorMobile;

				case "client counter":
					counter = new ActorMobileSocket("client");
					counter.Name = "counter";
                    // TODO: Set strat
					return counter;

				case "server counter":
                    counter = new ActorMobileSocket("server");
					counter.Name = "counter";
					counter.Strategy = StrategyServerCounter.GetInstance();
                    return counter;

                default:
                    Console.WriteLine("Impossible to create an actor of type " + type);
                    return null;
            }
            // => end switch
        }
        // => CreateActor
    }
}
