using Microsoft.VisualStudio.TestTools.UnitTesting;
using SafemoneyRestClient;
using SafemoneyRestClient.Models;
using System.Collections.Generic;

namespace UnitTest_Safemoney1
{
    [TestClass]
    public class UnitTest_DeviceInfo
    {
        private RestClient client;
        private ReadDeviceInfo res;

        // Exptected values
        private List<string> expectedModels = new List<string> { "COMPACT", "PROFESSIONAL", "ADVANCE", "EXTREME" };
        private const int expectedSerialLenght = 10;
        private const string expectedDriverVersion = "2.1.12.0";
        private const string expectedFirmwareVersion = "2.3.4-svn62894";

        [TestInitialize]
        public void TestInitialize() // Initialize the RestClient
        {
            client = new RestClient("http://192.168.34.212:7409", "pin", "0000");
            res = client.GetDeviceInfo();
        }
        [TestMethod]
        public void Test1_Model() // Check if model in list expectedModels
        {
            CollectionAssert.Contains(expectedModels, res.Device.Model);
        }
        [TestMethod]
        public void Test2_SerialLenght() // Check SerialLenght == 10
        {
            Assert.AreEqual(expectedSerialLenght, res.Device.Serial.Length);
        }
        [TestMethod]
        public void Test3_DriverVersionType() // Check DriverVersion == String
        {
            Assert.IsInstanceOfType(res.Device.DriverVersion, typeof(string));
        }
        [TestMethod]
        public void Test4_DriverVersion() // Check DriverVersion 
        {
            Assert.AreEqual(expectedDriverVersion, res.Device.DriverVersion);
        }
        [TestMethod]
        public void Test5_FirmwareVersion() // Check FirmwareVersion
        {
            Assert.AreEqual(expectedFirmwareVersion, res.Device.FirmwareVersion);
        }
        [TestMethod]
        public void Test6_PatchVersion() // Check is null
        {
            Assert.IsNull(res.Device.PatchVersion);
        }
        [TestMethod]
        public void Test7_IsActived() // Check is Active
        {
            Assert.IsTrue(res.License.isActived);
        }
        [TestMethod]
        public void Test8_ResCode() // Check ResCode == 0
        {
            Assert.AreEqual(res.ResCode, 0);
        }
        [TestMethod]
        public void Test9_ResDescription() // Check ResDescription == "success"
        {
            Assert.AreEqual(res.ResDescription.ToLower(), "success");
        }
    }
}
