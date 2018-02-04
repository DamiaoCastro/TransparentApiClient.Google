using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Tabledata {
    public class TabledataClient : BaseClient {

        public TabledataClient(byte[] serviceAccountCredentials) :
            base(serviceAccountCredentials, "https://www.googleapis.com/bigquery/v2/", new string[] { "https://www.googleapis.com/auth/bigquery", "https://www.googleapis.com/auth/bigquery.insertdata" }) {
        }

        /// <summary>
        /// https://cloud.google.com/bigquery/docs/reference/rest/v2/tabledata/insertAll
        /// </summary>
        /// <param name="projectId">Project ID of the destination table.</param>
        /// <param name="datasetId">Dataset ID of the destination table.</param>
        /// <param name="tableId">Table ID of the destination table.</param>
        /// <returns></returns>
        public Task<BaseResponse<InsertAllResponse>> InsertAllAsync(string projectId, string datasetId, string tableId, InsertAllRequest requestBody, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
            if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
            if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }
            if (requestBody == null) { throw new ArgumentNullException(nameof(requestBody)); }

            return SendAsync(HttpMethod.Post, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}/insertAll", requestBody, cancellationToken)
                .ContinueWith(HandleBaseResponse<InsertAllResponse>, cancellationToken)
                .Unwrap();

        }

        /// <summary>
        /// https://cloud.google.com/bigquery/docs/reference/rest/v2/tabledata/list
        /// </summary>
        /// <param name="projectId">Project ID of the table to read</param>
        /// <param name="datasetId">Dataset ID of the table to read</param>
        /// <param name="tableId">Table ID of the table to read</param>
        /// <param name="maxResults">Maximum number of results to return</param>
        /// <param name="pageToken">Page token, returned by a previous call, identifying the result set</param>
        /// <param name="selectedFields">List of fields to return (comma-separated). If unspecified, all fields are returned</param>
        /// <param name="startIndex">Zero-based index of the starting row to read</param>
        /// <returns></returns>
        public Task<BaseResponse<ListResponse>> ListAsync(
                string projectId,
                string datasetId,
                string tableId,
                uint? maxResults,
                string pageToken,
                string selectedFields,
                uint? startIndex,
                CancellationToken cancellationToken) {

            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }
            if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
            if (string.IsNullOrWhiteSpace(tableId)) { throw new ArgumentNullException(nameof(tableId)); }

            return SendAsync(HttpMethod.Get, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}/data?{ListQueryContruct(maxResults, pageToken, selectedFields, startIndex)}", null, cancellationToken)
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