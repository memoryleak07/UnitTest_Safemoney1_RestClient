using Newtonsoft.Json;

namespace SafemoneyRestClient.Models
{
    public class ReadSettings
    {
        public class ApplicationSettingsObj
        {
            [JsonProperty("plugins")]
            public int Plugins { get; set; }

            [JsonProperty("pluginsRunning")]
            public int PluginsRunning { get; set; }
        }
        public class SettingsInfoObj
        {
            [JsonProperty("assistMode")]
            public bool AssistMode { get; set; }

            [JsonProperty("paymentsQueue")]
            public bool PaymentsQueue { get; set; }

            [JsonProperty("partialChange")]
            public bool PartialChange { get; set; }

            [JsonProperty("appTimeout")]
            public int AppTimeout { get; set; }

            [JsonProperty("tokenRetention")]
            public int TokenRetention { get; set; }

            [JsonProperty("transactionTimeout")]
            public int TransactionTimeout { get; set; }

            [JsonProperty("dispensingMode")]
            public string DispensingMode { get; set; }

            [JsonProperty("language")]
            public string Language { get; set; }

            [JsonProperty("customerMode")]
            public bool CustomerMode { get; set; }

            [JsonProperty("directPaymentMode")]
            public bool DirectPaymentMode { get; set; }

            [JsonProperty("cancelButtonAlwaysShowed")]
            public bool CancelButtonAlwaysShowed { get; set; }

            [JsonProperty("moneyChangerMode")]
            public bool MoneyChangerMode { get; set; }

            [JsonProperty("autoResetCashboxCounters")]
            public bool AutoResetCashboxCounters { get; set; }
        }


        [JsonProperty("applicationSettings")]
        public ApplicationSettingsObj ApplicationSettings { get; set; }

        [JsonProperty("applicationSettings")]
        public SettingsInfoObj SettingsInfo { get; set; }

        [JsonProperty("resCode")]
        public int ResCode { get; set; }

        [JsonProperty("resDescription")]
        public int ResDescription { get; set; }
    }
}
