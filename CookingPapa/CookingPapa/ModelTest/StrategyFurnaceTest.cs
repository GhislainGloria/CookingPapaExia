using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using NUnit.Framework;

namespace ModelTest
{
    public class StrategyFurnaceTest
    {
        StrategyFurnace strategyFurnace;
#pragma warning disable CS0649 // Le champ 'StrategyFurnaceTest.actors' n'est jamais assigné et aura toujours sa valeur par défaut null
        readonly List<AbstractActor> actors;
#pragma warning restore CS0649 // Le champ 'StrategyFurnaceTest.actors' n'est jamais assigné et aura toujours sa valeur par défaut null
        AbstractActor Furnace;
        private Ingredient ingredient;

        [SetUp()]
        public void SetUp()
        {
            strategyFurnace = StrategyFurnace.GetInstance();
          
            List<AbstractActor> actors = new List<AbstractActor>();
            ingredient = new Ingredient("beef", 2, 5);
        }

        [Test()]
        public void BehaviorTest()
        {
            Furnace = ActorFactory.CreateActor("furnace");
            
                 strategyFurnace.Behavior(Furnace, actors);
                 if (Furnace.Items.Contains(ingredient))
                     {
                         Assert.IsTrue(Furnace.Busy);
                     }
                     if (Furnace.Busy == true)
                     {
                         Assert.AreSame(Furnace.Items, ingredient);
                     }
                     if (Furnace.Stack.Count > 0)
                     {
                         Assert.IsTrue(Furnace.Busy);
                     }
                     if (Furnace.Stack.Count == 0)
                     {
                         Assert.IsFalse(Furnace.Busy);
                     }
             
        }

        [TearDown()]
        public void TearDown()
        {

        }

    }

}
