using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class ReplyList { 

		/// <summary>
		/// Identifies what kind of resource this is. Value: the fixed string "drive#replyList".
		/// </summary>
		public string kind { get; set; } = "drive#replyList";

		/// <summary>
		/// The page token for the next page of replies. This will be absent if the end of the replies list has been reached. If the token is rejected for any reason, it should be discarded, and pagination should be restarted from the first page of results.
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// The list of replies. If nextPageToken is populated, then this list may be incomplete and an additional page of results should be fetched.
		/// </summary>
		public IEnumerable<Reply> replies { get; set; }

	}
}