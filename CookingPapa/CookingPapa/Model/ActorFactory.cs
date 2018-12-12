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
			Actor actorMobile = new Actor();
			ActorSocket counter;
            Random random = new Random();
            actorMobile.Name = type;

            switch(type)
            {
                case "butler":
					actorMobile.Strategy = new StrategyButler();
                    return actorMobile;

                case "chef": // AKA "Chef de cuisine"
                    actorMobile.Strategy = StrategyChef.GetInstance();
                    return actorMobile;

                case "customergroup":
                    actorMobile.Strategy = StrategyGroupActor.GetInstance();
                    return actorMobile;

                case "customer":
                    int randomNumber = random.Next(1, 3);
                    actorMobile.Stack[1] = 0;
                    actorMobile.Stack[2] = randomNumber;
                    actorMobile.Stack[4] = 0;
                    return actorMobile;

                case "diver":
                    actorMobile.Strategy = StrategyDiver.GetInstance();
                    return actorMobile;

                case "clientspawner":
                    actorMobile.Strategy = StrategyClientSpawner.GetInstance();
                    actorMobile.Stack[0] = 0;
                    return actorMobile;

                case "furnace":
					actorMobile.Strategy = StrategyWorkingFridge.GetInstance();
                    return actorMobile;

                case "dishwasher":
					actorMobile.Strategy = new StrategyDishwasher();
                    return actorMobile;

                case "washingmachine":
					actorMobile.Strategy = StrategyWashingMachine.GetInstance();
                    return actorMobile;                  

                case "waiter":
					actorMobile.Strategy = new StrategyWaiter();
                    return actorMobile;

                case "kitchenclerk":
					actorMobile.Strategy = StrategyKitchenClerk.GetInstance();
                    return actorMobile;

                case "partyleader": // AKA Chef de partie
					actorMobile.Strategy = StrategyPartyLeader.GetInstance();
                    return actorMobile;

                case "roomclerks":
					actorMobile.Strategy = new StrategyRoomClerks();
                    return actorMobile;

                case "stock":
					actorMobile.Strategy = StrategyStock.GetInstance();
                    return actorMobile;

                case "headwaiter":
					actorMobile.Strategy = StrategyHeadWaiter.GetInstance();
                    return actorMobile;

                case "workingfridge":
					actorMobile.Strategy = StrategyWorkingFridge.GetInstance();
                    return actorMobile;

				case "shed": // "Armoire" in which we put all the utensils
					actorMobile.Strategy = StrategyIdle.GetInstance();
					return actorMobile;

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
