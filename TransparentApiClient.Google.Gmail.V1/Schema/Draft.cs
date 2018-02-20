using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class Draft { 

		/// <summary>
		/// The immutable ID of the draft.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The message content of the draft.
		/// </summary>
		public Message message { get; set; }

	}
}