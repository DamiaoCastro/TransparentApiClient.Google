using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class BatchModifyMessagesRequest { 

		/// <summary>
		/// A list of label IDs to add to messages.
		/// </summary>
		public IEnumerable<object> addLabelIds { get; set; }

		/// <summary>
		/// The IDs of the messages to modify. There is a limit of 1000 ids per request.
		/// </summary>
		public IEnumerable<object> ids { get; set; }

		/// <summary>
		/// A list of label IDs to remove from messages.
		/// </summary>
		public IEnumerable<object> removeLabelIds { get; set; }

	}
}