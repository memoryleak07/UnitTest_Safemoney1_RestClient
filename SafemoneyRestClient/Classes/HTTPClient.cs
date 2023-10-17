//using DitronSearch.Infrastructure.Models;
using Newtonsoft.Json;
using SafemoneyRestClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SafemoneyRestClient
{

    public class HTTPClient
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public HttpClient HttpClient { get; private set; }
        public string BaseURI { get; private set; }

        public HTTPClient(string baseURI)
        {
            BaseURI = baseURI;
        }

        public T ManageResponse<T>(HttpResponseMessage response)
        {
            var errorMessage = "";
            return ManageResponse<T>(response, out errorMessage);
        }

        public T ManageResponse<T>(HttpResponseMessage response, out string errorMessage)
        //ML: could add statusCode|errorMessage
        {
            errorMessage = null;
            try
            {
                var resp = (T)Activator.CreateInstance(typeof(T));
                var stream = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                { resp = JsonConvert.DeserializeObject<T>(stream); }
                else
                {
                    try { resp = JsonConvert.DeserializeObject<T>(stream); }
                    catch
                    {
                    }
                    errorMessage = stream;
                }

                return resp;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
            }
        }

        protected string BuildPath(string path, Dictionary<string, string> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return path;

            // Path di base
            path += "?";
            foreach (string key in parameters.Keys)
                path += key + "=" + parameters[key] + "&";

            return path.Remove(path.Length - 1);
        }

        protected string CreateRequest(string offsetOperation)
        {
            return BaseURI + "/" + offsetOperation;
        }

        protected HttpResponseMessage DeleteModel(object mdl, string path, Dictionary<string, string> parameters = null)
        {
            return SendModel(mdl, path, parameters, HttpMethod.Delete);
        }

        public void Instance(AuthenticationType authType, string username = null, string psw = null, string token = null)
        {
            var httpClient = new HttpClient
            {
                Timeout = new TimeSpan(0, 0, 100)
            };

            switch (authType)
            {
                case AuthenticationType.None:
                    break;
                case AuthenticationType.Basic:
                    if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(psw))
                        goto default;
                    this.Username = username;
                    this.Password = psw;
                    token = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, psw)));
                    break;
                case AuthenticationType.Bearer:
                    if (string.IsNullOrEmpty(token))
                        goto default;
                    break;
                default:
                    throw new Exception("AUTHENTICATION_ERROR");
            }

            if (authType != AuthenticationType.None)
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authType.ToString(), token);

            this.HttpClient = httpClient;
        }

        protected void ManageBadResponse(HttpResponseMessage response)
        {
            var res = ManageResponse<BadResponse>(response, out string msg);
            res = res ?? new BadResponse();
            res.statusCode = response.StatusCode.ToString();
            res.statusMessage = msg;
            throw new HttpException(res);
        }

        protected HttpResponseMessage GetModel(string path, Dictionary<string, string> parameters = null)
        {
            path = BuildPath(path, parameters);
            var response = HttpClient.GetAsync(CreateRequest(path)).Result;

            if (!response.IsSuccessStatusCode)
                //throw new Exception(string.Format("GetServerError", CreateRequest(path), response.StatusCode, response.ReasonPhrase));
                ManageBadResponse(response);
            return response;
        }

        protected HttpResponseMessage PostModel(object mdl, string path, Dictionary<string, string> parameters = null)
        {
            return SendModel(mdl, path, parameters, HttpMethod.Post);
        }

        protected HttpResponseMessage PutModel(object mdl, string path, Dictionary<string, string> parameters = null)
        {
            return SendModel(mdl, path, parameters, HttpMethod.Put);
        }

        protected HttpResponseMessage SendModel(object mdl, string path, Dictionary<string, string> parameters, HttpMethod method)
        {
            string jsonString = String.Empty;

            if (mdl != null)
            {
                jsonString = JsonConvert.SerializeObject(mdl);
            }
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            path = BuildPath(path, parameters);

            HttpResponseMessage response = null;
            if (HttpMethod.Post.Equals(method))
            { response = HttpClient.PostAsync(CreateRequest(path), content).Result; }
            else if (HttpMethod.Put.Equals(method))
            { response = HttpClient.PutAsync(CreateRequest(path), content).Result; }
            else if (HttpMethod.Delete.Equals(method))
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, CreateRequest(path));
                request.Content = content;
                response = HttpClient.SendAsync(request).Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                ManageBadResponse(response);
            }
            return response;
        }

        protected HttpResponseMessage PostFile(string path, string fPath, Dictionary<string, string> parameters = null)
        {
            HttpResponseMessage response = null;

            using (var formFile = new MultipartFormDataContent())
            {
                using (var fileStreamContent = new StreamContent(new FileStream(fPath, FileMode.Open)))
                {
                    var fExt = Path.GetExtension(fPath).Substring(1);
                    var fName = Path.GetFileName(fPath);
                    formFile.Add(fileStreamContent, "formFile", fName);
                    path = BuildPath(path, parameters);

                    response = HttpClient.PostAsync(CreateRequest(path), formFile).Result;

                    fileStreamContent.Dispose();
                    formFile.Dispose();
                    if (!response.IsSuccessStatusCode)
                    {
                        ManageBadResponse(response);
                    }
                }
            }
            return response;
        }

        protected void GetFile(string path, string fPath, Dictionary<string, string> parameters = null)
        {
            var downloadTask = GetModel(path, parameters);

            using (Task<Stream> downloadResponseTask = downloadTask.Content.ReadAsStreamAsync())
            {
                downloadResponseTask.Wait();

                string basePath = Path.GetDirectoryName(fPath);
                if (!Directory.Exists(basePath))
                    Directory.CreateDirectory(basePath);

                using (FileStream fileStream = new FileStream(fPath, FileMode.Create))
                {
                    downloadResponseTask.Result.CopyTo(fileStream);
                }
            }
        }
    }
}