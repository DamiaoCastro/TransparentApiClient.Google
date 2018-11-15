using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigqueryDataTransfer.V1.Schema { 
	public class PullResponse { 

		/// <summary>
		/// Received Pub/Sub messages. The Pub/Sub system will return zero messages if
		///there are no more available in the backlog. The Pub/Sub system may return
		///fewer than the `maxMessages` requested even if there are more messages
		///available in the backlog.
		/// </summary>
		public IEnumerable<ReceivedMessage> receivedMessages { get; set; }

	}
}