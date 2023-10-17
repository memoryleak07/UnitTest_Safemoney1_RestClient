using Newtonsoft.Json;
using SafemoneyRestClient.Helpers;
using System.Collections.Generic;

namespace SafemoneyRestClient.Models
{
    public class InventoryList
    {

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("coins")]
        public DenominationList Coins { get; set; }

        [JsonProperty("notes")]
        public DenominationList Notes { get; set; }

        [JsonProperty("total")]
        public float Total { get; set; }
        [JsonProperty("resCode")]
        public int ResCode { get; set; }

        [JsonProperty("resDescription")]
        public string ResDescription { get; set; }

        [JsonIgnore]
        public List<Inventory> InventoryDetail
        {
            get
            {
                List<Inventory> list = new List<Inventory>();
                list.AddRange(Coins.Denominations);
                list.AddRange(Notes.Denominations);
                return list;
            }
        }

        // Obtained from Reflection 
        public override string ToString()
        {
            return string.Join("|", this.GetItemValue());
        }
    }

    public class DenominationList
    {

        [JsonProperty("denominations")]
        public List<Inventory> Denominations { get; set; }

        [JsonProperty("total")]
        public float Total { get; set; }
    }
}

