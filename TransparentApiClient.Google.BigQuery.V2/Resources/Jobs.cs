using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources {
    
    /// <summary>
    /// Jobs are objects that manage asynchronous tasks such as running queries, loading data, and exporting data. You can run multiple jobs concurrently in BigQuery, and completed jobs will be listed in the Jobs collection.
    /// The Jobs collection stores your project's complete job history, but availability is only guaranteed for jobs created in the past six months. To request automatic deletion of jobs that are more than 50 days old, contact support.
    /// Each job resource includes one of the following child properties, which defines the job type
    /// </summary>
    public class Jobs : BaseClient, IJobs {

        /// <summary>
        /// constructor with mandatory serviceAccountCredentials
        /// </summary>
        /// <param name="serviceAccountCredentials"></param>
        public Jobs(byte[] serviceAccountCredentials)
            : base(serviceAccountCredentials, "https://www.googleapis.com/bigquery/v2/",
                    new string[] { "https://www.googleapis.com/auth/bigquery", "https://www.googleapis.com/auth/cloud-platform", "https://www.googleapis.com/auth/cloud-platform.read-only", "https://www.googleapis.com/auth/devstorage.full_control", "https://www.googleapis.com/auth/devstorage.read_only", "https://www.googleapis.com/auth/devstorage.read_write" }) {
        }

        Task<BaseResponse<Schema.JobCancelResponse>> IJobs.CancelAsync(string jobId, string projectId, string location, JsonSerializerSettings settings, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(jobId)) { throw new ArgumentNullException(nameof(jobId)); }
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

            string queryString = GetQueryString(new { location });

            return SendAsync(HttpMethod.Post, $"projects/{projectId}/jobs/{jobId}/cancel?{queryString}", null, settings, cancellationToken)
                .ContinueWith(HandleBaseResponse<Schema.JobCancelResponse>, cancellationToken)
                .Unwrap();
        }

        Task<BaseResponse<Schema.Job>> IJobs.GetAsync(string jobId, string projectId, string location, JsonSerializerSettings settings, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(jobId)) { throw new ArgumentNullException(nameof(jobId)); }
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

            string queryString = GetQueryString(new { location });

            return SendAsync(HttpMethod.Get, $"projects/{projectId}/jobs/{jobId}?{queryString}", null, settings, cancellationToken)
                .ContinueWith(HandleBaseResponse<Schema.Job>, cancellationToken)
                .Unwrap();
        }

        Task<BaseResponse<Schema.GetQueryResultsResponse>> IJobs.GetQueryResultsAsync(string jobId, string projectId, string location, int? maxResults, string pageToken, string startIndex, int? timeoutMs, JsonSerializerSettings settings, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(jobId)) { throw new ArgumentNullException(nameof(jobId)); }
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

            string queryString = GetQueryString(new { location, maxResults, pageToken, startIndex, timeoutMs });

            return SendAsync(HttpMethod.Get, $"projects/{projectId}/queries/{jobId}?{queryString}", null, settings, cancellationToken)
                .ContinueWith(HandleBaseResponse<Schema.GetQueryResultsResponse>, cancellationToken)
                .Unwrap();
        }

        Task<BaseResponse<Schema.Job>> IJobs.InsertAsync(string projectId, Schema.Job Job, JsonSerializerSettings settings, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

            return SendAsync(HttpMethod.Post, $"projects/{projectId}/jobs", Job, settings, cancellationToken)
                .ContinueWith(HandleBaseResponse<Schema.Job>, cancellationToken)
                .Unwrap();
        }

        Task<BaseResponse<Schema.JobList>> IJobs.ListAsync(string projectId, bool? allUsers, string maxCreationTime, int? maxResults, string minCreationTime, string pageToken, string projection, string stateFilter, JsonSerializerSettings settings, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

            string queryString = GetQueryString(new { allUsers, maxCreationTime, maxResults, minCreationTime, pageToken, projection, stateFilter });

            return SendAsync(HttpMethod.Get, $"projects/{projectId}/jobs?{queryString}", null, settings, cancellationToken)
                .ContinueWith(HandleBaseResponse<Schema.JobList>, cancellationToken)
                .Unwrap();
        }

        Task<BaseResponse<Schema.QueryResponse>> IJobs.QueryAsync(string projectId, Schema.QueryRequest QueryRequest, JsonSerializerSettings settings, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

            return SendAsync(HttpMethod.Post, $"projects/{projectId}/queries", QueryRequest, settings, cancellationToken)
                .ContinueWith(HandleBaseResponse<Schema.QueryResponse>, cancellationToken)
                .Unwrap();
        }

    }

}