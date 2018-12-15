using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class StrategyWaiter : Strategy
    {

        private static StrategyWaiter Instance = new StrategyWaiter();
        public static StrategyWaiter GetInstance()
        {

            return Instance;
        }


        private StrategyWaiter() { }
        public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {

            if (self.Stack.Count > 0)
            {

                // quand un groupe arrive a une table , apporte pain et eau
                foreach (AbstractActor table in all.Where(n => n.Name == "table" && ((Table)n).Grp != null))
                {
                    if (table.Grp.Clients.Count < 7)
                    {

                        self.GetItemFrom(Counter, BreadandWater);


                        Console.WriteLine(self + ": table need water and bread ");

                        a.Busy = true;
                        a.AcceptItemExchange = false;
                        a.CommandList.Add(new CommandSetTarget(a, Counter));
                        a.CommandList.Add(new CommandMove(a));
                        a.CommandList.Add(new CommandGetItem(Counter, BreadandWater));

                        a.CommandList.Add(new CommandSetTarget(a, table));
                        a.CommandList.Add(new CommandMove(a));
                        a.CommandList.Add(new CommandGiveItem(a, table, BreadandWater));
                        a.CommandList.Add(new CommandSetAvailable(a));

                        // We want to know if the Waiter failed
                        a.EventGeneric += self.StrategyCallback;
                        self.Stack[1] = true;
                        break;

                    }



                    else if (table.Grp.Clients.Count >= 7)
                    {

                        if (target != null)
                        {
                            Console.WriteLine(self + ": table need water and bread ");

                            a.Busy = true;
                            a.AcceptItemExchange = false;
                            a.CommandList.Add(new CommandSetTarget(a, Counter));
                            a.CommandList.Add(new CommandMove(a));
                            a.CommandList.Add(new CommandGetItem(Counter, BreadandWater));
                            a.CommandList.Add(new CommandGetItem(Counter, BreadandWater));

                            a.CommandList.Add(new CommandSetTarget(a, table));
                            a.CommandList.Add(new CommandMove(a));
                            a.CommandList.Add(new CommandGiveItem(a, table, BreadandWater));

                            a.CommandList.Add(new CommandSetAvailable(a));

                            // We want to know if the Waiter failed
                            a.EventGeneric += self.StrategyCallback;
                            self.Stack[1] = true;
                            break;
                        }


                    }

                }



                // apporte les plats sur les tables 


                // atten un temps


                // revien pour debarasser ( il peu debarasser que 5 par 5) 


                //    GroupActor Client = null;
                // Table closestTable = null;
            }




        }


        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
            switch (args.EventName)
            {
                case "order received":

                    self.Strack.Add(args.Arg);

                    a.Busy = true;
                    a.AcceptItemExchange = false;
                    a.CommandList.Add(new CommandSetTarget(a, Counter));
                    a.CommandList.Add(new CommandMove(a));
                    a.CommandList.Add(new CommandGetItem(Counter, Dish.all));

                    a.CommandList.Add(new CommandSetTarget(a, table));
                    a.CommandList.Add(new CommandMove(a));
                    a.CommandList.Add(new CommandGiveItem(a, table, Dish.all));


                    a.CommandList.Add(new CommandSetAvailable(a));









            }
        }
    }

