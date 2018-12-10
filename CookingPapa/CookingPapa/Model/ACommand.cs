using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class ACommand
    {
        public AbstractActor Self { get; protected set; }
        public bool IsCompleted { get; protected set; }
        public abstract void Execute();
    }
}
