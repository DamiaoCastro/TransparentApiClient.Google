using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class ModifyMessageRequest { 

		/// <summary>
		/// A list of IDs of labels to add to this message.
		/// </summary>
		public IEnumerable<object> addLabelIds { get; set; }

		/// <summary>
		/// A list IDs of labels to remove from this message.
		/// </summary>
		public IEnumerable<object> removeLabelIds { get; set; }

	}
}