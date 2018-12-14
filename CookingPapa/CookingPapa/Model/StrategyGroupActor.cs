using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class StrategyGroupActor : Strategy
    {

        /*
         * Stack[0] = int timeToOrder
        */

        private static readonly StrategyGroupActor Instance = new StrategyGroupActor();
        public static StrategyGroupActor GetInstance()
        {
            return Instance;
        }
        private StrategyGroupActor() { }
        public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {
            if ((bool)((GroupActor)self).Clients[0].Stack[0])
            {
                self.Stack[0] = (int)self.Stack[0] - 1;
                if ((int)self.Stack[0] == 0)
                {
                    Random rnd = new Random();
                    List<DishModel> orderModel = new List<DishModel>();
                    for (int i = ((GroupActor)self).Clients.Count; i > 0; i--)
                    {
                        int r = rnd.Next(DishModelList.GetAvailableDishes().Count);
                        orderModel.Add(DishModelList.GetAvailableDishes()[r]);
                    }
                    ((GroupActor)self).TriggerEvent("newOrder", new Order(((GroupActor)self.Stack[3]).Table, orderModel));
                }
            }
            foreach(Actor client in ((GroupActor)self).Clients)
            {
                client.Strategy.Behavior(client, all);
            }
            if (self.CommandList.Count > 0)
            {
                if (self.CommandList[0].IsCompleted)
                {
                    self.CommandList.RemoveAt(0);
                }
                else
                {
                    self.CommandList[0].Execute();
                }
            }
        }

        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
