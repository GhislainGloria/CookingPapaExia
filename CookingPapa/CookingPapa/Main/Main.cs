using System;
using View;
using System.Windows.Forms;

namespace Main
{
    public class MainClass
    {
		public static void Main(string[] args)
        {
			MainWindow window = new MainWindow();         
			Application.Run(window);
        }
    }
}
