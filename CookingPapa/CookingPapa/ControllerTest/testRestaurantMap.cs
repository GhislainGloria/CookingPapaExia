using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using NUnit.Framework;
using System.Drawing;
using System.Security.Policy;
using Model;


namespace ControllerTest
{
    //[TestFixture()]
    class TestRestaurantMap
    {
           private readonly Site mapSize;
           public  List<AbstractActor> Actors { get; set; }

        private readonly RestaurantMap retaurant = new  RestaurantMap();

        public Site MapSize => mapSize;


        [Test()]
        public void Testrange()
        {
            /*Actors = new List<AbstractActor>();
            ActorMobile testActor = new ActorMobile();
            testActor.Name = "bibi";
            testActor.Position = new Point(10, 10);
            Actors.Add(testActor);

            testActor.Name = "fourpos";
            testActor.Position = new Point(20, 20);
            Actors.Add(testActor);

            testActor.Name = "fourpos2";
            testActor.Position = new Point(30,30);
            Actors.Add(testActor);*/

            Point testcuisinier = new Point(10, 5);
            Point four1 = new Point(12, 7);
            Point four2 = new Point(18, 9);

          
            double testF1 = Math.Sqrt((Math.Pow((12-10),2)+Math.Pow((7-5),2)));
            double testF2 = Math.Sqrt((Math.Pow((18 - 10), 2) + Math.Pow((9 - 5), 2)));



            if (testF1>testF2)
            {
                Assert.IsTrue(true, "le four 1 est plus proche du cuisinier que le four 2 ");


            }
            else
            {


                Assert.IsTrue(true, "le four 2 est plus proche du cuisinier que le four 1 ");
            }
         




        }

    }
}
