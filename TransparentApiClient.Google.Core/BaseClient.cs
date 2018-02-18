using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace TransparentApiClient.Google.Core {
    public abstract class BaseClient : IDisposable {

        private readonly byte[] serviceAccountCredentials;
        private readonly string baseUri;
        private readonly IEnumerable<string> scopes;
        private HttpClient httpClient = null;

        public BaseClient(byte[] serviceAccountCredentials, string baseUri, IEnumerable<string> scopes) {
            this.serviceAccountCredentials = serviceAccountCredentials ?? throw new ArgumentNullException(nameof(serviceAccountCredentials));
            if (string.IsNullOrWhiteSpace(baseUri)) { throw new ArgumentNullException(nameof(baseUri)); }
            this.scopes = scopes ?? throw new ArgumentNullException(nameof(scopes));

            this.baseUri = baseUri;
        }

        protected Task<HttpResponseMessage> SendAsync(HttpMethod httpMethod, string partialUri, object requestBodyObject = null, CancellationToken cancellationToken = default(CancellationToken)) {

            var _httpClient = GetHttpClient();

            HttpContent content = null;
            if (requestBodyObject != null) {
                content = new StringContent(JsonConvert.SerializeObject(requestBodyObject), System.Text.Encoding.UTF8, "application/json");
            }

            var request = new HttpRequestMessage() { RequestUri = new Uri($"{baseUri}{partialUri}"), Method = httpMethod, Content = content };

            return _httpClient.SendAsync(request, cancellationToken);
        }

        protected Task<BaseResponse<T>> HandleBaseResponse<T>(Task<HttpResponseMessage> sendTask) {

            var response = sendTask.Result;

            var baseResponse = new BaseResponse<T>() { Success = false };
            baseResponse.ResponseCode = response.StatusCode;

            if (response.IsSuccessStatusCode) {
                baseResponse.Success = true;

                return response.Content.ReadAsStringAsync()
                    .ContinueWith((readTask) => {

                        string responseBody = readTask.Result;
                        baseResponse.Response = JsonConvert.DeserializeObject<T>(responseBody);

                        return baseResponse;
                    });
            }

            return Task.FromResult(baseResponse);
        }

        protected string GetQueryString(object parameters) {

            var queryParameters = from c in parameters.GetType().GetProperties()
                                  let value = c.GetValue(parameters)
                                  where value != null
                                  select $"{c.Name}={Uri.EscapeUriString($"{value}")}";

            var quertString = $"{string.Join("&", queryParameters)}";
            return quertString;
        }

        DateTime t1 = DateTime.UtcNow;
        private HttpClient GetHttpClient() {
            if ((DateTime.UtcNow - t1).TotalHours > 1)//get new http client and new credentials every hour
            {
                httpClient.Dispose();
                httpClient = null;
                t1 = DateTime.UtcNow;
            }

            if (httpClient == null) {
                var googleCredential = GoogleCredential.FromStream(new System.IO.MemoryStream(serviceAccountCredentials)).CreateScoped(scopes);
                var accessToken = googleCredential.UnderlyingCredential.GetAccessTokenForRequestAsync().Result;

                httpClient = new System.Net.Http.HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
            return httpClient;
        }

        void IDisposable.Dispose() {
            httpClient?.Dispose();
        }

    }
}
