using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
   public class TimeManager
    {

        public delegate void VoidDel();
        
        int Hours;
        int Minutes;
        int Seconde;
        int Days;
        int Month;
        int Year;

        public void Forward()
        {
            
        }

        public event VoidDel NextDay;            
        public event VoidDel Opened;      
        public event VoidDel Closed;      
    }
}