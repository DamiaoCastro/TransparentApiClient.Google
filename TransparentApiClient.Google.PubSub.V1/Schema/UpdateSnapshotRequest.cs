using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class UpdateSnapshotRequest { 

		/// <summary>
		/// Indicates which fields in the provided snapshot to update.
Must be specified and non-empty.
		/// </summary>
		public string updateMask { get; set; }

		/// <summary>
		/// The updated snpashot object.
		/// </summary>
		public Snapshot snapshot { get; set; }

	}
}