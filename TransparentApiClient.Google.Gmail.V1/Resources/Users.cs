using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Gmail.V1.Resources { 

	public class Users : BaseClient {

		public Users(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/gmail/v1/users/",
		    		new string[] {"https://mail.google.com/","https://www.googleapis.com/auth/gmail.compose","https://www.googleapis.com/auth/gmail.metadata","https://www.googleapis.com/auth/gmail.modify","https://www.googleapis.com/auth/gmail.readonly"}) {
		}

		/// <summary>
		/// Gets the current user's Gmail profile.
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.Profile>> GetProfileAsync(string userId, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Get, $"{userId}/profile", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Profile>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Stop receiving push notifications for the given user mailbox.
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<object>> StopAsync(string userId, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Post, $"{userId}/stop", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Set up or update a push notification watch on the given user mailbox.
		/// </summary>
		/// <param name="userId">The user's email address. The special value me can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.WatchResponse>> WatchAsync(string userId, Schema.WatchRequest WatchRequest, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Post, $"{userId}/watch", WatchRequest, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.WatchResponse>, cancellationToken)
				.Unwrap();
		}

	}

}