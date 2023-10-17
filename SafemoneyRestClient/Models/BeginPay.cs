using Newtonsoft.Json;

namespace SafemoneyRestClient.Models
{
    public class BeginPay
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
