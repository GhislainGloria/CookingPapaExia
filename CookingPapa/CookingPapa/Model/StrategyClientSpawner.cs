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
         * Stack[1] = actual chance to pop GroupActor (const)
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
            if (((int)self.Stack[0]/10) > (int)self.Stack[1])
            {
                int clientNumber = GetClientCount();
                AbstractActor newGroup = ActorFactory.CreateActor("customergroup");
                for (int i = 0; i < clientNumber; i++)
                {
                    ((GroupActor)newGroup).Clients.Add((Actor)ActorFactory.CreateActor("customer"));
                }
                newGroup.Position = self.Position;
                all.Add(newGroup);
                self.TriggerEvent("clientSpawned", newGroup);
                self.Stack[0] = 0;
                self.Stack[1] = random.Next(1, 100);
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
