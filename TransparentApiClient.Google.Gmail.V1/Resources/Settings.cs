using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Gmail.V1.Resources { 

	public class Settings : BaseClient {

		public Settings(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/gmail/v1/users/",
		    		new string[] {"https://mail.google.com/","https://www.googleapis.com/auth/gmail.modify","https://www.googleapis.com/auth/gmail.readonly","https://www.googleapis.com/auth/gmail.settings.basic","https://www.googleapis.com/auth/gmail.settings.sharing"}) {
		}

		/// <summary>
		/// Gets the auto-forwarding setting for the specified account.
		/// </summary>
		/// <param name="userId">User's email address. The special value "me" can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.AutoForwarding>> GetAutoForwardingAsync(string userId, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Get, $"{userId}/settings/autoForwarding", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.AutoForwarding>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets IMAP settings.
		/// </summary>
		/// <param name="userId">User's email address. The special value "me" can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.ImapSettings>> GetImapAsync(string userId, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Get, $"{userId}/settings/imap", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.ImapSettings>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets POP settings.
		/// </summary>
		/// <param name="userId">User's email address. The special value "me" can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.PopSettings>> GetPopAsync(string userId, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Get, $"{userId}/settings/pop", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.PopSettings>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets vacation responder settings.
		/// </summary>
		/// <param name="userId">User's email address. The special value "me" can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.VacationSettings>> GetVacationAsync(string userId, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Get, $"{userId}/settings/vacation", null, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.VacationSettings>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates the auto-forwarding setting for the specified account. A verified forwarding address must be specified when auto-forwarding is enabled.

This method is only available to service account clients that have been delegated domain-wide authority.
		/// </summary>
		/// <param name="userId">User's email address. The special value "me" can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.AutoForwarding>> UpdateAutoForwardingAsync(string userId, Schema.AutoForwarding AutoForwarding, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Put, $"{userId}/settings/autoForwarding", AutoForwarding, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.AutoForwarding>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates IMAP settings.
		/// </summary>
		/// <param name="userId">User's email address. The special value "me" can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.ImapSettings>> UpdateImapAsync(string userId, Schema.ImapSettings ImapSettings, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Put, $"{userId}/settings/imap", ImapSettings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.ImapSettings>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates POP settings.
		/// </summary>
		/// <param name="userId">User's email address. The special value "me" can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.PopSettings>> UpdatePopAsync(string userId, Schema.PopSettings PopSettings, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Put, $"{userId}/settings/pop", PopSettings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.PopSettings>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates vacation responder settings.
		/// </summary>
		/// <param name="userId">User's email address. The special value "me" can be used to indicate the authenticated user.</param>
		public Task<BaseResponse<Schema.VacationSettings>> UpdateVacationAsync(string userId, Schema.VacationSettings VacationSettings, CancellationToken cancellationToken) {
			if (string.IsNullOrWhiteSpace(userId)) { throw new ArgumentNullException(nameof(userId)); }

			return SendAsync(HttpMethod.Put, $"{userId}/settings/vacation", VacationSettings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.VacationSettings>, cancellationToken)
				.Unwrap();
		}

	}

}