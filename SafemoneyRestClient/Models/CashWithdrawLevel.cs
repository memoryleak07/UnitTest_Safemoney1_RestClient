using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SafemoneyRestClient.Helpers;
using System.Collections.Generic;

namespace SafemoneyRestClient.Models
{
    public class CashWithdrawLevel
    {
        [JsonProperty("deviceType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DeviceType DeviceType { get; set; }

        [JsonProperty("denomination")]
        public float Denomination { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        // Obtained from Reflection 
        public override string ToString()
        {
            return string.Join("|", this.GetItemValue());
        }

    }

    public class CashList
    {
        //{ "cashList" : [
        //  {
        //    "deviceType": "COIN",
        //    "denomination": 1,
        //    "quantity": 5
        //  },

        [JsonProperty("cashList")]
        public List<CashWithdrawLevel> CashWithdrawLevels { get; set; }

        public CashList()
        {
            CashWithdrawLevels = new List<CashWithdrawLevel>();
        }

        public CashList(DeviceType deviceType, float denomination, int quantity) : this()
        {
            CashWithdrawLevels.Add(new CashWithdrawLevel
            {
                DeviceType = deviceType,
                Denomination = denomination,
                Quantity = quantity
            });
        }

        public void AddItem(Inventory item)
        {
            CashWithdrawLevels.Add(new CashWithdrawLevel
            {
                DeviceType = item.DeviceType,
                Denomination = item.Denomination,
                Quantity = item.ReLevel
            });
        }
    }


}
