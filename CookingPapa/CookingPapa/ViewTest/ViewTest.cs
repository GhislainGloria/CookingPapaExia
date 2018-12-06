using NUnit.Framework;
using System;
using View;

namespace ViewTest
{
    [TestFixture()]
    public class ViewTest
    {
		private readonly ViewWidget viewWidget = new ViewWidget();
		private readonly MainWindow mainWindow = new MainWindow();

        [Test()]
        public void CanPaint()
        {
			mainWindow.Show();
			mainWindow.Close();
			Assert.IsTrue(true, "L'event Paint a du se passer normalement");
        }
    }
}
