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
        

        [SetUp()]
        public void SetUp()
        {
            
        }
        

        [Test()]
        public void CallStrategyTest()
        {
            

        }

        public void NextTickTest()
        {
            
        }

        public void MoveTest()
        {
            AbstractActor butler = ActorFactory.CreateActor("butler");
        }

        [TearDown()]
        public void TearDown()
        {

        }
    }
}
