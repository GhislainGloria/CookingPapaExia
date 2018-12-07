using NUnit.Framework;
using Controller;


namespace ControllerTest
{
    class TimeManagerTest
    {

        private readonly TimeManager timemanager = new TimeManager();
        
		private void fail()
		{
			Assert.Fail("Called at wrong moment");
		}

		private void success()
		{
			//Assert.Pass("Test passed");
		}

        [Test()]
        public void TestAll()
        {
			timemanager.NextMinute += fail;

			for (int i = 0; i < 59; i++)
			{
				timemanager.Forward();
			}

			timemanager.NextMinute -= fail;         
			timemanager.NextMinute += success;

			timemanager.Forward(); // 60 seconds passed

			timemanager.NextMinute -= success;         
        }            
    }
}