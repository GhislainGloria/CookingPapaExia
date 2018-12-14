using View;
using Controller;
using System.Windows.Forms;
using System.Threading;
using System;

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
				Thread.CurrentThread.Name = "MainSimulationThread";
				int SimulationSpeed = 1000;
				bool block = false;

				window.TimeScaleChanged += (int NewScale) => {
					if(NewScale == 0)
					{
						block = true;
						return;
					}
					block = false;
					SimulationSpeed = 1000 / NewScale; 
				};

				while(true)
				{
					if (block) continue;
					Thread.Sleep(SimulationSpeed);
					universe.NextTick();
					window.RedrawView();
				}
			});
			mainSimulationThread.Start();

			Application.Run(window);
			mainSimulationThread.Abort();
        }
    }
}