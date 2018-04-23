using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class RevisionList { 

		/// <summary>
		/// Identifies what kind of resource this is. Value: the fixed string "drive#revisionList".
		/// </summary>
		public string kind { get; set; } = "drive#revisionList";

		/// <summary>
		/// The page token for the next page of revisions. This will be absent if the end of the revisions list has been reached. If the token is rejected for any reason, it should be discarded, and pagination should be restarted from the first page of results.
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// The list of revisions. If nextPageToken is populated, then this list may be incomplete and an additional page of results should be fetched.
		/// </summary>
		public IEnumerable<Revision> revisions { get; set; }

	}
}