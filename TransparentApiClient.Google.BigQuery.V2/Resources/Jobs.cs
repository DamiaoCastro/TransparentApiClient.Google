using System.Threading;using System.Net.Http;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources { 

	public class Jobs : BaseClient {

		public Jobs(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "", new string[] { }) {
		}

		/// <summary>
		/// Requests that a job be cancelled. This call will return immediately, and the client will need to poll for the job status to see if the cancel completed successfully. Cancelled jobs may still incur costs.
		/// </summary>
		public Task<BaseResponse<object>> CancelAsync(string jobId, string projectId, CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/jobs/{jobId}/cancel", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Returns information about a specific job. Job information is available for a six month period after creation. Requires that you're the person who ran the job, or have the Is Owner project role.
		/// </summary>
		public Task<BaseResponse<object>> GetAsync(string jobId, string projectId, CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/jobs/{jobId}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Retrieves the results of a query job.
		/// </summary>
		public Task<BaseResponse<object>> GetQueryResultsAsync(string jobId, string projectId, CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/queries/{jobId}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Starts a new asynchronous job. Requires the Can View project role.
		/// </summary>
		public Task<BaseResponse<object>> InsertAsync(string projectId, CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/jobs", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Lists all jobs that you started in the specified project. Job information is available for a six month period after creation. The job list is sorted in reverse chronological order, by job creation time. Requires the Can View project role, or the Is Owner project role if you set the allUsers property.
		/// </summary>
		public Task<BaseResponse<object>> ListAsync(string projectId, CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/jobs", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Runs a BigQuery SQL query synchronously and returns query results if the query completes within a specified timeout.
		/// </summary>
		public Task<BaseResponse<object>> QueryAsync(string projectId, CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/queries", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

	}

}