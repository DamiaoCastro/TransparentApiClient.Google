using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources { 

	public class Projects : BaseClient {

		public Projects(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/bigquery/v2/",
		    		new string[] {"https://www.googleapis.com/auth/bigquery","https://www.googleapis.com/auth/cloud-platform","https://www.googleapis.com/auth/cloud-platform.read-only"}) {
		}

		/// <summary>
		/// Returns the email address of the service account for your project used for interactions with Google Cloud KMS.
		/// </summary>
		/// <param name="projectId">Project ID for which the service account is requested.</param>
		public Task<BaseResponse<Schema.GetServiceAccountResponse>> GetServiceAccountAsync(string projectId, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(projectId)) { throw new ArgumentNullException(nameof(projectId)); }

			return SendAsync(HttpMethod.Get, $"projects/{projectId}/serviceAccount", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.GetServiceAccountResponse>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Lists all projects to which you have been granted any project role.
		/// </summary>
		/// <param name="maxResults">Maximum number of results to return</param>
		/// <param name="pageToken">Page token, returned by a previous call, to request the next page of results</param>
		public Task<BaseResponse<Schema.ProjectList>> ListAsync(int? maxResults, string pageToken, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {

			string queryString = GetQueryString(new {maxResults, pageToken});

			return SendAsync(HttpMethod.Get, $"projects?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.ProjectList>, cancellationToken)
				.Unwrap();
		}

	}

}