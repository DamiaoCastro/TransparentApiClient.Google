using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class Change { 

		/// <summary>
		/// The updated state of the file. Present if the type is file and the file has not been removed from this list of changes.
		/// </summary>
		public File file { get; set; }

		/// <summary>
		/// The ID of the file which has changed.
		/// </summary>
		public string fileId { get; set; }

		/// <summary>
		/// Identifies what kind of resource this is. Value: the fixed string "drive#change".
		/// </summary>
		public string kind { get; set; } = "drive#change";

		/// <summary>
		/// Whether the file or Team Drive has been removed from this list of changes, for example by deletion or loss of access.
		/// </summary>
		public bool removed { get; set; }

		/// <summary>
		/// The updated state of the Team Drive. Present if the type is teamDrive, the user is still a member of the Team Drive, and the Team Drive has not been removed.
		/// </summary>
		public TeamDrive teamDrive { get; set; }

		/// <summary>
		/// The ID of the Team Drive associated with this change.
		/// </summary>
		public string teamDriveId { get; set; }

		/// <summary>
		/// The time of this change (RFC 3339 date-time).
		/// </summary>
		public string time { get; set; }

		/// <summary>
		/// The type of the change. Possible values are file and teamDrive.
		/// </summary>
		public string type { get; set; }

	}
}