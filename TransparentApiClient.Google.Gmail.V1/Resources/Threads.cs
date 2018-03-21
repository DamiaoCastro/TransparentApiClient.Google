using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Gmail.V1.Resources { 

	public class Threads : BaseClient {

		public Threads(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/gmail/v1/users/",
		    		new string[] {"https://mail.google.com/","https://www.googleapis.com/auth/gmail.metadata","https://www.googleapis.com/auth/gmail.modify","https://www.googleapis.com/auth/gmail.readonly"}) {
		}

		/// <summary>
		/// Immediately and permanently deletes the specified thread. This operation cannot be undone. Prefer threads.trash instead.
		/// </summary>
		/// <param name="id">ID of the Thread to delete.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<object>> DeleteAsync(string id, string userId, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Delete, $"{userId}/threads/{id}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets the specified thread.
		/// </summary>
		/// <param name="id">The ID of the thread to retrieve.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		/// <param name="format">The format to return the messages in.</param>
		/// <param name="metadataHeaders">When given and format is METADATA, only include headers specified.</param>
		public Task<BaseResponse<Schema.Thread>> GetAsync(string id, string userId, string format, string metadataHeaders, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			string queryString = GetQueryString(new {format, metadataHeaders});

			return SendAsync(HttpMethod.Get, $"{userId}/threads/{id}?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Thread>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Lists the threads in the user's mailbox.
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		/// <param name="includeSpamTrash">Include threads from SPAM and TRASH in the results.</param>
		/// <param name="labelIds">Only return threads with labels that match all of the specified label IDs.</param>
		/// <param name="maxResults">Maximum number of threads to return.</param>
		/// <param name="pageToken">Page token to retrieve a specific page of results in the list.</param>
		/// <param name="q">Only return threads matching the specified query. Supports the same query format as the Gmail search box. For example, "from:someuser@example.com rfc822msgid: is:unread". Parameter cannot be used when accessing the api using the gmail.metadata scope.</param>
		public Task<BaseResponse<Schema.ListThreadsResponse>> ListAsync(string userId, bool? includeSpamTrash, string labelIds, int? maxResults, string pageToken, string q, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			string queryString = GetQueryString(new {includeSpamTrash, labelIds, maxResults, pageToken, q});

			return SendAsync(HttpMethod.Get, $"{userId}/threads?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.ListThreadsResponse>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Modifies the labels applied to the thread. This applies to all messages in the thread.
		/// </summary>
		/// <param name="id">The ID of the thread to modify.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.Thread>> ModifyAsync(string id, string userId, Schema.ModifyThreadRequest ModifyThreadRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Post, $"{userId}/threads/{id}/modify", ModifyThreadRequest, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Thread>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Moves the specified thread to the trash.
		/// </summary>
		/// <param name="id">The ID of the thread to Trash.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.Thread>> TrashAsync(string id, string userId, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Post, $"{userId}/threads/{id}/trash", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Thread>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Removes the specified thread from the trash.
		/// </summary>
		/// <param name="id">The ID of the thread to remove from Trash.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.Thread>> UntrashAsync(string id, string userId, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Post, $"{userId}/threads/{id}/untrash", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Thread>, cancellationToken)
				.Unwrap();
		}

	}

}