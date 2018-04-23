using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Drive.V3.Resources { 

	public class Permissions : BaseClient {

		public Permissions(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/drive/v3/",
		    		new string[] {"https://www.googleapis.com/auth/drive","https://www.googleapis.com/auth/drive.file","https://www.googleapis.com/auth/drive.metadata","https://www.googleapis.com/auth/drive.metadata.readonly","https://www.googleapis.com/auth/drive.photos.readonly","https://www.googleapis.com/auth/drive.readonly"}) {
		}

		/// <summary>
		/// Creates a permission for a file or Team Drive.
		/// </summary>
		/// <param name="fileId">The ID of the file or Team Drive.</param>
		/// <param name="emailMessage">A plain text custom message to include in the notification email.</param>
		/// <param name="sendNotificationEmail">Whether to send a notification email when sharing to users or groups. This defaults to true for users and groups, and is not allowed for other requests. It must not be disabled for ownership transfers.</param>
		/// <param name="supportsTeamDrives">Whether the requesting application supports Team Drives.</param>
		/// <param name="transferOwnership">Whether to transfer ownership to the specified user and downgrade the current owner to a writer. This parameter is required as an acknowledgement of the side effect.</param>
		/// <param name="useDomainAdminAccess">Whether the request should be treated as if it was issued by a domain administrator; if set to true, then the requester will be granted access if they are an administrator of the domain to which the item belongs.</param>
		public Task<BaseResponse<Schema.Permission>> CreateAsync(string fileId, string emailMessage, bool? sendNotificationEmail, bool? supportsTeamDrives, bool? transferOwnership, bool? useDomainAdminAccess, Schema.Permission Permission, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }

			string queryString = GetQueryString(new {emailMessage, sendNotificationEmail, supportsTeamDrives, transferOwnership, useDomainAdminAccess});

			return SendAsync(HttpMethod.Post, $"files/{fileId}/permissions?{queryString}", Permission, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Permission>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Deletes a permission.
		/// </summary>
		/// <param name="fileId">The ID of the file or Team Drive.</param>
		/// <param name="permissionId">The ID of the permission.</param>
		/// <param name="supportsTeamDrives">Whether the requesting application supports Team Drives.</param>
		/// <param name="useDomainAdminAccess">Whether the request should be treated as if it was issued by a domain administrator; if set to true, then the requester will be granted access if they are an administrator of the domain to which the item belongs.</param>
		public Task<BaseResponse<object>> DeleteAsync(string fileId, string permissionId, bool? supportsTeamDrives, bool? useDomainAdminAccess, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }
			if (string.IsNullOrWhiteSpace(permissionId)) { throw new ArgumentNullException(nameof(permissionId)); }

			string queryString = GetQueryString(new {supportsTeamDrives, useDomainAdminAccess});

			return SendAsync(HttpMethod.Delete, $"files/{fileId}/permissions/{permissionId}?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets a permission by ID.
		/// </summary>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="permissionId">The ID of the permission.</param>
		/// <param name="supportsTeamDrives">Whether the requesting application supports Team Drives.</param>
		/// <param name="useDomainAdminAccess">Whether the request should be treated as if it was issued by a domain administrator; if set to true, then the requester will be granted access if they are an administrator of the domain to which the item belongs.</param>
		public Task<BaseResponse<Schema.Permission>> GetAsync(string fileId, string permissionId, bool? supportsTeamDrives, bool? useDomainAdminAccess, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }
			if (string.IsNullOrWhiteSpace(permissionId)) { throw new ArgumentNullException(nameof(permissionId)); }

			string queryString = GetQueryString(new {supportsTeamDrives, useDomainAdminAccess});

			return SendAsync(HttpMethod.Get, $"files/{fileId}/permissions/{permissionId}?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Permission>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Lists a file's or Team Drive's permissions.
		/// </summary>
		/// <param name="fileId">The ID of the file or Team Drive.</param>
		/// <param name="pageSize">The maximum number of permissions to return per page. When not set for files in a Team Drive, at most 100 results will be returned. When not set for files that are not in a Team Drive, the entire list will be returned.</param>
		/// <param name="pageToken">The token for continuing a previous list request on the next page. This should be set to the value of 'nextPageToken' from the previous response.</param>
		/// <param name="supportsTeamDrives">Whether the requesting application supports Team Drives.</param>
		/// <param name="useDomainAdminAccess">Whether the request should be treated as if it was issued by a domain administrator; if set to true, then the requester will be granted access if they are an administrator of the domain to which the item belongs.</param>
		public Task<BaseResponse<Schema.PermissionList>> ListAsync(string fileId, int? pageSize, string pageToken, bool? supportsTeamDrives, bool? useDomainAdminAccess, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }

			string queryString = GetQueryString(new {pageSize, pageToken, supportsTeamDrives, useDomainAdminAccess});

			return SendAsync(HttpMethod.Get, $"files/{fileId}/permissions?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.PermissionList>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates a permission with patch semantics.
		/// </summary>
		/// <param name="fileId">The ID of the file or Team Drive.</param>
		/// <param name="permissionId">The ID of the permission.</param>
		/// <param name="removeExpiration">Whether to remove the expiration date.</param>
		/// <param name="supportsTeamDrives">Whether the requesting application supports Team Drives.</param>
		/// <param name="transferOwnership">Whether to transfer ownership to the specified user and downgrade the current owner to a writer. This parameter is required as an acknowledgement of the side effect.</param>
		/// <param name="useDomainAdminAccess">Whether the request should be treated as if it was issued by a domain administrator; if set to true, then the requester will be granted access if they are an administrator of the domain to which the item belongs.</param>
		public Task<BaseResponse<Schema.Permission>> UpdateAsync(string fileId, string permissionId, bool? removeExpiration, bool? supportsTeamDrives, bool? transferOwnership, bool? useDomainAdminAccess, Schema.Permission Permission, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }
			if (string.IsNullOrWhiteSpace(permissionId)) { throw new ArgumentNullException(nameof(permissionId)); }

			string queryString = GetQueryString(new {removeExpiration, supportsTeamDrives, transferOwnership, useDomainAdminAccess});

			return SendAsync(HttpMethod.Post, $"files/{fileId}/permissions/{permissionId}?{queryString}", Permission, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Permission>, cancellationToken)
				.Unwrap();
		}

	}

}