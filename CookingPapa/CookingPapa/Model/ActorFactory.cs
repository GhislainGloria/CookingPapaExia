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
			ActorStatic actorStatic = new ActorStatic();
			ActorMobile actorMobile = new ActorMobile();
			actorMobile.Name = type;
			actorStatic.Name = type;

            switch(type)
            {
                case "butler":
                    StrategyButler strategyButler = new StrategyButler();
                    actorStatic.SetStrategy(strategyButler);
					actorStatic.Name = "butler";
                    return actorStatic;

                case "chef":
					StrategyChef strategyChef = StrategyChef.getInstance();
                    actorStatic.SetStrategy(strategyChef);
                    return actorStatic;
               
                case "customer":
                    StrategyCustomers strategyCustomers = new StrategyCustomers();
                    actorMobile.SetStrategy(strategyCustomers);
                    return actorMobile;

                case "diver":
                    StrategyDiver strategyDiver = new StrategyDiver();
                    actorMobile.SetStrategy(strategyDiver);
                    return actorMobile;

                case "furnace":
                    StrategyFurnace strategyFurnace = new StrategyFurnace();
					actorStatic.SetStrategy(strategyFurnace);
                    return actorStatic;

                case "dishwasher":
                    {
                        ActorStatic actorStatic = new ActorStatic();
                        StrategyDishwasher strategyDiver = new StrategyDishwasher();
                        actorStatic.SetStrategy(strategyDiver);
                        return actorStatic;
                    }

                case "washingmachine":
                    {
                        ActorStatic actorStatic = new ActorStatic();
                        StrategyWashingmachine strategyDiver = new StrategyWashingmachine();
                        actorStatic.SetStrategy(strategyDiver);
                        return actorStatic;
                    }



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
                    actorStatic.SetStrategy(strategyStock);
                    return actorStatic;

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
