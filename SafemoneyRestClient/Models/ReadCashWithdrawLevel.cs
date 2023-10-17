using Newtonsoft.Json;

namespace SafemoneyRestClient.Models
{
    public class ReadCashWithdrawLevel
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("totalDispensed")]
        public long TotalDispensed { get; set; }

        [JsonProperty("totalNotDispensed")]
        public long TotalNotDispensed { get; set; }

        [JsonProperty("withdrawals")]
        public Withdrawals[] Withdrawals { get; set; }

        [JsonProperty("transactionStatus")]
        public string TransactionStatus { get; set; }

        [JsonProperty("resCode")]
        public long ResCode { get; set; }

        [JsonProperty("resDescription")]
        public string ResDescription { get; set; }
    }

    public partial class Withdrawals
    {
        [JsonProperty("dispensed")]
        public long Dispensed { get; set; }

        [JsonProperty("notDispensed")]
        public long NotDispensed { get; set; }

        [JsonProperty("denomination")]
        public long Denomination { get; set; }

        [JsonProperty("deviceType")]
        public DeviceType DeviceType { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }
}
