using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class ListSubscriptionsResponse { 

		/// <summary>
		/// If not empty, indicates that there may be more subscriptions that match
the request; this value should be passed in a new
`ListSubscriptionsRequest` to get more subscriptions.
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// The subscriptions that match the request.
		/// </summary>
		public IEnumerable<Subscription> subscriptions { get; set; }

	}
}