using System.Threading;using System.Net.Http;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources { 

	public class Projects : BaseClient {

		public Projects(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "", new string[] { }) {
		}

		/// <summary>
		/// Returns the email address of the service account for your project used for interactions with Google Cloud KMS.
		/// </summary>
		public Task<BaseResponse<object>> GetServiceAccountAsync(string projectId, CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/serviceAccount", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Lists all projects to which you have been granted any project role.
		/// </summary>
		public Task<BaseResponse<object>> ListAsync(CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"projects", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

	}

}