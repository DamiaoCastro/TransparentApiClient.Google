using System.Collections.Generic;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class File { 

		/// <summary>
		/// A collection of arbitrary key-value pairs which are private to the requesting app.
		///Entries with null values are cleared in update and copy requests.
		/// </summary>
		public object appProperties { get; set; }

		/// <summary>
		/// Capabilities the current user has on this file. Each capability corresponds to a fine-grained action that a user may take.
		/// </summary>
		public object capabilities { get; set; }

		/// <summary>
		/// Additional information about the content of the file. These fields are never populated in responses.
		/// </summary>
		public object contentHints { get; set; }

		/// <summary>
		/// The time at which the file was created (RFC 3339 date-time).
		/// </summary>
		public string createdTime { get; set; }

		/// <summary>
		/// A short description of the file.
		/// </summary>
		public string description { get; set; }

		/// <summary>
		/// Whether the file has been explicitly trashed, as opposed to recursively trashed from a parent folder.
		/// </summary>
		public bool explicitlyTrashed { get; set; }

		/// <summary>
		/// The final component of fullFileExtension. This is only available for files with binary content in Drive.
		/// </summary>
		public string fileExtension { get; set; }

		/// <summary>
		/// The color for a folder as an RGB hex string. The supported colors are published in the folderColorPalette field of the About resource.
		///If an unsupported color is specified, the closest color in the palette will be used instead.
		/// </summary>
		public string folderColorRgb { get; set; }

		/// <summary>
		/// The full file extension extracted from the name field. May contain multiple concatenated extensions, such as "tar.gz". This is only available for files with binary content in Drive.
		///This is automatically updated when the name field changes, however it is not cleared if the new name does not contain a valid extension.
		/// </summary>
		public string fullFileExtension { get; set; }

		/// <summary>
		/// Whether any users are granted file access directly on this file. This field is only populated for Team Drive files.
		/// </summary>
		public bool hasAugmentedPermissions { get; set; }

		/// <summary>
		/// Whether this file has a thumbnail. This does not indicate whether the requesting app has access to the thumbnail. To check access, look for the presence of the thumbnailLink field.
		/// </summary>
		public bool hasThumbnail { get; set; }

		/// <summary>
		/// The ID of the file's head revision. This is currently only available for files with binary content in Drive.
		/// </summary>
		public string headRevisionId { get; set; }

		/// <summary>
		/// A static, unauthenticated link to the file's icon.
		/// </summary>
		public string iconLink { get; set; }

		/// <summary>
		/// The ID of the file.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Additional metadata about image media, if available.
		/// </summary>
		public object imageMediaMetadata { get; set; }

		/// <summary>
		/// Whether the file was created or opened by the requesting app.
		/// </summary>
		public bool isAppAuthorized { get; set; }

		/// <summary>
		/// Identifies what kind of resource this is. Value: the fixed string "drive#file".
		/// </summary>
		public string kind { get; set; } = "drive#file";

		/// <summary>
		/// The last user to modify the file.
		/// </summary>
		public User lastModifyingUser { get; set; }

		/// <summary>
		/// The MD5 checksum for the content of the file. This is only applicable to files with binary content in Drive.
		/// </summary>
		public string md5Checksum { get; set; }

		/// <summary>
		/// The MIME type of the file.
		///Drive will attempt to automatically detect an appropriate value from uploaded content if no value is provided. The value cannot be changed unless a new revision is uploaded.
		///If a file is created with a Google Doc MIME type, the uploaded content will be imported if possible. The supported import formats are published in the About resource.
		/// </summary>
		public string mimeType { get; set; }

		/// <summary>
		/// Whether the file has been modified by this user.
		/// </summary>
		public bool modifiedByMe { get; set; }

		/// <summary>
		/// The last time the file was modified by the user (RFC 3339 date-time).
		/// </summary>
		public string modifiedByMeTime { get; set; }

		/// <summary>
		/// The last time the file was modified by anyone (RFC 3339 date-time).
		///Note that setting modifiedTime will also update modifiedByMeTime for the user.
		/// </summary>
		public string modifiedTime { get; set; }

		/// <summary>
		/// The name of the file. This is not necessarily unique within a folder. Note that for immutable items such as the top level folders of Team Drives, My Drive root folder, and Application Data folder the name is constant.
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The original filename of the uploaded content if available, or else the original value of the name field. This is only available for files with binary content in Drive.
		/// </summary>
		public string originalFilename { get; set; }

		/// <summary>
		/// Whether the user owns the file. Not populated for Team Drive files.
		/// </summary>
		public bool ownedByMe { get; set; }

		/// <summary>
		/// The owners of the file. Currently, only certain legacy files may have more than one owner. Not populated for Team Drive files.
		/// </summary>
		public IEnumerable<User> owners { get; set; }

		/// <summary>
		/// The IDs of the parent folders which contain the file.
		///If not specified as part of a create request, the file will be placed directly in the user's My Drive folder. If not specified as part of a copy request, the file will inherit any discoverable parents of the source file. Update requests must use the addParents and removeParents parameters to modify the parents list.
		/// </summary>
		public IEnumerable<object> parents { get; set; }

		/// <summary>
		/// List of permission IDs for users with access to this file.
		/// </summary>
		public IEnumerable<object> permissionIds { get; set; }

		/// <summary>
		/// The full list of permissions for the file. This is only available if the requesting user can share the file. Not populated for Team Drive files.
		/// </summary>
		public IEnumerable<Permission> permissions { get; set; }

		/// <summary>
		/// A collection of arbitrary key-value pairs which are visible to all apps.
		///Entries with null values are cleared in update and copy requests.
		/// </summary>
		public object properties { get; set; }

		/// <summary>
		/// The number of storage quota bytes used by the file. This includes the head revision as well as previous revisions with keepForever enabled.
		/// </summary>
		public string quotaBytesUsed { get; set; }

		/// <summary>
		/// Whether the file has been shared. Not populated for Team Drive files.
		/// </summary>
		public bool shared { get; set; }

		/// <summary>
		/// The time at which the file was shared with the user, if applicable (RFC 3339 date-time).
		/// </summary>
		public string sharedWithMeTime { get; set; }

		/// <summary>
		/// The user who shared the file with the requesting user, if applicable.
		/// </summary>
		public User sharingUser { get; set; }

		/// <summary>
		/// The size of the file's content in bytes. This is only applicable to files with binary content in Drive.
		/// </summary>
		public string size { get; set; }

		/// <summary>
		/// The list of spaces which contain the file. The currently supported values are 'drive', 'appDataFolder' and 'photos'.
		/// </summary>
		public IEnumerable<object> spaces { get; set; }

		/// <summary>
		/// Whether the user has starred the file.
		/// </summary>
		public bool starred { get; set; }

		/// <summary>
		/// ID of the Team Drive the file resides in.
		/// </summary>
		public string teamDriveId { get; set; }

		/// <summary>
		/// A short-lived link to the file's thumbnail, if available. Typically lasts on the order of hours. Only populated when the requesting app can access the file's content.
		/// </summary>
		public string thumbnailLink { get; set; }

		/// <summary>
		/// The thumbnail version for use in thumbnail cache invalidation.
		/// </summary>
		public string thumbnailVersion { get; set; }

		/// <summary>
		/// Whether the file has been trashed, either explicitly or from a trashed parent folder. Only the owner may trash a file, and other users cannot see files in the owner's trash.
		/// </summary>
		public bool trashed { get; set; }

		/// <summary>
		/// The time that the item was trashed (RFC 3339 date-time). Only populated for Team Drive files.
		/// </summary>
		public string trashedTime { get; set; }

		/// <summary>
		/// If the file has been explicitly trashed, the user who trashed it. Only populated for Team Drive files.
		/// </summary>
		public User trashingUser { get; set; }

		/// <summary>
		/// A monotonically increasing version number for the file. This reflects every change made to the file on the server, even those not visible to the user.
		/// </summary>
		public string version { get; set; }

		/// <summary>
		/// Additional metadata about video media. This may not be available immediately upon upload.
		/// </summary>
		public object videoMediaMetadata { get; set; }

		/// <summary>
		/// Whether the file has been viewed by this user.
		/// </summary>
		public bool viewedByMe { get; set; }

		/// <summary>
		/// The last time the file was viewed by the user (RFC 3339 date-time).
		/// </summary>
		public string viewedByMeTime { get; set; }

		/// <summary>
		/// Whether users with only reader or commenter permission can copy the file's content. This affects copy, download, and print operations.
		/// </summary>
		public bool viewersCanCopyContent { get; set; }

		/// <summary>
		/// A link for downloading the content of the file in a browser. This is only available for files with binary content in Drive.
		/// </summary>
		public string webContentLink { get; set; }

		/// <summary>
		/// A link for opening the file in a relevant Google editor or viewer in a browser.
		/// </summary>
		public string webViewLink { get; set; }

		/// <summary>
		/// Whether users with only writer permission can modify the file's permissions. Not populated for Team Drive files.
		/// </summary>
		public bool writersCanShare { get; set; }

	}
}