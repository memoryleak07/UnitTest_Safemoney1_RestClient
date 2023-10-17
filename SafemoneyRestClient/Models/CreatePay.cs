using Newtonsoft.Json;

namespace SafemoneyRestClient.Models
{
    public class CreatePay
    {
        [JsonProperty("toBePaid")]
        public float ToBePaid { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
    }
}
