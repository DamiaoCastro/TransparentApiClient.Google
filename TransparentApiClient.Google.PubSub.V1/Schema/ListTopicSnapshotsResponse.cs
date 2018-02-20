using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class ListTopicSnapshotsResponse { 

		/// <summary>
		/// If not empty, indicates that there may be more snapshots that match
the request; this value should be passed in a new
`ListTopicSnapshotsRequest` to get more snapshots.
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// The names of the snapshots that match the request.
		/// </summary>
		public IEnumerable<object> snapshots { get; set; }

	}
}