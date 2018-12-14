
namespace Model
{
    public class CommandSetAvailable : ACommand
    {
		public CommandSetAvailable(AbstractActor self, bool itemExchange = true, bool busy = false, bool busyWaiting = false, bool busyWalking = false)
        {
            Self = self;
			Busy = busy;
			BusyWaiting = busyWaiting;
			BusyWalking = busyWalking;
			ItemExchange = itemExchange;
        }

        public AbstractActor Getfrom { get; private set; }
		public bool Busy { get; private set; }
		public bool BusyWaiting { get; private set; }
		public bool BusyWalking { get; private set; }
        public bool ItemExchange { get; private set; }

        public override void Execute()
        {
            IsCompleted = true;
			Self.Busy = Busy;
			Self.BusyWaiting = BusyWaiting;
			Self.BusyWalking = BusyWalking;
			Self.AcceptItemExchange = ItemExchange;
        }
    }
}
