using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TransparentApiClient.Google.BigQuery.V2 {
    public class TabledataClient : BaseClient {
        public TabledataClient(byte[] serviceAccountCredentials, string projectId) : base(serviceAccountCredentials, projectId) {
        }

        /// <summary>
        /// https://cloud.google.com/bigquery/docs/reference/rest/v2/tabledata/insertAll
        /// </summary>
        /// <returns></returns>
        public Task InsertAllAsync(string datasetId, string tableId, InsertAllRequestBody insertAllRequestBody, CancellationToken cancellationToken) {

            return SendAsync(HttpMethod.Post, $"datasets/{datasetId}/tables/{tableId}/insertAll", insertAllRequestBody, cancellationToken)
                .ContinueWith((sendTask) => {

                    HttpResponseMessage httpResponseMessage = sendTask.Result;
                    if (httpResponseMessage.IsSuccessStatusCode) {


                    }

                });

        }

    }
}
