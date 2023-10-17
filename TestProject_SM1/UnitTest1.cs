using SafemoneyRestClient;
using SafemoneyRestClient.Models;

namespace TestProject_SM1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RestClient client = new("http://192.168.34.212:7409", "pin", "0000");

            ReadDeviceInfo res = client.GetDeviceInfo();

            Assert.AreEqual("PROFESSIONAL", res.Device.Model);
        }
    }
}