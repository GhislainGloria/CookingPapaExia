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
    class ActorTest
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
		public void GetClosestTest()
		{
			Actor diver = (Actor)ActorFactory.CreateActor("diver");
			Actor diver2 = (Actor)ActorFactory.CreateActor("diver");
			Actor diver3 = (Actor)ActorFactory.CreateActor("diver");
			diver.Position = new Point(0, 0);
			diver2.Position = new Point(1, 0);
			diver3.Position = new Point(10, 10);

			List<AbstractActor> all = new List<AbstractActor>();
			all.Add(diver);
			all.Add(diver2);
			all.Add(diver3);

			AbstractActor closest = diver.FindClosest("diver", all);

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
