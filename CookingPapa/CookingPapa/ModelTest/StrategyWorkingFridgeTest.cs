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
        readonly List<AbstractActor> actors;
        AbstractActor workingFridge;
        private Ingredient ingredient;

        [SetUp()]
        public void SetUp()
        {
            strategyWorkingFridge = StrategyWorkingFridge.GetInstance();          
            List<AbstractActor> actors = new List<AbstractActor>();
            ingredient = new Ingredient("beef", 2, 5);

        }

        [Test()]
        public void BehaviorTest()
        {

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
