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
        
        int Hours { get; set; }
        int Minutes { get; set; }
        int Seconde { get; set; }
        int Days { get; set; }
        int Month { get; set; }
        int Year { get; set; }

        public void Forward()
        {
            
        }

        public event VoidDel NextDay;            
        public event VoidDel Opened;      
        public event VoidDel Closed;      
    }
}