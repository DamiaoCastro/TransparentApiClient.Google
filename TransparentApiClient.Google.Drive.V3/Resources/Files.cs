using System;
using System.Threading;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransparentApiClient.Google.Core;

namespace TransparentApiClient.Google.Drive.V3.Resources { 

	public class Files : BaseClient {

		public Files(byte[] serviceAccountCredentials)
		    : base(serviceAccountCredentials, "https://www.googleapis.com/drive/v3/",
		    		new string[] {"https://www.googleapis.com/auth/drive","https://www.googleapis.com/auth/drive.appdata","https://www.googleapis.com/auth/drive.file","https://www.googleapis.com/auth/drive.photos.readonly","https://www.googleapis.com/auth/drive.readonly","https://www.googleapis.com/auth/drive.metadata","https://www.googleapis.com/auth/drive.metadata.readonly","https://www.googleapis.com/auth/drive.scripts"}) {
		}

		/// <summary>
		/// Creates a copy of a file and applies any requested updates with patch semantics.
		/// </summary>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="ignoreDefaultVisibility">Whether to ignore the domain's default visibility settings for the created file. Domain administrators can choose to make all uploaded files visible to the domain by default; this parameter bypasses that behavior for the request. Permissions are still inherited from parent folders.</param>
		/// <param name="keepRevisionForever">Whether to set the 'keepForever' field in the new head revision. This is only applicable to files with binary content in Drive.</param>
		/// <param name="ocrLanguage">A language hint for OCR processing during image import (ISO 639-1 code).</param>
		/// <param name="supportsTeamDrives">Whether the requesting application supports Team Drives.</param>
		public Task<BaseResponse<Schema.File>> CopyAsync(string fileId, bool? ignoreDefaultVisibility, bool? keepRevisionForever, string ocrLanguage, bool? supportsTeamDrives, Schema.File File, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }

			string queryString = GetQueryString(new {ignoreDefaultVisibility, keepRevisionForever, ocrLanguage, supportsTeamDrives});

			return SendAsync(HttpMethod.Post, $"files/{fileId}/copy?{queryString}", File, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.File>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Creates a new file.
		/// </summary>
		/// <param name="ignoreDefaultVisibility">Whether to ignore the domain's default visibility settings for the created file. Domain administrators can choose to make all uploaded files visible to the domain by default; this parameter bypasses that behavior for the request. Permissions are still inherited from parent folders.</param>
		/// <param name="keepRevisionForever">Whether to set the 'keepForever' field in the new head revision. This is only applicable to files with binary content in Drive.</param>
		/// <param name="ocrLanguage">A language hint for OCR processing during image import (ISO 639-1 code).</param>
		/// <param name="supportsTeamDrives">Whether the requesting application supports Team Drives.</param>
		/// <param name="useContentAsIndexableText">Whether to use the uploaded content as indexable text.</param>
		public Task<BaseResponse<Schema.File>> CreateAsync(bool? ignoreDefaultVisibility, bool? keepRevisionForever, string ocrLanguage, bool? supportsTeamDrives, bool? useContentAsIndexableText, Schema.File File, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {

			string queryString = GetQueryString(new {ignoreDefaultVisibility, keepRevisionForever, ocrLanguage, supportsTeamDrives, useContentAsIndexableText});

			return SendAsync(HttpMethod.Post, $"files?{queryString}", File, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.File>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Permanently deletes a file owned by the user without moving it to the trash. If the file belongs to a Team Drive the user must be an organizer on the parent. If the target is a folder, all descendants owned by the user are also deleted.
		/// </summary>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="supportsTeamDrives">Whether the requesting application supports Team Drives.</param>
		public Task<BaseResponse<object>> DeleteAsync(string fileId, bool? supportsTeamDrives, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }

			string queryString = GetQueryString(new {supportsTeamDrives});

			return SendAsync(HttpMethod.Delete, $"files/{fileId}?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Permanently deletes all of the user's trashed files.
		/// </summary>
		public Task<BaseResponse<object>> EmptyTrashAsync(JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {

			return SendAsync(HttpMethod.Delete, $"files/trash", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Exports a Google Doc to the requested MIME type and returns the exported content. Please note that the exported content is limited to 10MB.
		/// </summary>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="mimeType">The MIME type of the format requested for this export.</param>
		public Task<BaseResponse<object>> ExportAsync(string fileId, string mimeType, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }
			if (string.IsNullOrWhiteSpace(mimeType)) { throw new ArgumentNullException(nameof(mimeType)); }

			string queryString = GetQueryString(new {mimeType});

			return SendAsync(HttpMethod.Get, $"files/{fileId}/export?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<object>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Generates a set of file IDs which can be provided in create requests.
		/// </summary>
		/// <param name="count">The number of IDs to return.</param>
		/// <param name="space">The space in which the IDs can be used to create new files. Supported values are 'drive' and 'appDataFolder'.</param>
		public Task<BaseResponse<Schema.GeneratedIds>> GenerateIdsAsync(int? count, string space, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {

			string queryString = GetQueryString(new {count, space});

			return SendAsync(HttpMethod.Get, $"files/generateIds?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.GeneratedIds>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Gets a file's metadata or content by ID.
		/// </summary>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="acknowledgeAbuse">Whether the user is acknowledging the risk of downloading known malware or other abusive files. This is only applicable when alt=media.</param>
		/// <param name="supportsTeamDrives">Whether the requesting application supports Team Drives.</param>
		public Task<BaseResponse<Schema.File>> GetAsync(string fileId, bool? acknowledgeAbuse, bool? supportsTeamDrives, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }

			string queryString = GetQueryString(new {acknowledgeAbuse, supportsTeamDrives});

			return SendAsync(HttpMethod.Get, $"files/{fileId}?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.File>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Lists or searches files.
		/// </summary>
		/// <param name="corpora">Comma-separated list of bodies of items (files/documents) to which the query applies. Supported bodies are 'user', 'domain', 'teamDrive' and 'allTeamDrives'. 'allTeamDrives' must be combined with 'user'; all other values must be used in isolation. Prefer 'user' or 'teamDrive' to 'allTeamDrives' for efficiency.</param>
		/// <param name="corpus">The source of files to list. Deprecated: use 'corpora' instead.</param>
		/// <param name="includeTeamDriveItems">Whether Team Drive items should be included in results.</param>
		/// <param name="orderBy">A comma-separated list of sort keys. Valid keys are 'createdTime', 'folder', 'modifiedByMeTime', 'modifiedTime', 'name', 'name_natural', 'quotaBytesUsed', 'recency', 'sharedWithMeTime', 'starred', and 'viewedByMeTime'. Each key sorts ascending by default, but may be reversed with the 'desc' modifier. Example usage: ?orderBy=folder,modifiedTime desc,name. Please note that there is a current limitation for users with approximately one million files in which the requested sort order is ignored.</param>
		/// <param name="pageSize">The maximum number of files to return per page. Partial or empty result pages are possible even before the end of the files list has been reached.</param>
		/// <param name="pageToken">The token for continuing a previous list request on the next page. This should be set to the value of 'nextPageToken' from the previous response.</param>
		/// <param name="q">A query for filtering the file results. See the "Search for Files" guide for supported syntax.</param>
		/// <param name="spaces">A comma-separated list of spaces to query within the corpus. Supported values are 'drive', 'appDataFolder' and 'photos'.</param>
		/// <param name="supportsTeamDrives">Whether the requesting application supports Team Drives.</param>
		/// <param name="teamDriveId">ID of Team Drive to search.</param>
		public Task<BaseResponse<Schema.FileList>> ListAsync(string corpora, string corpus, bool? includeTeamDriveItems, string orderBy, int? pageSize, string pageToken, string q, string spaces, bool? supportsTeamDrives, string teamDriveId, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {

			string queryString = GetQueryString(new {corpora, corpus, includeTeamDriveItems, orderBy, pageSize, pageToken, q, spaces, supportsTeamDrives, teamDriveId});

			return SendAsync(HttpMethod.Get, $"files?{queryString}", null, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.FileList>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Updates a file's metadata and/or content with patch semantics.
		/// </summary>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="addParents">A comma-separated list of parent IDs to add.</param>
		/// <param name="keepRevisionForever">Whether to set the 'keepForever' field in the new head revision. This is only applicable to files with binary content in Drive.</param>
		/// <param name="ocrLanguage">A language hint for OCR processing during image import (ISO 639-1 code).</param>
		/// <param name="removeParents">A comma-separated list of parent IDs to remove.</param>
		/// <param name="supportsTeamDrives">Whether the requesting application supports Team Drives.</param>
		/// <param name="useContentAsIndexableText">Whether to use the uploaded content as indexable text.</param>
		public Task<BaseResponse<Schema.File>> UpdateAsync(string fileId, string addParents, bool? keepRevisionForever, string ocrLanguage, string removeParents, bool? supportsTeamDrives, bool? useContentAsIndexableText, Schema.File File, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }

			string queryString = GetQueryString(new {addParents, keepRevisionForever, ocrLanguage, removeParents, supportsTeamDrives, useContentAsIndexableText});

			return SendAsync(HttpMethod.Post, $"files/{fileId}?{queryString}", File, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.File>, cancellationToken)
				.Unwrap();
		}

		/// <summary>
		/// Subscribes to changes to a file
		/// </summary>
		/// <param name="fileId">The ID of the file.</param>
		/// <param name="acknowledgeAbuse">Whether the user is acknowledging the risk of downloading known malware or other abusive files. This is only applicable when alt=media.</param>
		/// <param name="supportsTeamDrives">Whether the requesting application supports Team Drives.</param>
		public Task<BaseResponse<Schema.Channel>> WatchAsync(string fileId, bool? acknowledgeAbuse, bool? supportsTeamDrives, Schema.Channel Channel, JsonSerializerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken)) {
			if (string.IsNullOrWhiteSpace(fileId)) { throw new ArgumentNullException(nameof(fileId)); }

			string queryString = GetQueryString(new {acknowledgeAbuse, supportsTeamDrives});

			return SendAsync(HttpMethod.Post, $"files/{fileId}/watch?{queryString}", Channel, settings, cancellationToken)
				.ContinueWith(HandleBaseResponse<Schema.Channel>, cancellationToken)
				.Unwrap();
		}

	}

}