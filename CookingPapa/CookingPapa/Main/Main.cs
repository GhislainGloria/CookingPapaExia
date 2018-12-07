using System;
using View;
using Controller;
using System.Windows.Forms;
using System.Threading;

namespace Main
{
    public class MainClass
    {
		public static void Main(string[] args)
        {
			Universe universe = Universe.GetInstance();
			MainWindow window = new MainWindow(universe);

			Thread mainSimulationThread = new Thread(() =>
			{
				while(true)
				{
					Thread.Sleep(1000);
					universe.NextTick();
				}
			});
			mainSimulationThread.Start();

			Application.Run(window);
			mainSimulationThread.Abort();
        }
    }
}