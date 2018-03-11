using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class ListTopicsResponse { 

		/// <summary>
		/// If not empty, indicates that there may be more topics that match the
		///request; this value should be passed in a new `ListTopicsRequest`.
		/// </summary>
		public string nextPageToken { get; set; }

		/// <summary>
		/// The resulting topics.
		/// </summary>
		public IEnumerable<Topic> topics { get; set; }

	}
}