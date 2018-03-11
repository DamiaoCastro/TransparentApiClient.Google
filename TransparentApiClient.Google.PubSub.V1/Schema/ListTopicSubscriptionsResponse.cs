using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class ListTopicSubscriptionsResponse { 

		/// <summary>
		/// If not empty, indicates that there may be more subscriptions that match
		///the request; this value should be passed in a new
		///`ListTopicSubscriptionsRequest` to get more subscriptions.
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// The names of the subscriptions that match the request.
		/// </summary>
		public IEnumerable<object> subscriptions { get; set; }

	}
}