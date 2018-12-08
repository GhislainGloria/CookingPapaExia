using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    class ActorMobileTest
    {

        [SetUp()]


        [Test()]
        public void CallStrategyTest()
        {

        }

        [Test()]
        public void NextTickTest()
        {

        }

        [Test()]
        public void Move()
        {
            ActorMobile butler = (ActorMobile)ActorFactory.CreateActor("butler");
            IActor furnace = ActorFactory.CreateActor("furnace");
            butler.Position = new Point(10, 20);
            furnace.Position = new Point(60, 40);
            Assert.AreNotEqual(butler.Position, furnace.Position);
            butler.Move(furnace);
            Assert.AreEqual(butler.Position, furnace.Position);


        }

        public void SetStrategyTest(Strategy strategy)
        {

        }

        [TearDown()]
        public void TearDown()
        {

        }
    }
}
