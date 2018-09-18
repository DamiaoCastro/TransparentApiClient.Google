using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources {
    
    /// <summary>
    /// Projects are top-level containers in the Google Cloud Platform. For more information, see Projects.
    /// The BigQuery API enables you to list projects by using the bigquery.projects.list method, but creating and managing projects occur outside of the API.For information about how to create or manage projects, see Managing Projects.
    /// For a list of methods for this resource, see the end of this page https://cloud.google.com/bigquery/docs/reference/rest/v2/projects.
    /// </summary>
    public class Projects : BaseClient, IProjects {

        /// <summary>
        /// constructor with mandatory serviceAccountCredentials
        /// </summary>
        /// <param name="serviceAccountCredentials"></param>
        public Projects(byte[] serviceAccountCredentials)
            : base(serviceAccountCredentials, "https://www.googleapis.com/bigquery/v2/",
                    new string[] { "https://www.googleapis.com/auth/bigquery", "https://www.googleapis.com/auth/cloud-platform", "https://www.googleapis.com/auth/cloud-platform.read-only" }) {
        }

        Task<BaseResponse<Schema.GetServiceAccountResponse>> IProjects.GetServiceAccountAsync(string projectId, JsonSerializerSettings settings, CancellationToken cancellationToken) {
            if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

            return SendAsync(HttpMethod.Get, $"projects/{projectId}/serviceAccount", null, settings, cancellationToken)
                .ContinueWith(HandleBaseResponse<Schema.GetServiceAccountResponse>, cancellationToken)
                .Unwrap();
        }

        Task<BaseResponse<Schema.ProjectList>> IProjects.ListAsync(int? maxResults, string pageToken, JsonSerializerSettings settings, CancellationToken cancellationToken) {
            string queryString = GetQueryString(new { maxResults, pageToken });

            return SendAsync(HttpMethod.Get, $"projects?{queryString}", null, settings, cancellationToken)
                .ContinueWith(HandleBaseResponse<Schema.ProjectList>, cancellationToken)
                .Unwrap();
        }

    }

}