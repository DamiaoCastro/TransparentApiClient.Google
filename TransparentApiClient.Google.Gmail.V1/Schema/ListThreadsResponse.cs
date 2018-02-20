using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class ListThreadsResponse { 

		/// <summary>
		/// Page token to retrieve the next page of results in the list.
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// Estimated total number of results.
		/// </summary>
		public int resultSizeEstimate { get; set; }

		/// <summary>
		/// List of threads.
		/// </summary>
		public IEnumerable<Thread> threads { get; set; }

	}
}