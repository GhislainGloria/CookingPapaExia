using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class ActorMobile : IActor
    {
        public List<ICarriableItem> Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Position Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IActor Target { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Busy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Thread Thread { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MaxInventorySize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Strategy Strategy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void CallStrategy()
        {

        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public void NextTick()
        {
            throw new NotImplementedException();
        }

        public void Event()
        {
            throw new NotImplementedException();
        }

        public void SetStrategy(Strategy strategy)
        {
            throw new NotImplementedException();
        }

        public ActorMobile()
        {

        }

        
    }
}
