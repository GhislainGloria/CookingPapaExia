using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    class ActorFactoryTest
    {

        [TestFixtureSetUp()]
        public void SetupTest()
        {

        }

        [Test()]
        public void TestCreateActor()
        {
            Assert.IsNotNull(ActorFactory.CreateActor("butler"));
            Assert.AreNotSame(ActorFactory.CreateActor("customer"), ActorFactory.CreateActor("butler"));
            
            
        }

        [TestFixtureTearDown()]
        public void TearDown()
        {

        }
    }
}
