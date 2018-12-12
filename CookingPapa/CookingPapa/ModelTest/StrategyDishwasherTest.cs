using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    class StrategyDishwasherTest
    {
        List<AbstractActor> actors;
        AbstractActor dishwasher;

        [SetUp()]
        public void SetUp()
        {


        }

        [Test()]
        public void BehaviorTest()
        {
            dishwasher = ActorFactory.CreateActor("washingmachine");
            ACarriableItem fork = UtensilFactory.CreateUtensil("fork");
            ACarriableItem plate = UtensilFactory.CreateUtensil("plate");

            Assert.AreEqual(plate.Clean, fork.Clean);

            dishwasher.Items.Add(fork);
            dishwasher.Items.Add(plate);

            StrategyWashingMachine.GetInstance().Behavior(dishwasher, actors);

            foreach (ACarriableItem item in dishwasher.Items)
            {
                Assert.IsTrue(item.Clean);
            }




        }



        [TearDown()]
        public void TearDown()
        {

        }
    }
}
