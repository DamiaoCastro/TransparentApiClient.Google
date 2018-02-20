using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class HistoryLabelRemoved { 

		/// <summary>
		/// Label IDs removed from the message.
		/// </summary>
		public IEnumerable<object> labelIds { get; set; }

		public Message message { get; set; }

	}
}