using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class BatchDeleteMessagesRequest { 

		/// <summary>
		/// The IDs of the messages to delete.
		/// </summary>
		public IEnumerable<object> ids { get; set; }

	}
}