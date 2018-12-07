using System;
using View;
using Controller;
using System.Windows.Forms;

namespace Main
{
    public class MainClass
    {
		public static void Main(string[] args)
        {
			Universe universe = Universe.GetInstance();
			MainWindow window = new MainWindow(universe);
			Application.Run(window);
        }
    }
}