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
#pragma warning disable CS0649 // Le champ 'StrategyDishwasherTest.actors' n'est jamais assigné et aura toujours sa valeur par défaut null
        private readonly List<AbstractActor> actors;
#pragma warning restore CS0649 // Le champ 'StrategyDishwasherTest.actors' n'est jamais assigné et aura toujours sa valeur par défaut null
        AbstractActor dishwasher;
        public List<AbstractActor> Actors => actors;

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

            StrategyWashingMachine.GetInstance().Behavior(dishwasher, Actors);

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
