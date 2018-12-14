using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class StrategyClientSpawner : Strategy
    {

        /*
         * Stack[0] = chance to pop GroupActor
         */

        private static readonly StrategyClientSpawner Instance = new StrategyClientSpawner();
        public static StrategyClientSpawner GetInstance()
        {
            return Instance;
        }
        private StrategyClientSpawner() { }

        public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {

            Random random = new Random();
            int randomNumber = random.Next(1, 100);

            if (((int)self.Stack[0]) > randomNumber)
            {
                AbstractActor newGroup = ActorFactory.CreateActor("customergroup");
                all.Add(newGroup);
                self.TriggerEvent("clientSpawned", newGroup);
                self.Stack[0] = 0;
            }
            else
            {
                self.Stack[0] = ((int)self.Stack[0]) + 1;
            }

        }

        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
            throw new NotImplementedException();
        }

        int GetClientCount()
        {
            Random random = new Random();
            double randomClient = random.NextDouble();
            if (randomClient <= 0.6)
                return random.Next(1, 4);
            if (randomClient <= 0.9 && randomClient > 0.6)
                return random.Next(5, 8);
            else
                return random.Next(9, 10);
        }
    }
}
