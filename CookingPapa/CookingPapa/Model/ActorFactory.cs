using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class ActorFactory
    { 

        public static IActor CreateActor(string type)
        {
			ActorMobile actorMobile = new ActorMobile();
			actorMobile.Name = type;

            switch(type)
            {
                case "butler":
                    StrategyButler strategyButler = new StrategyButler();
                    actorMobile.SetStrategy(strategyButler);
					actorMobile.Name = "butler";
                    return actorMobile;

                case "chef":
					StrategyChef strategyChef = StrategyChef.getInstance();
                    actorMobile.SetStrategy(strategyChef);
                    return actorMobile;
               
                case "customer":
                    StrategyCustomers strategyCustomers = new StrategyCustomers();
                    actorMobile.SetStrategy(strategyCustomers);
                    return actorMobile;

                case "diver":
					StrategyDiver strategyDiver = StrategyDiver.GetInstance();
                    actorMobile.SetStrategy(strategyDiver);
                    return actorMobile;

                case "furnace":
                    StrategyFurnace strategyFurnace = new StrategyFurnace();
					actorMobile.SetStrategy(strategyFurnace);
                    return actorMobile;

                case "dishwasher":
                    StrategyDishwasher strategyDishwasher = new StrategyDishwasher();
                    actorMobile.SetStrategy(strategyDishwasher);
                    return actorMobile;

                case "washingmachine":
                    StrategyWashingmachine strategyWashingMachine = new StrategyWashingmachine();
                    actorMobile.SetStrategy(strategyWashingMachine);
                    return actorMobile;                  

                case "headwaiter":
                    StrategyHeadWaiter strategyHeadWaiter = new StrategyHeadWaiter();
                    actorMobile.SetStrategy(strategyHeadWaiter);
                    return actorMobile;

                case "kitchenclerk":
                    StrategyKitchenClerk strategyKitchenClerk = new StrategyKitchenClerk();
                    actorMobile.SetStrategy(strategyKitchenClerk);
                    return actorMobile;

                case "partyleader":
                    StrategyPartyLeader strategyPartyLeader = new StrategyPartyLeader();
                    actorMobile.SetStrategy(strategyPartyLeader);
                    return actorMobile;

                case "roomclerks":
                    StrategyRoomClerks strategyRoomClerks = new StrategyRoomClerks();
                    actorMobile.SetStrategy(strategyRoomClerks);
                    return actorMobile;

                case "stock":
                    StrategyStock strategyStock = new StrategyStock();
                    actorMobile.SetStrategy(strategyStock);
                    return actorMobile;

                case "waiter":
                    StrategyWaiter strategyWaiter = new StrategyWaiter();
                    actorMobile.SetStrategy(strategyWaiter);
                    return actorMobile;

                case "workingfridge":
                    StrategyWorkingFridge strategyWorkingFridge = new StrategyWorkingFridge();
                    actorMobile.SetStrategy(strategyWorkingFridge);
                    return actorMobile;

                default:
                     Console.WriteLine("Cet acteur n'existe pas");
                     return null;
            }
            // => end switch
        }
        // => CreateActor
    }
}
