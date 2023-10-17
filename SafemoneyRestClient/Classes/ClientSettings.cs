using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

namespace SafemoneyRestClient
{
    public static class ClientSettings
    {
        public static string BaseURI { get; set; } = "";
        public static string Username { get; set; } = "";
        public static string Password { get; set; } = "";
        public static string ProxyAddress { get; internal set; } = "";
        public static string ApiVersion { get; internal set; } = "";
        public static string Token { get; set; } = "";
        [JsonConverter(typeof(StringEnumConverter))]
        public static AuthenticationType AuthType { get; set; } = AuthenticationType.None;
        static ClientSettings()
        {
            using (var stream = new FileStream("appsettings.json", FileMode.Open, FileAccess.Read))
            {
                var buf = new byte[stream.Length];
                stream.Read(buf, 0, buf.Length);
                //ClientSettingsJsonSerializable? d = JsonConvert.DeserializeObject<ClientSettingsJsonSerializable>(Encoding.UTF8.GetString(buf));
                var tmp = JObject.Parse(Encoding.UTF8.GetString(buf));
                if (tmp == null)
                    return;
                var settings = tmp["ClientSettings"];
                ClientSettingsJsonSerializable d = JsonConvert.DeserializeObject<ClientSettingsJsonSerializable>(settings.ToString());
                if (d == null)
                    return;
                BaseURI = d.URL;
                ProxyAddress = d.ProxyAddress;
                ApiVersion = d.ApiVersion;
                Token = d.Token;
                AuthType = d.AuthType;
                Username = d.Username;
                Password = d.Password;

            }
        }
    }

    public class ClientSettingsJsonSerializable
    {
        public string URL { get; set; }
        public string Token { get; set; }
        public string ProxyAddress { get; set; }
        public string ApiVersion { get; set; }
        public AuthenticationType AuthType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}