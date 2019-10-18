using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class ListLocationsResponse { 

		/// <summary>
		/// A list of locations that matches the specified filter in the request.
		/// </summary>
		public IEnumerable<Location> locations { get; set; }

		/// <summary>
		/// The standard List next-page token.
		/// </summary>
		public string nextPageToken { get; set; }

	}
}