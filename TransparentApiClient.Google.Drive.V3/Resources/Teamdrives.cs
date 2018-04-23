using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Drive.V3.Resources { 

	public class Teamdrives : BaseClient {

		public Teamdrives(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/drive/v3/",
		    		new string[] {"https://www.googleapis.com/auth/drive","https://www.googleapis.com/auth/drive.readonly"}) {
		}

		/// <summary>
		/// Creates a new Team Drive.
		/// </summary>
		/// <param name="requestId">An ID, such as a random UUID, which uniquely identifies this user's request for idempotent creation of a Team Drive. A repeated request by the same user and with the same request ID will avoid creating duplicates by attempting to create the same Team Drive. If the Team Drive already exists a 409 error will be returned.</param>
		public Task<BaseResponse<Schema.TeamDrive>> CreateAsync(string requestId, Schema.TeamDrive TeamDrive, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(requestId)) { throw new ArgumentNullException(nameof(requestId)); }

			string queryString = GetQueryString(new {requestId});

			return SendAsync(HttpMethod.Post, $"teamdrives?{queryString}", TeamDrive, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.TeamDrive>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Permanently deletes a Team Drive for which the user is an organizer. The Team Drive cannot contain any untrashed items.
		/// </summary>
		/// <param name="teamDriveId">The ID of the Team Drive</param>
		public Task<BaseResponse<object>> DeleteAsync(string teamDriveId, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(teamDriveId)) { throw new ArgumentNullException(nameof(teamDriveId)); }

			return SendAsync(HttpMethod.Delete, $"teamdrives/{teamDriveId}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets a Team Drive's metadata by ID.
		/// </summary>
		/// <param name="teamDriveId">The ID of the Team Drive</param>
		/// <param name="useDomainAdminAccess">Whether the request should be treated as if it was issued by a domain administrator; if set to true, then the requester will be granted access if they are an administrator of the domain to which the Team Drive belongs.</param>
		public Task<BaseResponse<Schema.TeamDrive>> GetAsync(string teamDriveId, bool? useDomainAdminAccess, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(teamDriveId)) { throw new ArgumentNullException(nameof(teamDriveId)); }

			string queryString = GetQueryString(new {useDomainAdminAccess});

			return SendAsync(HttpMethod.Get, $"teamdrives/{teamDriveId}?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.TeamDrive>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Lists the user's Team Drives.
		/// </summary>
		/// <param name="pageSize">Maximum number of Team Drives to return.</param>
		/// <param name="pageToken">Page token for Team Drives.</param>
		/// <param name="q">Query string for searching Team Drives.</param>
		/// <param name="useDomainAdminAccess">Whether the request should be treated as if it was issued by a domain administrator; if set to true, then all Team Drives of the domain in which the requester is an administrator are returned.</param>
		public Task<BaseResponse<Schema.TeamDriveList>> ListAsync(int? pageSize, string pageToken, string q, bool? useDomainAdminAccess, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {

			string queryString = GetQueryString(new {pageSize, pageToken, q, useDomainAdminAccess});

			return SendAsync(HttpMethod.Get, $"teamdrives?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.TeamDriveList>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates a Team Drive's metadata
		/// </summary>
		/// <param name="teamDriveId">The ID of the Team Drive</param>
		public Task<BaseResponse<Schema.TeamDrive>> UpdateAsync(string teamDriveId, Schema.TeamDrive TeamDrive, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(teamDriveId)) { throw new ArgumentNullException(nameof(teamDriveId)); }

			return SendAsync(HttpMethod.Post, $"teamdrives/{teamDriveId}", TeamDrive, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.TeamDrive>, cancellationToken)
				.Unwrap();
		}

	}

}