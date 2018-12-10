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
    class AbstractActorTest
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
        public void MoveTest()
        {
            AbstractActor butler = (AbstractActor)ActorFactory.CreateActor("butler");
            IActor furnace = ActorFactory.CreateActor("furnace");
            butler.Position = new Point(10, 20);
            furnace.Position = new Point(60, 40);
            Assert.AreNotEqual(butler.Position, furnace.Position);
            butler.Target = furnace;
            butler.CommandList.Add(new Move(butler));
            while(!butler.CommandList[0].IsCompleted)
            {
                butler.CommandList[0].Execute();
            }
            butler.CommandList.RemoveAt(0);
           
            Assert.AreEqual(butler.Position, furnace.Position);
        }

        [Test()]
        public void GetClosestTest()
        {
            ActorMobile diver = (ActorMobile)ActorFactory.CreateActor("diver");
            ActorMobile diver2 = (ActorMobile)ActorFactory.CreateActor("diver");
            ActorMobile diver3 = (ActorMobile)ActorFactory.CreateActor("diver");
            diver.Position = new Point(0, 0);
            diver2.Position = new Point(1, 0);
            diver3.Position = new Point(10, 10);

            List<IActor> all = new List<IActor>();
            all.Add(diver);
            all.Add(diver2);
            all.Add(diver3);

            IActor closest = diver.FindClosest("diver", all);

            Assert.IsTrue(object.ReferenceEquals(closest, diver2));
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
