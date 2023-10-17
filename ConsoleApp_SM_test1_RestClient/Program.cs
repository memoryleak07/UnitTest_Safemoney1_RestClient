using SafemoneyRestClient;
using SafemoneyRestClient.Models;

namespace ConsoleApp_SM_test1_RestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RestClient client = new RestClient("http://192.168.34.212:7409", "pin", "0000");
            // Set AssistMode: OFF
            ReadSettings readSettings = client.GetSettings();
            Console.WriteLine(readSettings.SettingsInfo.AssistMode);
        }
    }
}