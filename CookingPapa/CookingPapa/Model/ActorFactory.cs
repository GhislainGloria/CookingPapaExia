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
            GroupActor groupActor = null;
			ActorSocket counter = null;
            Random random = new Random();
            actor.Name = type;

            switch (type)
            {
                case "butler":
                    actor.Strategy = new StrategyButler();
                    return actor;

                case "chef": // AKA "Chef de cuisine"
                    actor.Strategy = StrategyChef.GetInstance();
                    return actor;

                case "customergroup":
                    groupActor = new GroupActor();
                    groupActor.Name = type;
                    groupActor.Strategy = StrategyGroupActor.GetInstance();
                    actor.Stack.Add(null);
                    return groupActor;

                case "customer":
                    actor.Strategy = StrategyCustomers.GetInstance();
                    int randomNumber = random.Next(1, 3);
                    actor.Stack.Add(false);
                    actor.Stack.Add(0);
                    actor.Stack.Add(null);
                    actor.Stack.Add(randomNumber);
                    actor.Stack.Add(0);
                    actor.Stack.Add(random);
                    return actor;

                case "diver":
                    actor.Strategy = StrategyDiver.GetInstance();
                    return actor;

                case "clientspawner":
                    actor.Strategy = StrategyClientSpawner.GetInstance();
                    actor.Stack.Add(0);
                    actor.Stack.Add(random.Next(1, 100));
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

                case "waiter":
                    actor.Strategy = new StrategyWaiter();
                    return actor;

                case "headwaiter":
					actor.Strategy = StrategyHeadWaiter.GetInstance();
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

                case "receptionnist":
					actor.Strategy = StrategyReceptionnist.GetInstance();
                    return actor;

                case "workingfridge":
                    actor.Strategy = StrategyWorkingFridge.GetInstance();
                    return actor;

				case "shed": // "Armoire" in which we put all the utensils
                    actor.Strategy = StrategyIdle.GetInstance();
					return actor;

				case "cookingplate": // "Feu de cuisson"
					actor.Strategy = StrategyIdle.GetInstance();
					return actor;

				case "client counter":
					counter = new ActorSocket("client");
					counter.MaxInventorySize = 1000000;
					counter.Strategy = StrategyCounterClient.GetInstance();
                    return counter;

				case "server counter":
					counter = new ActorSocket("server");
					counter.MaxInventorySize = 1000000;
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
