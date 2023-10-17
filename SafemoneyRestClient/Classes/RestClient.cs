//using DitronSearch.Infrastructure.Classes;
//using DitronSearch.Infrastructure.Models;
//using DitronSearch.Plugin.CheckPartitaIVA_CercaImpresaBase.Models;

using SafemoneyRestClient.Models;
using System.Collections.Generic;

namespace SafemoneyRestClient
{
    public class RestClient : HTTPClient
    {
        private readonly string API_VERSION;

        public RestClient(string baseURI, string apiVersion, AuthenticationType authenticationType, string username = null, string password = null, string token = null) :
            base(baseURI)
        {
            API_VERSION = apiVersion;
            base.Instance(authenticationType, username, password, token);
        }

        public RestClient() : this(ClientSettings.BaseURI, ClientSettings.ApiVersion, ClientSettings.AuthType, ClientSettings.Username, ClientSettings.Password, ClientSettings.Token)
        {
        }

        public RestClient(string ip, string username, string password) : this(ip, string.Empty, AuthenticationType.Basic, username, password)
        {
        }
        //public CompanyBasicInformation GetBasicInformation(string pIva)
        //{
        //    var resp = GetModel($"base/{pIva}");

        //    if (resp.StatusCode == System.Net.HttpStatusCode.NoContent)
        //        throw new Exception("NO_CONTENT");
        //    return ManageResponse<CompanyBasicInformation>(resp);
        //}

        public ReadCreatedPayResp Reboot()
        {
            var res = PutModel(null, "reboot");
            return ManageResponse<ReadCreatedPayResp>(res);
        }

        public ReadCreatedPayResp Poweroff()
        {
            var res = PutModel(null, "poweroff");
            return ManageResponse<ReadCreatedPayResp>(res);
        }

        public ReadCreatedPayResp CreatePayment(CreatePay body)
        {
            var res = PostModel(body, "pay");
            return ManageResponse<ReadCreatedPayResp>(res);
        }

        public ReadCreatedPayResp CreateWithdraw(CreatePay body)
        {
            var res = PostModel(body, "withdraw");
            return ManageResponse<ReadCreatedPayResp>(res);
        }

        public ReadCreatedPayResp BeginPayment(BeginPay body)
        {
            var res = PostModel(body, "beginPayment");
            return ManageResponse<ReadCreatedPayResp>(res);
        }

        public ReadResultPayResp AbortPayment(BeginPay body)
        {
            var res = DeleteModel(body, "pay");
            return ManageResponse<ReadResultPayResp>(res);
        }

        public ReadResultPayResp GetPay(string token)
        {
            var res = GetModel("pay", new Dictionary<string, string>() { { "token", token } });
            return ManageResponse<ReadResultPayResp>(res);
        }

        public ReadResulPayRespList QueryPayments(TransactionList body)
        {
            var res = PostModel(body, "queryPayments");
            return ManageResponse<ReadResulPayRespList>(res);
        }
        //<<>>
        public ReadCashWithdrawLevel CashWithdrawLevel(CashList body)
        {
            var res = PostModel(body, "cashWithdrawLevel");
            return ManageResponse<ReadCashWithdrawLevel>(res);
        }
        //public CashWithdrawLevel CashWithdrawLevel(CashList body)
        //{
        //    var res = PostModel(body, "cashWithdrawLevel");
        //    return ManageResponse<CashWithdrawLevel>(res);
        //}


        public InventoryList GetInventory()
        {
            var res = GetModel("inventory");
            return ManageResponse<InventoryList>(res);
        }

        public InventoryList EmptyCashPartial()
        {
            var res = PostModel(null, "emptyCashPartial");
            return ManageResponse<InventoryList>(res);
        }

        public InventoryList EmptyCashTotal()
        {
            var res = PostModel(null, "emptyCashTotal");
            return ManageResponse<InventoryList>(res);
        }
        public ReadDeviceInfo GetDeviceInfo()
        {
            var res = GetModel("deviceInfo");
            return ManageResponse<ReadDeviceInfo>(res);
        }
        public ReadSettings GetSettings()
        {
            var res = GetModel("settings");
            return ManageResponse<ReadSettings>(res);
        }
    }
}
