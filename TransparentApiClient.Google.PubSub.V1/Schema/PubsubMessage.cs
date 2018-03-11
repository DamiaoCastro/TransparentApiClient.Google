using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class PubsubMessage { 

		/// <summary>
		/// The message payload.
		/// </summary>
		public string data { get; set; }

		/// <summary>
		/// Optional attributes for this message.
		/// </summary>
		public object attributes { get; set; }

		/// <summary>
		/// ID of this message, assigned by the server when the message is published.
		///Guaranteed to be unique within the topic. This value may be read by a
		///subscriber that receives a `PubsubMessage` via a `Pull` call or a push
		///delivery. It must not be populated by the publisher in a `Publish` call.
		/// </summary>
		public string messageId { get; set; }

		/// <summary>
		/// The time at which the message was published, populated by the server when
		///it receives the `Publish` call. It must not be populated by the
		///publisher in a `Publish` call.
		/// </summary>
		public string publishTime { get; set; }

	}
}