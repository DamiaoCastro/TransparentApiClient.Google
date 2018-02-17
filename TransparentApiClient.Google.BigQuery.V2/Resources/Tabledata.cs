using System.Threading;using System.Net.Http;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.BigQuery.V2.Resources { 

	public class Tabledata : BaseClient {

		public Tabledata(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "", new string[] { }) {
		}

		/// <summary>
		/// Streams data into BigQuery one record at a time without needing to run a load job. Requires the WRITER dataset role.
		/// </summary>
		public Task<BaseResponse<object>> InsertAllAsync(CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

		/// <summary>
		/// Retrieves table data from a specified set of rows. Requires the READER dataset role.
		/// </summary>
		public Task<BaseResponse<object>> ListAsync(CancellationToken cancellationToken) {

			return SendAsync(HttpMethod.Post, $"", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();

		}

	}

}