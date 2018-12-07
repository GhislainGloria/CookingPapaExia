using NUnit.Framework;
using System;
using View;
using Controller;

namespace ViewTest
{
    //[TestFixture()]
    public class ViewTest
    {
		private Universe universe = Universe.GetInstance();
		private MainWindow mainWindow;

		[SetUp()]
		public void SetupTest()
		{
			mainWindow = new MainWindow(universe);
		}

        [Test()]
        public void CanPaint()
        {
			try {
				mainWindow.Show();
                mainWindow.Close();
                Assert.IsTrue(true, "L'event Paint a du se passer normalement");	
			} catch(Exception e) {
				Console.WriteLine(e.StackTrace);
				Assert.IsTrue(false, "La fenetre ne s'est pas affichee correctement");
			}
        }
    }
}
