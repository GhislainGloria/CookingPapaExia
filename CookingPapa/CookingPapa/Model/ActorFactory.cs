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
            switch(type)
            {
                case "butler":
                    {
                        ActorStatic actorStatic = new ActorStatic();
                        StrategyButler strategyButler = new StrategyButler();
                        actorStatic.SetStrategy(strategyButler);
                        return actorStatic;
                    }

                case "chef":
                    {
                        ActorStatic actorStatic = new ActorStatic();
                        StrategyChef strategyChef = new StrategyChef();
                        actorStatic.SetStrategy(strategyChef);
                        return actorStatic;
                    }

                case "customer":
                {
                    ActorMobile actorMobile = new ActorMobile();
                    StrategyCustomers strategyCustomers = new StrategyCustomers();
                    actorMobile.SetStrategy(strategyCustomers);
                    return actorMobile;
                }

                case "diver":
                    {
                        ActorMobile actorMobile = new ActorMobile();
                        StrategyDiver strategyDiver = new StrategyDiver();
                        actorMobile.SetStrategy(strategyDiver);
                        return actorMobile;
                    }

                case "furnace":
                    {
                        ActorStatic actorStatic = new ActorStatic();
                        StrategyFurnace strategyFurnace = new StrategyFurnace();
                        actorStatic.SetStrategy(strategyFurnace);
                        return actorStatic;
                    }

                case "headwaiter":
                    {
                        ActorMobile actorMobile = new ActorMobile();
                        StrategyHeadWaiter strategyHeadWaiter = new StrategyHeadWaiter();
                        actorMobile.SetStrategy(strategyHeadWaiter);
                        return actorMobile;
                    }

                case "kitchenclerk":
                    {
                        ActorMobile actorMobile = new ActorMobile();
                        StrategyKitchenClerk strategyKitchenClerk = new StrategyKitchenClerk();
                        actorMobile.SetStrategy(strategyKitchenClerk);
                        return actorMobile;
                    }

                case "partyleader":
                    {
                        ActorMobile actorMobile = new ActorMobile();
                        StrategyPartyLeader strategyPartyLeader = new StrategyPartyLeader();
                        actorMobile.SetStrategy(strategyPartyLeader);
                        return actorMobile;
                    }

                case "roomclerks":
                    {
                        ActorMobile actorMobile = new ActorMobile();
                        StrategyRoomClerks strategyRoomClerks = new StrategyRoomClerks();
                        actorMobile.SetStrategy(strategyRoomClerks);
                        return actorMobile;
                    }

                case "stock":
                    {
                        ActorStatic actorStatic = new ActorStatic();
                        StrategyStock strategyStock = new StrategyStock();
                        actorStatic.SetStrategy(strategyStock);
                        return actorStatic;
                    }

                case "waiter":
                    {
                        ActorMobile actorMobile = new ActorMobile();
                        StrategyWaiter strategyWaiter = new StrategyWaiter();
                        actorMobile.SetStrategy(strategyWaiter);
                        return actorMobile;
                    }

                case "workingfridge":
                    {
                        ActorMobile actorMobile = new ActorMobile();
                        StrategyWorkingFridge strategyWorkingFridge = new StrategyWorkingFridge();
                        actorMobile.SetStrategy(strategyWorkingFridge);
                        return actorMobile;
                    }

                default:
                {
                     Console.WriteLine("Cet acteur n'existe pas");
                       return null;
                }
            }
            

            
        }
    }
}
