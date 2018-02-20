using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class ListMessagesResponse { 

		/// <summary>
		/// List of messages.
		/// </summary>
		public IEnumerable<Message> messages { get; set; }

		/// <summary>
		/// Token to retrieve the next page of results in the list.
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// Estimated total number of results.
		/// </summary>
		public int resultSizeEstimate { get; set; }

	}
}