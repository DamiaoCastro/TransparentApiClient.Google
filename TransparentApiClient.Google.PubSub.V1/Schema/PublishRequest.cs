using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class PublishRequest { 

		/// <summary>
		/// The messages to publish.
		/// </summary>
		public IEnumerable<PubsubMessage> messages { get; set; }

	}
}