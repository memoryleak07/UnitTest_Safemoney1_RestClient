using Newtonsoft.Json;
using SafemoneyRestClient.Helpers;
using System.Collections.Generic;

namespace SafemoneyRestClient.Models
{
    public class TransactionList
    {
        [JsonIgnore]
        public static string CREATED = "CREATED";
        [JsonIgnore]
        public static string CASH_IN = "CASH_IN";
        [JsonIgnore]
        public static string CASH_OUT = "CASH_OUT";
        [JsonIgnore]
        public static string TERMINATED = "TERMINATED";
        [JsonIgnore]
        public static string ABORTED = "ABORTED";
        [JsonIgnore]
        public static string ERROR = "ERROR";
        [JsonProperty("statusList")]
        public List<string> StatusList { get; set; } = new List<string>();

        // Obtained from Reflection 
        public override string ToString()
        {
            return string.Join("|", this.GetItemValue());
        }
    }
}
