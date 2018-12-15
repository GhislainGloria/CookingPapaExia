using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using NUnit.Framework;

namespace ModelTest
{
    public class StrategyWorkingFridgeTest
    {
        StrategyWorkingFridge strategyWorkingFridge;
        private Ingredient ingredient;

        [SetUp()]
        public void SetUp()
        {
            
                      
            

        }

        [Test()]
        public void BehaviorTest()
        {

            AbstractActor workingFridge = ActorFactory.CreateActor("workingfridge");
            strategyWorkingFridge = StrategyWorkingFridge.GetInstance();
            List<AbstractActor> actors = new List<AbstractActor>();
            ingredient = new Ingredient("meat", 0);

            strategyWorkingFridge.Behavior(workingFridge, actors);
                 if (workingFridge.Items.Contains(ingredient))
                     {
                         Assert.IsTrue(workingFridge.Busy);
                     }
                     if (workingFridge.Busy == true)
                     {
                         Assert.AreSame(workingFridge.Items, ingredient);
                     }
                     if (workingFridge.Stack.Count > 0)
                     {
                         Assert.IsTrue(workingFridge.Busy);
                     }
                     if (workingFridge.Stack.Count == 0)
                     {
                         Assert.IsFalse(workingFridge.Busy);
                     }
             
        }

        [TearDown()]
        public void TearDown()
        {

        }

    }

}
