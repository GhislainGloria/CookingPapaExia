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
        public static AbstractActor CreateActor(string type)
        {
			Actor actor = new Actor();
			ActorSocket counter;
            actor.Name = type;

            switch(type)
            {
                case "butler":
                    actor.Strategy = new StrategyButler();
                    return actor;

                case "chef": // AKA "Chef de cuisine"
                    actor.Strategy = StrategyChef.GetInstance();
                    return actor;
               
                case "customer":
                    actor.Strategy = new StrategyCustomers();
                    return actor;

                case "diver":
                    actor.Strategy = StrategyDiver.GetInstance();
                    return actor;

                case "furnace":
                    actor.Strategy = StrategyWorkingFridge.GetInstance();
                    return actor;

                case "dishwasher":
                    actor.Strategy = StrategyDishwasher.GetInstance();
                    return actor;

                case "washingmachine":
                    actor.Strategy = StrategyWashingMachine.GetInstance();
                    return actor;                  

                case "headwaiter":
                    actor.Strategy = new StrategyHeadWaiter();
                    return actor;

                case "kitchenclerk":
                    actor.Strategy = StrategyKitchenClerk.GetInstance();
                    return actor;

                case "partyleader": // AKA Chef de partie
                    actor.Strategy = StrategyPartyLeader.GetInstance();
                    return actor;

                case "roomclerks":
                    actor.Strategy = new StrategyRoomClerks();
                    return actor;

                case "stock":
                    actor.Strategy = StrategyStock.GetInstance();
                    return actor;

                case "waiter":
                    actor.Strategy = new StrategyWaiter();
                    return actor;

                case "workingfridge":
                    actor.Strategy = StrategyWorkingFridge.GetInstance();
                    return actor;

				case "shed": // "Armoire" in which we put all the utensils
                    actor.Strategy = StrategyIdle.GetInstance();
					return actor;

				case "client counter":
                    counter = new ActorSocket("client")
                    {
                        Name = "counter"
                    };
                    // TODO: Set strat
                    return counter;

				case "server counter":
                    counter = new ActorSocket("server")
                    {
                        Name = "counter",
                        Strategy = StrategyServerCounter.GetInstance()
                    };
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
