using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    class ActorMobileTest
    {
        ActorMobile actorMobile;

        [SetUp()]
        public void SetUp()
        {
            actorMobile = new ActorMobile();
        }
        

        [Test()]
        public void CallStrategyTest()
        {
            Assert.actorMobile.CallStrategy();
        }

        public void NextTickTest()
        {
            throw new NotImplementedException();
        }

        public void MoveTest()
        {
            throw new NotImplementedException();
        }

        [TearDown()]
        public void TearDown()
        {

        }
    }
}
