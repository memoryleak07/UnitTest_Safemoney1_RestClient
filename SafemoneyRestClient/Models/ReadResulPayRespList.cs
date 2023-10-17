using Newtonsoft.Json;
using System.Collections.Generic;

namespace SafemoneyRestClient.Models
{
    public class ReadResulPayRespList
    {
        [JsonProperty("payments")]
        public List<ReadPaymentDetail> Payments { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }

    public class ReadPaymentDetail : ReadResultPayResp
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
