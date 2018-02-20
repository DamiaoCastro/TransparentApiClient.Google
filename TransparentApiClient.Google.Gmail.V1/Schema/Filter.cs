using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class Filter { 

		/// <summary>
		/// Action that the filter performs.
		/// </summary>
		public FilterAction action { get; set; }

		/// <summary>
		/// Matching criteria for the filter.
		/// </summary>
		public FilterCriteria criteria { get; set; }

		/// <summary>
		/// The server assigned ID of the filter.
		/// </summary>
		public string id { get; set; }

	}
}