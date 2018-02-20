using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Gmail.V1.Resources { 

	public class History : BaseClient {

		public History(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/gmail/v1/users/",
		    		new string[] {"https://mail.google.com/","https://www.googleapis.com/auth/gmail.metadata","https://www.googleapis.com/auth/gmail.modify","https://www.googleapis.com/auth/gmail.readonly"}) {
		}

		/// <summary>
		/// Lists the history of all changes to the given mailbox. History results are returned in chronological order (increasing historyId).
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		/// <param name="historyTypes">History types to be returned by the function</param>
		/// <param name="labelId">Only return messages with a label matching the ID.</param>
		/// <param name="maxResults">The maximum number of history records to return.</param>
		/// <param name="pageToken">Page token to retrieve a specific page of results in the list.</param>
		/// <param name="startHistoryId">Required. Returns history records after the specified startHistoryId. The supplied startHistoryId should be obtained from the historyId of a message, thread, or previous list response. History IDs increase chronologically but are not contiguous with random gaps in between valid IDs. Supplying an invalid or out of date startHistoryId typically returns an HTTP 404 error code. A historyId is typically valid for at least a week, but in some rare circumstances may be valid for only a few hours. If you receive an HTTP 404 error response, your application should perform a full sync. If you receive no nextPageToken in the response, there are no updates to retrieve and you can store the returned historyId for a future request.</param>
		public Task<BaseResponse<Schema.ListHistoryResponse>> ListAsync(string userId, string historyTypes, string labelId, int? maxResults, string pageToken, string startHistoryId, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			string queryString = GetQueryString(new {historyTypes, labelId, maxResults, pageToken, startHistoryId});

			return SendAsync(HttpMethod.Get, $"{userId}/history?{queryString}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.ListHistoryResponse>, cancellationToken)
				.Unwrap();
		}

	}

}