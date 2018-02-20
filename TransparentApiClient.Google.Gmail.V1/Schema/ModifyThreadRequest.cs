using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class ModifyThreadRequest { 

		/// <summary>
		/// A list of IDs of labels to add to this thread.
		/// </summary>
		public IEnumerable<object> addLabelIds { get; set; }

		/// <summary>
		/// A list of IDs of labels to remove from this thread.
		/// </summary>
		public IEnumerable<object> removeLabelIds { get; set; }

	}
}