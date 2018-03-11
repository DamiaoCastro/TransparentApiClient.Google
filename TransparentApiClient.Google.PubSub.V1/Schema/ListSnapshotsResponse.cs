using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class ListSnapshotsResponse { 

		/// <summary>
		/// If not empty, indicates that there may be more snapshot that match the
		///request; this value should be passed in a new `ListSnapshotsRequest`.
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// The resulting snapshots.
		/// </summary>
		public IEnumerable<Snapshot> snapshots { get; set; }

	}
}