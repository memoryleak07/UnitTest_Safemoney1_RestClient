using Newtonsoft.Json;
using SafemoneyRestClient.Helpers;


namespace SafemoneyRestClient.Models
{
    public class ReadCreatedPayResp
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("transactionStatus")]
        public string TransactionStatus { get; set; }

        [JsonProperty("resCode")]
        public int ResCode { get; set; }

        [JsonProperty("resDescription")]
        public string ResDescription { get; set; }

        // Obtained from Reflection 
        public override string ToString()
        {
            return string.Join("|", this.GetItemValue());
        }
    }
}
