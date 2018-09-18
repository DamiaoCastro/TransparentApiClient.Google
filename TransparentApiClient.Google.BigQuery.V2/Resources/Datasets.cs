using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources {

    /// <summary>
    /// Datasets allow you to organize and control access to your tables. For more information, see Datasets https://cloud.google.com/bigquery/docs/datasets.
    /// For a list of methods for this resource, see the end of this page. https://cloud.google.com/bigquery/docs/reference/rest/v2/datasets
    /// </summary>
    public class Datasets : BaseClient, IDatasets {
        
        /// <summary>
        /// constructor with mandatory serviceAccountCredentials
        /// </summary>
        /// <param name="serviceAccountCredentials"></param>
        public Datasets(byte[] serviceAccountCredentials)
            : base(serviceAccountCredentials, "https://www.googleapis.com/bigquery/v2/",
                    new string[] { "https://www.googleapis.com/auth/bigquery", "https://www.googleapis.com/auth/cloud-platform", "https://www.googleapis.com/auth/cloud-platform.read-only" }) {
        }

        Task<BaseResponse<object>> IDatasets.DeleteAsync(string datasetId, string projectId, bool? deleteContents, JsonSerializerSettings settings, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

            string queryString = GetQueryString(new { deleteContents });

            return SendAsync(HttpMethod.Delete, $"projects/{projectId}/datasets/{datasetId}?{queryString}", null, settings, cancellationToken)
                .ContinueWith(HandleBaseResponse<object>, cancellationToken)
                .Unwrap();
        }

        Task<BaseResponse<Schema.Dataset>> IDatasets.GetAsync(string datasetId, string projectId, JsonSerializerSettings settings, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

            return SendAsync(HttpMethod.Get, $"projects/{projectId}/datasets/{datasetId}", null, settings, cancellationToken)
                .ContinueWith(HandleBaseResponse<Schema.Dataset>, cancellationToken)
                .Unwrap();
        }

        Task<BaseResponse<Schema.Dataset>> IDatasets.InsertAsync(string projectId, Schema.Dataset Dataset, JsonSerializerSettings settings, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

            return SendAsync(HttpMethod.Post, $"projects/{projectId}/datasets", Dataset, settings, cancellationToken)
                .ContinueWith(HandleBaseResponse<Schema.Dataset>, cancellationToken)
                .Unwrap();
        }

        Task<BaseResponse<Schema.DatasetList>> IDatasets.ListAsync(string projectId, bool? all, string filter, int? maxResults, string pageToken, JsonSerializerSettings settings, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

            string queryString = GetQueryString(new { all, filter, maxResults, pageToken });

            return SendAsync(HttpMethod.Get, $"projects/{projectId}/datasets?{queryString}", null, settings, cancellationToken)
                .ContinueWith(HandleBaseResponse<Schema.DatasetList>, cancellationToken)
                .Unwrap();
        }

        Task<BaseResponse<Schema.Dataset>> IDatasets.PatchAsync(string datasetId, string projectId, Schema.Dataset Dataset, JsonSerializerSettings settings, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

            return SendAsync(HttpMethod.Post, $"projects/{projectId}/datasets/{datasetId}", Dataset, settings, cancellationToken)
                .ContinueWith(HandleBaseResponse<Schema.Dataset>, cancellationToken)
                .Unwrap();
        }

        Task<BaseResponse<Schema.Dataset>> IDatasets.UpdateAsync(string datasetId, string projectId, Schema.Dataset Dataset, JsonSerializerSettings settings, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(datasetId)) { throw new ArgumentNullException(nameof(datasetId)); }
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

            return SendAsync(HttpMethod.Put, $"projects/{projectId}/datasets/{datasetId}", Dataset, settings, cancellationToken)
                .ContinueWith(HandleBaseResponse<Schema.Dataset>, cancellationToken)
                .Unwrap();
        }

    }

}