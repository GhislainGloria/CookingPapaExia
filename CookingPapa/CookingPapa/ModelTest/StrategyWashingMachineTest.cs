using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    class StrategyWashingMachineTest
    {
  
        List<AbstractActor> actors;
        AbstractActor washingMachine;

        public List<AbstractActor> Actors { get => actors; set => actors = value; }

        [SetUp()]
        public void SetUp()
        {
            
            
        }

        [Test()]
        public void BehaviorTest()
        {
            washingMachine = ActorFactory.CreateActor("washingmachine");
            ACarriableItem fork = UtensilFactory.CreateUtensil("fork");
            ACarriableItem plate = UtensilFactory.CreateUtensil("plate");

            Assert.AreEqual(plate.Clean, fork.Clean);

            washingMachine.Items.Add(fork);
            washingMachine.Items.Add(plate);

            StrategyWashingMachine.GetInstance().Behavior(washingMachine, Actors);

            foreach (ACarriableItem item in washingMachine.Items)
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
