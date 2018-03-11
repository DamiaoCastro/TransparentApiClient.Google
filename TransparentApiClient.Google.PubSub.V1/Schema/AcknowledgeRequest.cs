using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class AcknowledgeRequest { 

		/// <summary>
		/// The acknowledgment ID for the messages being acknowledged that was returned
		///by the Pub/Sub system in the `Pull` response. Must not be empty.
		/// </summary>
		public IEnumerable<object> ackIds { get; set; }

	}
}