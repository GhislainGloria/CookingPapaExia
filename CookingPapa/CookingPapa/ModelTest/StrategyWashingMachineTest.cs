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
        StrategyWashingMachine strategyWashingMachine;
        List<AbstractActor> actors;
        AbstractActor workingFridge;
        List<ACarriableItem> items; 

        [SetUp()]
        public void SetUp()
        {
            strategyWashingMachine = StrategyWashingMachine.GetInstance();
            actors = new List<AbstractActor>();
            items = new List<ACarriableItem>();
            
        }

        [Test()]
        public void BehaviorTest()
        {

            

        }

        [TearDown()]
        public void TearDown()
        {

        }
    }
}
