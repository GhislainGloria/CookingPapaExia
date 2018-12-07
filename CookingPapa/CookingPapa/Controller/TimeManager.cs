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
        
        public int Hour { get; set; }
		public int Minute { get; set; }
		public int Second { get; set; }
		public int Day { get; set; }
		public int Week { get; set; }
		public int Year { get; set; }


        /**
         * OPEN 7/7
         * 
         * STAFF HOURS:
         * START 10:00
         * END 00:00 the next day
         * SWITCH TEAMS AT 17:00
         * 
         * CLIENTS CAN ORDER FROM:
         * START: 12:00
         * END 15:00
         * START 19:00
         * END 22:00
         */


		public TimeManager()
		{
			Second = Minute = Hour = Day = Week = Year = 0;

			NextMinute  = NextMinuteDefaultHandler;
			NextHour = NextHourDefaultHandler;
			NextDay = NextDayDefaultHandler;
			NextWeek = NextWeekDefaultHandler;
			NextYear = NextYearDefaultHandler;
		}

        public void Forward()
        {
			if (Second++ >= 60)
			{
				Second = 0;
				NextMinute();
			}
        }

		private void NextMinuteDefaultHandler()
		{
			if (Minute++ >= 60)
			{
				Minute = 0;
				NextHour();
			}
		}

		private void NextHourDefaultHandler()
		{
			if(Hour++ >= 24)
			{
				Hour = 0;
				NextDay();
				ClosedToStaff();
			}

			switch(Hour) {
				case 10:
					OpenedToStaff();
					break;
				case 12:
					OpenedToCustomers();
					break;
				case 15:
					ClosedToCustomers();
					break;
				case 17:
					TeamSwitchTime();
					break;
				case 22:
					ClosedToCustomers();
					break;               
			}
		}

		private void NextDayDefaultHandler()
		{
			if(Day++ >= 7)
			{
				Day = 0;
				NextWeek();
			}
		}

		private void NextWeekDefaultHandler()
		{
			if(Week++ >= 52)
			{
				Week = 0;
				NextYear();
			}
		}

		private void NextYearDefaultHandler()
		{
			Year++;
		}
        
		public event VoidDel NextMinute;
		public event VoidDel NextHour;
		public event VoidDel NextDay;
		public event VoidDel NextWeek;
        public event VoidDel NextYear;
        
		public event VoidDel OpenedToStaff;
		public event VoidDel ClosedToStaff;
		public event VoidDel OpenedToCustomers;
        public event VoidDel ClosedToCustomers;
		public event VoidDel TeamSwitchTime;      
    }
}