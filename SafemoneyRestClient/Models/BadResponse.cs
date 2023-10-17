//using DitronSearch.Infrastructure.Classes;
//using DitronSearch.Infrastructure.Models;
//using DitronSearch.Plugin.CheckPartitaIVA_CercaImpresaBase.Models;

using SafemoneyRestClient.Helpers;

namespace SafemoneyRestClient.Models
{
    public class BadResponse
    {
        public string statusCode { get; set; }
        public string statusMessage { get; set; }

        public override string ToString()
        {
            return string.Join("|", this.GetItemValue());
        }
    }
}