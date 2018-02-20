using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class ListFiltersResponse { 

		/// <summary>
		/// List of a user's filters.
		/// </summary>
		public IEnumerable<Filter> filter { get; set; }

	}
}