using Microsoft.VisualStudio.TestTools.UnitTesting;
using SafemoneyRestClient.Models;
using SafemoneyRestClient;
using System.Collections.Generic;

namespace UnitTest_Safemoney1
{
    [TestClass]
    public class UnitTest_Pay
    {
        private RestClient client;

        // Exptected values
        private List<string> transactionStatusList = new List<string> { "CREATED", "CASH_IN", "CASH_OUT", "TERMINATED", "ERROR", "ABORTED" };
        private CreatePay body = new CreatePay
        {
            ToBePaid = 100.0f,  // Set the value for ToBePaid
            Description = "Payment1"  // Set the Description
        };

        [TestInitialize]
        public void TestInitialize() // Initialize the RestClient
        {
            client = new RestClient("http://192.168.34.212:7409", "pin", "0000");
            // Set AssistMode: OFF
            //ReadSettings readSettings = client.GetSettings();
            //Console.WriteLine(readSettings.SettingsInfo.AssistMode);

        }
        [TestMethod]
        public void Test_CreatePay()
        {
            ReadCreatedPayResp res = client.CreatePayment(body);
            Assert.AreEqual(transactionStatusList[0], res.TransactionStatus);
        }
        [TestMethod]
        public void Test_BeginAndAbortPayment()
        {
            ReadCreatedPayResp resCP = client.CreatePayment(body);
            ReadCreatedPayResp resBP = client.BeginPayment(new BeginPay { Token = resCP.Token });
            ReadResultPayResp resGP = client.AbortPayment(new BeginPay { Token = resBP.Token });
            Assert.AreEqual(transactionStatusList[5], resGP.TransactionStatus);
        }
        //[TestMethod]
        //public void Test_DelPayment()
        //{

        //}
    }
}
