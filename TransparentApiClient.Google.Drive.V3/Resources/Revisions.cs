using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Drive.V3.Resources { 

	public class Revisions : BaseClient {

		public Revisions(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/drive/v3/",
		    		new string[] {"https://www.googleapis.com/auth/drive","https://www.googleapis.com/auth/drive.appdata","https://www.googleapis.com/auth/drive.file","https://www.googleapis.com/auth/drive.metadata","https://www.googleapis.com/auth/drive.metadata.readonly","https://www.googleapis.com/auth/drive.photos.readonly","https://www.googleapis.com/auth/drive.readonly"}) {
		}

		/// <summary>
		/// Permanently deletes a revision. This method is only applicable to files with binary content in Drive.
		/// </summary>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="revisionId">The ID of the revision.</param>
		public Task<BaseResponse<object>> DeleteAsync(string fileId, string revisionId, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }
			if (string.IsNullOrWhiteSpace(revisionId)) { throw new ArgumentNullException(nameof(revisionId)); }

			return SendAsync(HttpMethod.Delete, $"files/{fileId}/revisions/{revisionId}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets a revision's metadata or content by ID.
		/// </summary>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="revisionId">The ID of the revision.</param>
		/// <param name="acknowledgeAbuse">Whether the user is acknowledging the risk of downloading known malware or other abusive files. This is only applicable when alt=media.</param>
		public Task<BaseResponse<Schema.Revision>> GetAsync(string fileId, string revisionId, bool? acknowledgeAbuse, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }
			if (string.IsNullOrWhiteSpace(revisionId)) { throw new ArgumentNullException(nameof(revisionId)); }

			string queryString = GetQueryString(new {acknowledgeAbuse});

			return SendAsync(HttpMethod.Get, $"files/{fileId}/revisions/{revisionId}?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Revision>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Lists a file's revisions.
		/// </summary>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="pageSize">The maximum number of revisions to return per page.</param>
		/// <param name="pageToken">The token for continuing a previous list request on the next page. This should be set to the value of 'nextPageToken' from the previous response.</param>
		public Task<BaseResponse<Schema.RevisionList>> ListAsync(string fileId, int? pageSize, string pageToken, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }

			string queryString = GetQueryString(new {pageSize, pageToken});

			return SendAsync(HttpMethod.Get, $"files/{fileId}/revisions?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.RevisionList>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates a revision with patch semantics.
		/// </summary>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="revisionId">The ID of the revision.</param>
		public Task<BaseResponse<Schema.Revision>> UpdateAsync(string fileId, string revisionId, Schema.Revision Revision, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }
			if (string.IsNullOrWhiteSpace(revisionId)) { throw new ArgumentNullException(nameof(revisionId)); }

			return SendAsync(HttpMethod.Post, $"files/{fileId}/revisions/{revisionId}", Revision, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Revision>, cancellationToken)
				.Unwrap();
		}

	}

}