using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    //[TestFixture()]
    public class StockDAOTest
    {

        [Test()]
        public void TestCase()
        {
            Console.WriteLine(StockDAO.getDatabaseString());

        }
    }
}
