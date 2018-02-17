using System.Threading;using System.Net.Http;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources { 

	public class Datasets : BaseClient {

		public Datasets(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "", new string[] { }) {
		}

		/// <summary>
		/// Deletes the dataset specified by the datasetId value. Before you can delete a dataset, you must delete all its tables, either manually or by specifying deleteContents. Immediately after deletion, you can create another dataset with the same name.
		/// </summary>
		public Task<BaseResponse<object>> DeleteAsync(CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Returns the dataset specified by datasetID.
		/// </summary>
		public Task<BaseResponse<object>> GetAsync(CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Creates a new empty dataset.
		/// </summary>
		public Task<BaseResponse<object>> InsertAsync(CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Lists all datasets in the specified project to which you have been granted the READER dataset role.
		/// </summary>
		public Task<BaseResponse<object>> ListAsync(CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Updates information in an existing dataset. The update method replaces the entire dataset resource, whereas the patch method only replaces fields that are provided in the submitted dataset resource. This method supports patch semantics.
		/// </summary>
		public Task<BaseResponse<object>> PatchAsync(CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Updates information in an existing dataset. The update method replaces the entire dataset resource, whereas the patch method only replaces fields that are provided in the submitted dataset resource.
		/// </summary>
		public Task<BaseResponse<object>> UpdateAsync(CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

	}

}