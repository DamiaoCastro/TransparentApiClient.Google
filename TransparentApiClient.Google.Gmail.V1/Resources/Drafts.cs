using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Gmail.V1.Resources { 

	public class Drafts : BaseClient {

		public Drafts(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/gmail/v1/users/",
		    		new string[] {"https://mail.google.com/","https://www.googleapis.com/auth/gmail.compose","https://www.googleapis.com/auth/gmail.modify","https://www.googleapis.com/auth/gmail.readonly"}) {
		}

		/// <summary>
		/// Creates a new draft with the DRAFT label.
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.Draft>> CreateAsync(string userId, Schema.Draft Draft, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Post, $"{userId}/drafts", Draft, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Draft>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Immediately and permanently deletes the specified draft. Does not simply trash it.
		/// </summary>
		/// <param name="id">The ID of the draft to delete.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<object>> DeleteAsync(string id, string userId, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Delete, $"{userId}/drafts/{id}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets the specified draft.
		/// </summary>
		/// <param name="id">The ID of the draft to retrieve.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		/// <param name="format">The format to return the draft in.</param>
		public Task<BaseResponse<Schema.Draft>> GetAsync(string id, string userId, string format, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			string queryString = GetQueryString(new {format});

			return SendAsync(HttpMethod.Get, $"{userId}/drafts/{id}?{queryString}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Draft>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Lists the drafts in the user's mailbox.
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		/// <param name="includeSpamTrash">Include drafts from SPAM and TRASH in the results.</param>
		/// <param name="maxResults">Maximum number of drafts to return.</param>
		/// <param name="pageToken">Page token to retrieve a specific page of results in the list.</param>
		/// <param name="q">Only return draft messages matching the specified query. Supports the same query format as the Gmail search box. For example, "from:someuser@example.com rfc822msgid: is:unread".</param>
		public Task<BaseResponse<Schema.ListDraftsResponse>> ListAsync(string userId, bool? includeSpamTrash, int? maxResults, string pageToken, string q, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			string queryString = GetQueryString(new {includeSpamTrash, maxResults, pageToken, q});

			return SendAsync(HttpMethod.Get, $"{userId}/drafts?{queryString}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.ListDraftsResponse>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Sends the specified, existing draft to the recipients in the To, Cc, and Bcc headers.
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.Message>> SendAsync(string userId, Schema.Draft Draft, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Post, $"{userId}/drafts/send", Draft, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Message>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Replaces a draft's content.
		/// </summary>
		/// <param name="id">The ID of the draft to update.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.Draft>> UpdateAsync(string id, string userId, Schema.Draft Draft, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Put, $"{userId}/drafts/{id}", Draft, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Draft>, cancellationToken)
				.Unwrap();
		}

	}

}