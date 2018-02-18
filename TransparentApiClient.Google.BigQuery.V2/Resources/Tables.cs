using System.Threading;using System.Net.Http;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources { 

	public class Tables : BaseClient {

		public Tables(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "", new string[] { }) {
		}

		/// <summary>
		/// Deletes the table specified by tableId from the dataset. If the table contains data, all the data will be deleted.
		/// </summary>
		public Task<BaseResponse<object>> DeleteAsync(string datasetId, string projectId, string tableId, CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Gets the specified table resource by table ID. This method does not return the data in the table, it only returns the table resource, which describes the structure of this table.
		/// </summary>
		public Task<BaseResponse<object>> GetAsync(string datasetId, string projectId, string tableId, CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Creates a new, empty table in the dataset.
		/// </summary>
		public Task<BaseResponse<object>> InsertAsync(string datasetId, string projectId, CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/datasets/{datasetId}/tables", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Lists all tables in the specified dataset. Requires the READER dataset role.
		/// </summary>
		public Task<BaseResponse<object>> ListAsync(string datasetId, string projectId, CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/datasets/{datasetId}/tables", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Updates information in an existing table. The update method replaces the entire table resource, whereas the patch method only replaces fields that are provided in the submitted table resource. This method supports patch semantics.
		/// </summary>
		public Task<BaseResponse<object>> PatchAsync(string datasetId, string projectId, string tableId, CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Updates information in an existing table. The update method replaces the entire table resource, whereas the patch method only replaces fields that are provided in the submitted table resource.
		/// </summary>
		public Task<BaseResponse<object>> UpdateAsync(string datasetId, string projectId, string tableId, CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"projects/{projectId}/datasets/{datasetId}/tables/{tableId}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

	}

}