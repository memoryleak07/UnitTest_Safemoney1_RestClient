using Newtonsoft.Json;

namespace SafemoneyRestClient.Models
{
    public class ReadResultPayResp
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("dispensed")]
        public float Dispensed { get; set; }

        [JsonProperty("notDispensed")]
        public float NotDispensed { get; set; }

        [JsonProperty("paid")]
        public float Paid { get; set; }

        [JsonProperty("toBePaid")]
        public float ToBePaid { get; set; }

        [JsonProperty("transactionStatus")]
        public string TransactionStatus { get; set; }

        [JsonProperty("resCode")]
        public int ResCode { get; set; }

        [JsonProperty("resDescription")]
        public string ResDescription { get; set; }
    }
}
