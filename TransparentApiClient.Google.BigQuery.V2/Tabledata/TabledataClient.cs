using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TransparentApiClient.Google.BigQuery.V2.Tabledata {
    public class TabledataClient : BaseClient {

        public TabledataClient(byte[] serviceAccountCredentials, string projectId) :
            base(serviceAccountCredentials, projectId, new string[] { "https://www.googleapis.com/auth/bigquery.insertdata" }) {
        }

        /// <summary>
        /// https://cloud.google.com/bigquery/docs/reference/rest/v2/tabledata/insertAll
        /// </summary>
        /// <param name="datasetId">Dataset ID of the table to read</param>
        /// <param name="tableId">Table ID of the table to read</param>
        /// <returns></returns>
        public Task<BaseResponse<InsertAllResponse>> InsertAllAsync(string datasetId, string tableId, InsertAllRequest requestBody, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
            if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }
            if (requestBody == null) { throw new ArgumentNullException(nameof(requestBody)); }

            return SendAsync(HttpMethod.Post, $"datasets/{datasetId}/tables/{tableId}/insertAll", requestBody, cancellationToken)
                .ContinueWith(HandleBaseResponse<InsertAllResponse>, cancellationToken)
                .Unwrap();

        }

        /// <summary>
        /// https://cloud.google.com/bigquery/docs/reference/rest/v2/tabledata/list
        /// </summary>
        /// <param name="datasetId">Dataset ID of the table to read</param>
        /// <param name="tableId">Table ID of the table to read</param>
        /// <param name="maxResults">Maximum number of results to return</param>
        /// <param name="pageToken">Page token, returned by a previous call, identifying the result set</param>
        /// <param name="selectedFields">List of fields to return (comma-separated). If unspecified, all fields are returned</param>
        /// <param name="startIndex">Zero-based index of the starting row to read</param>
        /// <returns></returns>
        public Task<BaseResponse<ListResponse>> ListAsync(
                string datasetId,
                string tableId,
                uint? maxResults,
                string pageToken,
                string selectedFields,
                uint? startIndex,
                CancellationToken cancellationToken) {

            if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
            if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }

            return SendAsync(HttpMethod.Get, $"datasets/{datasetId}/tables/{tableId}/data?{ListQueryContruct(maxResults, pageToken, selectedFields, startIndex)}", null, cancellationToken)
                .ContinueWith(HandleBaseResponse<ListResponse>, cancellationToken)
                .Unwrap();

        }

        private string ListQueryContruct(uint? maxResults, string pageToken, string selectedFields, uint? startIndex) {

            var listOfValues = new List<string>();

            if (maxResults.HasValue) { listOfValues.Add($"maxResults={maxResults.Value}"); }
            if (!string.IsNullOrWhiteSpace(pageToken)) { listOfValues.Add($"pageToken={pageToken}"); }
            if (!string.IsNullOrWhiteSpace(selectedFields)) { listOfValues.Add($"selectedFields={selectedFields}"); }
            if (startIndex.HasValue) { listOfValues.Add($"startIndex={startIndex.Value}"); }

            return string.Join("&", listOfValues);
        }

    }
}