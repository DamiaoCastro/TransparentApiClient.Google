using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class FilterAction { 

		/// <summary>
		/// List of labels to add to the message.
		/// </summary>
		public IEnumerable<object> addLabelIds { get; set; }

		/// <summary>
		/// Email address that the message should be forwarded to.
		/// </summary>
		public string forward { get; set; }

		/// <summary>
		/// List of labels to remove from the message.
		/// </summary>
		public IEnumerable<object> removeLabelIds { get; set; }

	}
}