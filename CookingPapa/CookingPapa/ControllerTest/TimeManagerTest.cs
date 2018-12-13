using NUnit.Framework;
using Controller;


namespace ControllerTest
{
    class TimeManagerTest
    {

        private readonly TimeManager timemanager = new TimeManager();
        
		private void Fail()
		{
			Assert.Fail("Called at wrong moment");
		}

		private void Success()
		{
			//Assert.Pass("Test passed");
		}

        [Test()]
        public void TestAll()
        {
			timemanager.NextMinute += Fail;

			for (int i = 0; i < 59; i++)
			{
				timemanager.Forward();
			}

			timemanager.NextMinute -= Fail;         
			timemanager.NextMinute += Success;

			timemanager.Forward(); // 60 seconds passed

			timemanager.NextMinute -= Success;         
        }            
    }
}