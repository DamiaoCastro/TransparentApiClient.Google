using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class PublishResponse { 

		/// <summary>
		/// The server-assigned ID of each published message, in the same order as
		///the messages in the request. IDs are guaranteed to be unique within
		///the topic.
		/// </summary>
		public IEnumerable<object> messageIds { get; set; }

	}
}