using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Gmail.V1.Resources { 

	public class Messages : BaseClient {

		public Messages(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/gmail/v1/users/",
		    		new string[] {"https://mail.google.com/","https://www.googleapis.com/auth/gmail.modify","https://www.googleapis.com/auth/gmail.metadata","https://www.googleapis.com/auth/gmail.readonly","https://www.googleapis.com/auth/gmail.insert","https://www.googleapis.com/auth/gmail.compose","https://www.googleapis.com/auth/gmail.send"}) {
		}

		/// <summary>
		/// Deletes many messages by message ID. Provides no guarantees that messages were not already deleted or even existed at all.
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<object>> BatchDeleteAsync(string userId, Schema.BatchDeleteMessagesRequest BatchDeleteMessagesRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Post, $"{userId}/messages/batchDelete", BatchDeleteMessagesRequest, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Modifies the labels on the specified messages.
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<object>> BatchModifyAsync(string userId, Schema.BatchModifyMessagesRequest BatchModifyMessagesRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Post, $"{userId}/messages/batchModify", BatchModifyMessagesRequest, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Immediately and permanently deletes the specified message. This operation cannot be undone. Prefer messages.trash instead.
		/// </summary>
		/// <param name="id">The ID of the message to delete.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<object>> DeleteAsync(string id, string userId, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Delete, $"{userId}/messages/{id}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets the specified message.
		/// </summary>
		/// <param name="id">The ID of the message to retrieve.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		/// <param name="format">The format to return the message in.</param>
		/// <param name="metadataHeaders">When given and format is METADATA, only include headers specified.</param>
		public Task<BaseResponse<Schema.Message>> GetAsync(string id, string userId, string format, string metadataHeaders, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			string queryString = GetQueryString(new {format, metadataHeaders});

			return SendAsync(HttpMethod.Get, $"{userId}/messages/{id}?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Message>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Imports a message into only this user's mailbox, with standard email delivery scanning and classification similar to receiving via SMTP. Does not send a message.
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		/// <param name="deleted">Mark the email as permanently deleted (not TRASH) and only visible in Google Vault to a Vault administrator. Only used for G Suite accounts.</param>
		/// <param name="internalDateSource">Source for Gmail's internal date of the message.</param>
		/// <param name="neverMarkSpam">Ignore the Gmail spam classifier decision and never mark this email as SPAM in the mailbox.</param>
		/// <param name="processForCalendar">Process calendar invites in the email and add any extracted meetings to the Google Calendar for this user.</param>
		public Task<BaseResponse<Schema.Message>> ImportAsync(string userId, bool? deleted, string internalDateSource, bool? neverMarkSpam, bool? processForCalendar, Schema.Message Message, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			string queryString = GetQueryString(new {deleted, internalDateSource, neverMarkSpam, processForCalendar});

			return SendAsync(HttpMethod.Post, $"{userId}/messages/import?{queryString}", Message, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Message>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Directly inserts a message into only this user's mailbox similar to IMAP APPEND, bypassing most scanning and classification. Does not send a message.
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		/// <param name="deleted">Mark the email as permanently deleted (not TRASH) and only visible in Google Vault to a Vault administrator. Only used for G Suite accounts.</param>
		/// <param name="internalDateSource">Source for Gmail's internal date of the message.</param>
		public Task<BaseResponse<Schema.Message>> InsertAsync(string userId, bool? deleted, string internalDateSource, Schema.Message Message, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			string queryString = GetQueryString(new {deleted, internalDateSource});

			return SendAsync(HttpMethod.Post, $"{userId}/messages?{queryString}", Message, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Message>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Lists the messages in the user's mailbox.
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		/// <param name="includeSpamTrash">Include messages from SPAM and TRASH in the results.</param>
		/// <param name="labelIds">Only return messages with labels that match all of the specified label IDs.</param>
		/// <param name="maxResults">Maximum number of messages to return.</param>
		/// <param name="pageToken">Page token to retrieve a specific page of results in the list.</param>
		/// <param name="q">Only return messages matching the specified query. Supports the same query format as the Gmail search box. For example, "from:someuser@example.com rfc822msgid:<somemsgid@example.com> is:unread". Parameter cannot be used when accessing the api using the gmail.metadata scope.</param>
		public Task<BaseResponse<Schema.ListMessagesResponse>> ListAsync(string userId, bool? includeSpamTrash, string labelIds, int? maxResults, string pageToken, string q, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			string queryString = GetQueryString(new {includeSpamTrash, labelIds, maxResults, pageToken, q});

			return SendAsync(HttpMethod.Get, $"{userId}/messages?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.ListMessagesResponse>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Modifies the labels on the specified message.
		/// </summary>
		/// <param name="id">The ID of the message to modify.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.Message>> ModifyAsync(string id, string userId, Schema.ModifyMessageRequest ModifyMessageRequest, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Post, $"{userId}/messages/{id}/modify", ModifyMessageRequest, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Message>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Sends the specified message to the recipients in the To, Cc, and Bcc headers.
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.Message>> SendAsync(string userId, Schema.Message Message, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Post, $"{userId}/messages/send", Message, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Message>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Moves the specified message to the trash.
		/// </summary>
		/// <param name="id">The ID of the message to Trash.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.Message>> TrashAsync(string id, string userId, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Post, $"{userId}/messages/{id}/trash", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Message>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Removes the specified message from the trash.
		/// </summary>
		/// <param name="id">The ID of the message to remove from Trash.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.Message>> UntrashAsync(string id, string userId, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Post, $"{userId}/messages/{id}/untrash", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Message>, cancellationToken)
				.Unwrap();
		}

	}

}