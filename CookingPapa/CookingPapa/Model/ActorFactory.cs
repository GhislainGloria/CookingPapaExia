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
                        StrategyFurnace strategyDiver = new StrategyFurnace();
                        actorStatic.SetStrategy(strategyDiver);
                        return actorStatic;
                    }


                default:
                {
                     return null;
                }
            }
            

            
        }
    }
}
