using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    class StrategyHeadWaiterTest
    {
        List<AbstractActor> actors;
        AbstractActor headWaiter;
        AbstractActor receptionnist;
        AbstractActor stock;
        List<AbstractActor> rangTables;
        StrategyHeadWaiter strategyHeadWaiter;
        StrategyReceptionnist strategyReceptionnist;
        Utensil card;
        Order order;
        AbstractActor counter;
        AbstractActor idle;
        GroupActor groupActor;


        [SetUp()]
        public void SetUp()
        {
            
            actors = new List<AbstractActor>();
            headWaiter = ActorFactory.CreateActor("headWaiter");
            receptionnist = ActorFactory.CreateActor("receptionnist");
            rangTables = new List<AbstractActor>();
            rangTables.Add(new Table(4, 2));
            stock = ActorFactory.CreateActor("stock");
            groupActor = new GroupActor();
            groupActor.Clients.Add((Actor)ActorFactory.CreateActor("customers"));
            groupActor.Clients.Add((Actor)ActorFactory.CreateActor("customers"));
            groupActor.Clients.Add((Actor)ActorFactory.CreateActor("customers"));
            groupActor.Clients.Add((Actor)ActorFactory.CreateActor("customers"));
            card = UtensilFactory.CreateUtensil("card");
            counter = ActorFactory.CreateActor("counter");
            idle = ActorFactory.CreateActor("idle");
            strategyHeadWaiter = StrategyHeadWaiter.GetInstance();
            strategyReceptionnist = StrategyReceptionnist.GetInstance();



        }

        [Test()]
        public void BehaviorTest()
        {
            headWaiter.Target = receptionnist;
            headWaiter.CommandList.Add(new CommandMove(headWaiter));
            while (headWaiter.EvaluateDistanceTo(receptionnist) != (0 | 1 | -1))
            {
                strategyHeadWaiter.Behavior(headWaiter, actors);
            }
            Assert.IsTrue(headWaiter.EvaluateDistanceTo(receptionnist) == (0 | 1 | -1));
            headWaiter.CommandList.Add(new CommandSetTarget(groupActor, rangTables[0]));
            headWaiter.CommandList.Add(new CommandSetTarget(headWaiter, rangTables[0]));
            headWaiter.CommandList.Add(new CommandMove(headWaiter));
            strategyHeadWaiter.Behavior(headWaiter, actors);
            Assert.AreEqual(headWaiter.Target, rangTables[0]);
            while (headWaiter.EvaluateDistanceTo(rangTables[0]) != (0 | 1 | -1))
            {
                strategyHeadWaiter.Behavior(headWaiter, actors);
            }
            Assert.IsTrue(groupActor.EvaluateDistanceTo(rangTables[0]) == (0 | 1 | -1));
            headWaiter.CommandList.Add(new CommandSetTarget(headWaiter, stock));
            headWaiter.CommandList.Add(new CommandMove(headWaiter));
            while (headWaiter.EvaluateDistanceTo(stock) != (0 | 1 | -1))
            {
                strategyHeadWaiter.Behavior(headWaiter, actors);

            }
            Assert.IsTrue(headWaiter.EvaluateDistanceTo(stock) == (0 | 1 | -1));
            foreach (Actor client in groupActor.Clients)
            {
                headWaiter.CommandList.Add(new CommandGetItem(headWaiter, stock, "card"));
            }
            strategyHeadWaiter.Behavior(headWaiter, actors);
            Assert.IsTrue(headWaiter.Items.Contains(card));
            headWaiter.CommandList.Add(new CommandSetTarget(headWaiter, stock));
            headWaiter.CommandList.Add(new CommandMove(headWaiter));
            while (headWaiter.EvaluateDistanceTo(groupActor) != (0 | 1 | -1))
            {
                strategyHeadWaiter.Behavior(headWaiter, actors);

            }
            Assert.IsTrue(headWaiter.EvaluateDistanceTo(groupActor) == (0 | 1 | -1));
            foreach (Actor client in groupActor.Clients)
            {
                headWaiter.CommandList.Add(new CommandGiveItem(headWaiter, client, "card"));
            }
            strategyHeadWaiter.Behavior(headWaiter, actors);
            Assert.IsFalse(headWaiter.Items.Contains(card));
            for (int i = 0; i < 300; i++)
            {
                strategyHeadWaiter.Behavior(headWaiter, actors);
            }
            strategyHeadWaiter.Behavior(headWaiter, actors);
            Assert.IsTrue(headWaiter.Items.Contains(card));
            Assert.IsTrue(headWaiter.Items.Contains(order));
            while (headWaiter.EvaluateDistanceTo(counter) != (0 | 1 | -1))
            {
                strategyHeadWaiter.Behavior(headWaiter, actors);
            }
            Assert.IsTrue(headWaiter.EvaluateDistanceTo(counter) == (0 | 1 | -1));
            strategyHeadWaiter.Behavior(headWaiter, actors);
            Assert.IsFalse(headWaiter.Items.Contains(order));
            headWaiter.CommandList.Add(new CommandSetTarget(headWaiter, groupActor));
            headWaiter.CommandList.Add(new CommandMove(headWaiter));
            while (headWaiter.EvaluateDistanceTo(groupActor) != (0 | 1 | -1))
            {
                strategyHeadWaiter.Behavior(headWaiter, actors);

            }
            Assert.IsTrue(headWaiter.EvaluateDistanceTo(groupActor) == (0 | 1 | -1));
            if (headWaiter.CommandList == null)
            {
                while (headWaiter.EvaluateDistanceTo(idle) != (0 | 1 | -1))
                {
                    strategyHeadWaiter.Behavior(headWaiter, actors);

                }
                Assert.IsTrue(headWaiter.EvaluateDistanceTo(idle) == (0 | 1 | -1));
            }
        }



        [TearDown()]
        public void TearDown()
        {

        }
    }
}
