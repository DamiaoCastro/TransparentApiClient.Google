using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class ListHistoryResponse { 

		/// <summary>
		/// List of history records. Any messages contained in the response will typically only have id and threadId fields populated.
		/// </summary>
		public IEnumerable<History> history { get; set; }

		/// <summary>
		/// The ID of the mailbox's current history record.
		/// </summary>
		public string historyId { get; set; }

		/// <summary>
		/// Page token to retrieve the next page of results in the list.
		/// </summary>
		public string nextPageToken { get; set; }

	}
}