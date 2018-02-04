using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace TransparentApiClient.Google.BigQuery.V2 {
    public abstract class BaseClient : IDisposable {

        private readonly byte[] serviceAccountCredentials;
        private readonly string projectId;
        private readonly IEnumerable<string> addicionalScopes;
        private HttpClient httpClient = null;

        public BaseClient(byte[] serviceAccountCredentials, string projectId, IEnumerable<string> addicionalScopes) {
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

            this.serviceAccountCredentials = serviceAccountCredentials ?? throw new ArgumentNullException(nameof(serviceAccountCredentials));
            this.projectId = projectId;
            this.addicionalScopes = addicionalScopes;
        }

        protected Task<HttpResponseMessage> SendAsync(HttpMethod httpMethod, string partialUri, object requestBodyObject = null, CancellationToken cancellationToken = default(CancellationToken)) {

            var _httpClient = GetHttpClient();

            HttpContent content = null;
            if (requestBodyObject != null) {
                content = new StringContent(JsonConvert.SerializeObject(requestBodyObject), System.Text.Encoding.UTF8, "application/json");
            }

            var request = new HttpRequestMessage() {
                RequestUri = new Uri($"https://www.googleapis.com/bigquery/v2/projects/{projectId}/{partialUri}"),
                Method = httpMethod,
                Content = content
            };

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

        DateTime t1 = DateTime.UtcNow;
        private HttpClient GetHttpClient() {
            if ((DateTime.UtcNow - t1).TotalHours > 1)//get new http client and new credentials every hour
            {
                httpClient.Dispose();
                httpClient = null;
                t1 = DateTime.UtcNow;
            }

            if (httpClient == null) {
                var scopes = new List<string>() { "https://www.googleapis.com/auth/bigquery" };
                if (addicionalScopes != null && addicionalScopes.Any()) {
                    scopes.AddRange(addicionalScopes);
                }

                var googleCredential = GoogleCredential
                                            .FromStream(new System.IO.MemoryStream(serviceAccountCredentials))
                                            .CreateScoped(scopes);
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
