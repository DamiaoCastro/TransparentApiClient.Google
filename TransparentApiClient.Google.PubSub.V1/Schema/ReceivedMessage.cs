using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class ReceivedMessage { 

		/// <summary>
		/// This ID can be used to acknowledge the received message.
		/// </summary>
		public string ackId { get; set; }

		/// <summary>
		/// The message.
		/// </summary>
		public PubsubMessage message { get; set; }

	}
}