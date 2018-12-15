using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace ModelTest
{
    class ActorFactoryTest
    {

        [SetUp()]


        [Test()]
        public void TestCreateActor()
        {
            Assert.IsNotNull(ActorFactory.CreateActor("chef"));
            Assert.AreNotSame(ActorFactory.CreateActor("chef"), ActorFactory.CreateActor("butler"));
			Assert.IsInstanceOf(typeof(AbstractActor), ActorFactory.CreateActor("chef")); // TODO: reenable
        }
        
        [TearDown()]
        public void TearDown()
        {

        }

    }
}
