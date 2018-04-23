using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Drive.V3.Resources { 

	public class Changes : BaseClient {

		public Changes(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/drive/v3/",
		    		new string[] {"https://www.googleapis.com/auth/drive","https://www.googleapis.com/auth/drive.appdata","https://www.googleapis.com/auth/drive.file","https://www.googleapis.com/auth/drive.metadata","https://www.googleapis.com/auth/drive.metadata.readonly","https://www.googleapis.com/auth/drive.photos.readonly","https://www.googleapis.com/auth/drive.readonly"}) {
		}

		/// <summary>
		/// Gets the starting pageToken for listing future changes.
		/// </summary>
		/// <param name="supportsTeamDrives">Whether the requesting application supports Team Drives.</param>
		/// <param name="teamDriveId">The ID of the Team Drive for which the starting pageToken for listing future changes from that Team Drive will be returned.</param>
		public Task<BaseResponse<Schema.StartPageToken>> GetStartPageTokenAsync(bool? supportsTeamDrives, string teamDriveId, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {

			string queryString = GetQueryString(new {supportsTeamDrives, teamDriveId});

			return SendAsync(HttpMethod.Get, $"changes/startPageToken?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.StartPageToken>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Lists the changes for a user or Team Drive.
		/// </summary>
		/// <param name="includeCorpusRemovals">Whether changes should include the file resource if the file is still accessible by the user at the time of the request, even when a file was removed from the list of changes and there will be no further change entries for this file.</param>
		/// <param name="includeRemoved">Whether to include changes indicating that items have been removed from the list of changes, for example by deletion or loss of access.</param>
		/// <param name="includeTeamDriveItems">Whether Team Drive files or changes should be included in results.</param>
		/// <param name="pageSize">The maximum number of changes to return per page.</param>
		/// <param name="pageToken">The token for continuing a previous list request on the next page. This should be set to the value of 'nextPageToken' from the previous response or to the response from the getStartPageToken method.</param>
		/// <param name="restrictToMyDrive">Whether to restrict the results to changes inside the My Drive hierarchy. This omits changes to files such as those in the Application Data folder or shared files which have not been added to My Drive.</param>
		/// <param name="spaces">A comma-separated list of spaces to query within the user corpus. Supported values are 'drive', 'appDataFolder' and 'photos'.</param>
		/// <param name="supportsTeamDrives">Whether the requesting application supports Team Drives.</param>
		/// <param name="teamDriveId">The Team Drive from which changes will be returned. If specified the change IDs will be reflective of the Team Drive; use the combined Team Drive ID and change ID as an identifier.</param>
		public Task<BaseResponse<Schema.ChangeList>> ListAsync(bool? includeCorpusRemovals, bool? includeRemoved, bool? includeTeamDriveItems, int? pageSize, string pageToken, bool? restrictToMyDrive, string spaces, bool? supportsTeamDrives, string teamDriveId, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(pageToken)) { throw new ArgumentNullException(nameof(pageToken)); }

			string queryString = GetQueryString(new {includeCorpusRemovals, includeRemoved, includeTeamDriveItems, pageSize, pageToken, restrictToMyDrive, spaces, supportsTeamDrives, teamDriveId});

			return SendAsync(HttpMethod.Get, $"changes?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.ChangeList>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Subscribes to changes for a user.
		/// </summary>
		/// <param name="includeCorpusRemovals">Whether changes should include the file resource if the file is still accessible by the user at the time of the request, even when a file was removed from the list of changes and there will be no further change entries for this file.</param>
		/// <param name="includeRemoved">Whether to include changes indicating that items have been removed from the list of changes, for example by deletion or loss of access.</param>
		/// <param name="includeTeamDriveItems">Whether Team Drive files or changes should be included in results.</param>
		/// <param name="pageSize">The maximum number of changes to return per page.</param>
		/// <param name="pageToken">The token for continuing a previous list request on the next page. This should be set to the value of 'nextPageToken' from the previous response or to the response from the getStartPageToken method.</param>
		/// <param name="restrictToMyDrive">Whether to restrict the results to changes inside the My Drive hierarchy. This omits changes to files such as those in the Application Data folder or shared files which have not been added to My Drive.</param>
		/// <param name="spaces">A comma-separated list of spaces to query within the user corpus. Supported values are 'drive', 'appDataFolder' and 'photos'.</param>
		/// <param name="supportsTeamDrives">Whether the requesting application supports Team Drives.</param>
		/// <param name="teamDriveId">The Team Drive from which changes will be returned. If specified the change IDs will be reflective of the Team Drive; use the combined Team Drive ID and change ID as an identifier.</param>
		public Task<BaseResponse<Schema.Channel>> WatchAsync(bool? includeCorpusRemovals, bool? includeRemoved, bool? includeTeamDriveItems, int? pageSize, string pageToken, bool? restrictToMyDrive, string spaces, bool? supportsTeamDrives, string teamDriveId, Schema.Channel Channel, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(pageToken)) { throw new ArgumentNullException(nameof(pageToken)); }

			string queryString = GetQueryString(new {includeCorpusRemovals, includeRemoved, includeTeamDriveItems, pageSize, pageToken, restrictToMyDrive, spaces, supportsTeamDrives, teamDriveId});

			return SendAsync(HttpMethod.Post, $"changes/watch?{queryString}", Channel, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Channel>, cancellationToken)
				.Unwrap();
		}

	}

}