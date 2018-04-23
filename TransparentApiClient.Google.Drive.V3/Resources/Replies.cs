using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Drive.V3.Resources { 

	public class Replies : BaseClient {

		public Replies(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/drive/v3/",
		    		new string[] {"https://www.googleapis.com/auth/drive","https://www.googleapis.com/auth/drive.file","https://www.googleapis.com/auth/drive.readonly"}) {
		}

		/// <summary>
		/// Creates a new reply to a comment.
		/// </summary>
		/// <param name="commentId">The ID of the comment.</param>
		/// <param name="fileId">The ID of the file.</param>
		public Task<BaseResponse<Schema.Reply>> CreateAsync(string commentId, string fileId, Schema.Reply Reply, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(commentId)) { throw new ArgumentNullException(nameof(commentId)); }
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }

			return SendAsync(HttpMethod.Post, $"files/{fileId}/comments/{commentId}/replies", Reply, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Reply>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Deletes a reply.
		/// </summary>
		/// <param name="commentId">The ID of the comment.</param>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="replyId">The ID of the reply.</param>
		public Task<BaseResponse<object>> DeleteAsync(string commentId, string fileId, string replyId, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(commentId)) { throw new ArgumentNullException(nameof(commentId)); }
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }
			if (string.IsNullOrWhiteSpace(replyId)) { throw new ArgumentNullException(nameof(replyId)); }

			return SendAsync(HttpMethod.Delete, $"files/{fileId}/comments/{commentId}/replies/{replyId}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets a reply by ID.
		/// </summary>
		/// <param name="commentId">The ID of the comment.</param>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="replyId">The ID of the reply.</param>
		/// <param name="includeDeleted">Whether to return deleted replies. Deleted replies will not include their original content.</param>
		public Task<BaseResponse<Schema.Reply>> GetAsync(string commentId, string fileId, string replyId, bool? includeDeleted, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(commentId)) { throw new ArgumentNullException(nameof(commentId)); }
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }
			if (string.IsNullOrWhiteSpace(replyId)) { throw new ArgumentNullException(nameof(replyId)); }

			string queryString = GetQueryString(new {includeDeleted});

			return SendAsync(HttpMethod.Get, $"files/{fileId}/comments/{commentId}/replies/{replyId}?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Reply>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Lists a comment's replies.
		/// </summary>
		/// <param name="commentId">The ID of the comment.</param>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="includeDeleted">Whether to include deleted replies. Deleted replies will not include their original content.</param>
		/// <param name="pageSize">The maximum number of replies to return per page.</param>
		/// <param name="pageToken">The token for continuing a previous list request on the next page. This should be set to the value of 'nextPageToken' from the previous response.</param>
		public Task<BaseResponse<Schema.ReplyList>> ListAsync(string commentId, string fileId, bool? includeDeleted, int? pageSize, string pageToken, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(commentId)) { throw new ArgumentNullException(nameof(commentId)); }
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }

			string queryString = GetQueryString(new {includeDeleted, pageSize, pageToken});

			return SendAsync(HttpMethod.Get, $"files/{fileId}/comments/{commentId}/replies?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.ReplyList>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates a reply with patch semantics.
		/// </summary>
		/// <param name="commentId">The ID of the comment.</param>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="replyId">The ID of the reply.</param>
		public Task<BaseResponse<Schema.Reply>> UpdateAsync(string commentId, string fileId, string replyId, Schema.Reply Reply, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(commentId)) { throw new ArgumentNullException(nameof(commentId)); }
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }
			if (string.IsNullOrWhiteSpace(replyId)) { throw new ArgumentNullException(nameof(replyId)); }

			return SendAsync(HttpMethod.Post, $"files/{fileId}/comments/{commentId}/replies/{replyId}", Reply, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Reply>, cancellationToken)
				.Unwrap();
		}

	}

}