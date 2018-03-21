using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        protected Task<HttpResponseMessage> SendAsync(HttpMethod httpMethod, string partialUri, object requestBodyObject = null, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {

            var _httpClient = GetHttpClient();

            HttpContent content = null;
            if (requestBodyObject != null) {
                //content = new StringContent(JsonConvert.SerializeObject(requestBodyObject), System.Text.Encoding.UTF8, "application/json");

                byte[] compressedBodyBytes;
                using (var memoryStream = new System.IO.MemoryStream()) {
                    var requestBodyObjectBytes = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(requestBodyObject, Formatting.None, settings));
                    using (var zipStream = new System.IO.Compression.GZipStream(memoryStream, System.IO.Compression.CompressionMode.Compress)) {
                        zipStream.Write(requestBodyObjectBytes, 0, requestBodyObjectBytes.Length);
                    }
                    compressedBodyBytes = memoryStream.ToArray();
                }

                content = new ByteArrayContent(compressedBodyBytes);
            }

            var request = new HttpRequestMessage() { RequestUri = new Uri($"{baseUri}{partialUri}"), Method = httpMethod, Content = content };
            request.Content.Headers.ContentEncoding.Add("gzip");
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            return _httpClient.SendAsync(request, cancellationToken);
        }

        protected Task<BaseResponse<T>> HandleBaseResponse<T>(Task<HttpResponseMessage> sendTask) {

            var response = sendTask.Result;

            var baseResponse = new BaseResponse<T>() { Success = false };
            baseResponse.ResponseCode = response.StatusCode;
            baseResponse.Success = response.IsSuccessStatusCode;
            if (response.Content.Headers.ContentEncoding.Contains("gzip")) {

                return response.Content.ReadAsByteArrayAsync()
                    .ContinueWith((readAsByteArrayTask) => {
                        byte[] resultByteArray = readAsByteArrayTask.Result;

                        var memoryStream = new MemoryStream();
                        using (var zipStream = new System.IO.Compression.GZipStream(new MemoryStream(resultByteArray), System.IO.Compression.CompressionMode.Decompress)) {
                            zipStream.CopyTo(memoryStream);
                        }

                        string responseBody = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
                        return GetResponse(baseResponse, responseBody);
                    });


            } else {
                return response.Content.ReadAsStringAsync()
                    .ContinueWith((readTask) => {

                        string responseBody = readTask.Result;
                        return GetResponse(baseResponse, responseBody);

                    });

            }
        }

        private static BaseResponse<T> GetResponse<T>(BaseResponse<T> baseResponse, string responseBody) {
            if (baseResponse.Success) {
                baseResponse.Response = JsonConvert.DeserializeObject<T>(responseBody);
            } else {
                try {
                    baseResponse.Error = JsonConvert.DeserializeObject<ErrorSuper>(responseBody).error;
                } catch (Exception) {
                    baseResponse.ErrorText = responseBody;
                }
            }

            return baseResponse;
        }

        private class ErrorSuper {
            public ErrorResponse error { get; set; }
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
