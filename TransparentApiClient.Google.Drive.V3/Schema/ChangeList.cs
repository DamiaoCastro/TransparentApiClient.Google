using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class ChangeList { 

		/// <summary>
		/// The list of changes. If nextPageToken is populated, then this list may be incomplete and an additional page of results should be fetched.
		/// </summary>
		public IEnumerable<Change> changes { get; set; }

		/// <summary>
		/// Identifies what kind of resource this is. Value: the fixed string "drive#changeList".
		/// </summary>
		public string kind { get; set; } = "drive#changeList";

		/// <summary>
		/// The starting page token for future changes. This will be present only if the end of the current changes list has been reached.
		/// </summary>
		public string newStartPageToken { get; set; }

		/// <summary>
		/// The page token for the next page of changes. This will be absent if the end of the changes list has been reached. If the token is rejected for any reason, it should be discarded, and pagination should be restarted from the first page of results.
		/// </summary>
		public string nextPageToken { get; set; }

	}
}