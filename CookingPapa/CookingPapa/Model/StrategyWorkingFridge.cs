using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StrategyWorkingFridge : Strategy
    {
        private static readonly StrategyWorkingFridge Instance = new StrategyWorkingFridge();
        public static StrategyWorkingFridge GetInstance()
        {
            return Instance;
        }

        private StrategyWorkingFridge()
        {

        }

        public override void Behavior(AbstractActor self, List<AbstractActor> all)
        {         
         
        }

        public override void ReactToEvent(AbstractActor self, MyEventArgs args)
        {
            
        }
    }
}
