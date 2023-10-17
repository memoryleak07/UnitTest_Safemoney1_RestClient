using Newtonsoft.Json;
using SafemoneyRestClient.Helpers;

namespace SafemoneyRestClient.Models
{
    public class ReadDeviceInfo
    {
        public class DeviceObj
        {
            [JsonProperty("model")]
            public string Model { get; set; }

            [JsonProperty("serial")]
            public string Serial { get; set; }

            [JsonProperty("driverVersion")]
            public string DriverVersion { get; set; }

            [JsonProperty("firmwareVersion")]
            public string FirmwareVersion { get; set; }

            [JsonProperty("patchVersion")]
            public string PatchVersion { get; set; }

        }
        public class FactoryObj
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("www")]
            public string Www { get; set; }

            [JsonProperty("systemname")]
            public string Systemname { get; set; }
        }
        public class LicenseObj
        {
            [JsonProperty("activationKey")]
            public string activationKey { get; set; }

            [JsonProperty("isActived")]
            public bool isActived { get; set; }

            [JsonProperty("licenseKey")]
            public string licenseKey { get; set; }
        }
        // Configuration
        public class ConfigurationObj
        {
            [JsonProperty("HasLoader")]
            public string HasLoader;

            [JsonProperty("HasCashbox")]
            public string HasCashbox;
        }

        public class ConfigurationDev
        {
            [JsonProperty("NOTE")]
            public ConfigurationObj NOTE;

            [JsonProperty("COIN")]
            public ConfigurationObj COIN;
        }


        [JsonProperty("device")]
        public DeviceObj Device { get; set; }

        [JsonProperty("factory")]
        public FactoryObj Factory { get; set; }

        [JsonProperty("license")]
        public LicenseObj License { get; set; }

        [JsonProperty("configuration")]
        public ConfigurationDev Configuration { get; set; }


        [JsonProperty("resCode")]
        public int ResCode { get; set; }

        [JsonProperty("resDescription")]
        public string ResDescription { get; set; }

        public override string ToString()
        {
            return string.Join("|", this.GetItemValue());
        }
    }
}