using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    [TestFixture()]
    public class TableTest
    {
        GroupActor actors = new GroupActor();

        [Test()]
        public void TestCase()
        {
            actors.Clients.Add(new ActorMobile());
            Table table = new Table(1);
            table.setGroupActor(actors);
            Assert.AreEqual(1, table.Place, "Le nombre de clients max à la table est bon");

            actors.Clients.Add(new ActorMobile());
            table.setGroupActor(actors);
            try {
                table.setGroupActor(actors);
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }
    }
}
