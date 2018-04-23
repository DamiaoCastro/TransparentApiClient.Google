using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class Revision { 

		/// <summary>
		/// The ID of the revision.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Whether to keep this revision forever, even if it is no longer the head revision. If not set, the revision will be automatically purged 30 days after newer content is uploaded. This can be set on a maximum of 200 revisions for a file.
		///This field is only applicable to files with binary content in Drive.
		/// </summary>
		public bool keepForever { get; set; }

		/// <summary>
		/// Identifies what kind of resource this is. Value: the fixed string "drive#revision".
		/// </summary>
		public string kind { get; set; } = "drive#revision";

		/// <summary>
		/// The last user to modify this revision.
		/// </summary>
		public User lastModifyingUser { get; set; }

		/// <summary>
		/// The MD5 checksum of the revision's content. This is only applicable to files with binary content in Drive.
		/// </summary>
		public string md5Checksum { get; set; }

		/// <summary>
		/// The MIME type of the revision.
		/// </summary>
		public string mimeType { get; set; }

		/// <summary>
		/// The last time the revision was modified (RFC 3339 date-time).
		/// </summary>
		public string modifiedTime { get; set; }

		/// <summary>
		/// The original filename used to create this revision. This is only applicable to files with binary content in Drive.
		/// </summary>
		public string originalFilename { get; set; }

		/// <summary>
		/// Whether subsequent revisions will be automatically republished. This is only applicable to Google Docs.
		/// </summary>
		public bool publishAuto { get; set; }

		/// <summary>
		/// Whether this revision is published. This is only applicable to Google Docs.
		/// </summary>
		public bool published { get; set; }

		/// <summary>
		/// Whether this revision is published outside the domain. This is only applicable to Google Docs.
		/// </summary>
		public bool publishedOutsideDomain { get; set; }

		/// <summary>
		/// The size of the revision's content in bytes. This is only applicable to files with binary content in Drive.
		/// </summary>
		public string size { get; set; }

	}
}