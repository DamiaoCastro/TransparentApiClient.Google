using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class PermissionList { 

		/// <summary>
		/// Identifies what kind of resource this is. Value: the fixed string "drive#permissionList".
		/// </summary>
		public string kind { get; set; } = "drive#permissionList";

		/// <summary>
		/// The page token for the next page of permissions. This field will be absent if the end of the permissions list has been reached. If the token is rejected for any reason, it should be discarded, and pagination should be restarted from the first page of results.
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// The list of permissions. If nextPageToken is populated, then this list may be incomplete and an additional page of results should be fetched.
		/// </summary>
		public IEnumerable<Permission> permissions { get; set; }

	}
}