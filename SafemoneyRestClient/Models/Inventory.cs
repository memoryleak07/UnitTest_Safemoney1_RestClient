using Newtonsoft.Json;
using SafemoneyRestClient.Helpers;

namespace SafemoneyRestClient.Models
{
    public class Inventory
    {
        [JsonProperty("cbLevel")]
        public int CbLevel { get; set; }

        [JsonProperty("delta")]
        public int Delta { get; set; }

        [JsonProperty("denomination")]
        public float Denomination { get; set; }

        [JsonProperty("deviceType")]
        public DeviceType DeviceType { get; set; }

        [JsonProperty("maxThreshold")]
        public int MaxThreshold { get; set; }

        [JsonProperty("minThreshold")]
        public int MinThreshold { get; set; }

        [JsonProperty("reLevel")]
        public int ReLevel { get; set; }

        [JsonProperty("route")]
        public Route Route { get; set; }

        [JsonProperty("total")]
        public float Total { get; set; }

        // Obtained from Reflection 
        public override string ToString()
        {
            return string.Join("|", this.GetItemValue());
        }
    }

    public enum DeviceType { COIN, NOTE };

    public enum Route { Deposit, None, Recycle };

}
