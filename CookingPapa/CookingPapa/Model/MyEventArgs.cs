using System;

namespace Model
{
	public class MyEventArgs : EventArgs
    {
        public object Arg { get; set; }
		public object Arg2 { get; set; }
        public string EventName { get; set; }

        public MyEventArgs(string eventName, object arg)
        {
            Arg = arg;
            EventName = eventName;
        }

		public MyEventArgs(string eventName, object arg, object arg2)
			: this(eventName, arg)
		{
			Arg2 = arg2;         
		}
    }
}
