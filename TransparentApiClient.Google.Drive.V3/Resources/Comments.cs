using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Drive.V3.Resources { 

	public class Comments : BaseClient {

		public Comments(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/drive/v3/",
		    		new string[] {"https://www.googleapis.com/auth/drive","https://www.googleapis.com/auth/drive.file","https://www.googleapis.com/auth/drive.readonly"}) {
		}

		/// <summary>
		/// Creates a new comment on a file.
		/// </summary>
		/// <param name="fileId">The ID of the file.</param>
		public Task<BaseResponse<Schema.Comment>> CreateAsync(string fileId, Schema.Comment Comment, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }

			return SendAsync(HttpMethod.Post, $"files/{fileId}/comments", Comment, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Comment>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Deletes a comment.
		/// </summary>
		/// <param name="commentId">The ID of the comment.</param>
		/// <param name="fileId">The ID of the file.</param>
		public Task<BaseResponse<object>> DeleteAsync(string commentId, string fileId, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(commentId)) { throw new ArgumentNullException(nameof(commentId)); }
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }

			return SendAsync(HttpMethod.Delete, $"files/{fileId}/comments/{commentId}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets a comment by ID.
		/// </summary>
		/// <param name="commentId">The ID of the comment.</param>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="includeDeleted">Whether to return deleted comments. Deleted comments will not include their original content.</param>
		public Task<BaseResponse<Schema.Comment>> GetAsync(string commentId, string fileId, bool? includeDeleted, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(commentId)) { throw new ArgumentNullException(nameof(commentId)); }
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }

			string queryString = GetQueryString(new {includeDeleted});

			return SendAsync(HttpMethod.Get, $"files/{fileId}/comments/{commentId}?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Comment>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Lists a file's comments.
		/// </summary>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="includeDeleted">Whether to include deleted comments. Deleted comments will not include their original content.</param>
		/// <param name="pageSize">The maximum number of comments to return per page.</param>
		/// <param name="pageToken">The token for continuing a previous list request on the next page. This should be set to the value of 'nextPageToken' from the previous response.</param>
		/// <param name="startModifiedTime">The minimum value of 'modifiedTime' for the result comments (RFC 3339 date-time).</param>
		public Task<BaseResponse<Schema.CommentList>> ListAsync(string fileId, bool? includeDeleted, int? pageSize, string pageToken, string startModifiedTime, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }

			string queryString = GetQueryString(new {includeDeleted, pageSize, pageToken, startModifiedTime});

			return SendAsync(HttpMethod.Get, $"files/{fileId}/comments?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.CommentList>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates a comment with patch semantics.
		/// </summary>
		/// <param name="commentId">The ID of the comment.</param>
		/// <param name="fileId">The ID of the file.</param>
		public Task<BaseResponse<Schema.Comment>> UpdateAsync(string commentId, string fileId, Schema.Comment Comment, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(commentId)) { throw new ArgumentNullException(nameof(commentId)); }
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }

			return SendAsync(HttpMethod.Post, $"files/{fileId}/comments/{commentId}", Comment, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Comment>, cancellationToken)
				.Unwrap();
		}

	}

}