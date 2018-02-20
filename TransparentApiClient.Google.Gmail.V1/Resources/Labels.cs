using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Gmail.V1.Resources { 

	public class Labels : BaseClient {

		public Labels(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/gmail/v1/users/",
		    		new string[] {"https://mail.google.com/","https://www.googleapis.com/auth/gmail.labels","https://www.googleapis.com/auth/gmail.modify","https://www.googleapis.com/auth/gmail.metadata","https://www.googleapis.com/auth/gmail.readonly"}) {
		}

		/// <summary>
		/// Creates a new label.
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.Label>> CreateAsync(string userId, Schema.Label Label, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Post, $"{userId}/labels", Label, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Label>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Immediately and permanently deletes the specified label and removes it from any messages and threads that it is applied to.
		/// </summary>
		/// <param name="id">The ID of the label to delete.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<object>> DeleteAsync(string id, string userId, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Delete, $"{userId}/labels/{id}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets the specified label.
		/// </summary>
		/// <param name="id">The ID of the label to retrieve.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.Label>> GetAsync(string id, string userId, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Get, $"{userId}/labels/{id}", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Label>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Lists all labels in the user's mailbox.
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.ListLabelsResponse>> ListAsync(string userId, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Get, $"{userId}/labels", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.ListLabelsResponse>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates the specified label. This method supports patch semantics.
		/// </summary>
		/// <param name="id">The ID of the label to update.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.Label>> PatchAsync(string id, string userId, Schema.Label Label, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Post, $"{userId}/labels/{id}", Label, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Label>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates the specified label.
		/// </summary>
		/// <param name="id">The ID of the label to update.</param>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.Label>> UpdateAsync(string id, string userId, Schema.Label Label, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(id)) { throw new ArgumentNullException(nameof(id)); }
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Put, $"{userId}/labels/{id}", Label, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Label>, cancellationToken)
				.Unwrap();
		}

	}

}