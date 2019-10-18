using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class Location { 

		/// <summary>
		/// Cross-service attributes for the location. For example
		///
		///    {"cloud.googleapis.com/region": "us-east1"}
		/// </summary>
		public object labels { get; set; }

		/// <summary>
		/// Resource name for the location, which may vary between implementations.
		///For example: `"projects/example-project/locations/us-east1"`
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The canonical id for this location. For example: `"us-east1"`.
		/// </summary>
		public string locationId { get; set; }

		/// <summary>
		/// The friendly name for this location, typically a nearby city name.
		///For example, "Tokyo".
		/// </summary>
		public string displayName { get; set; }

		/// <summary>
		/// Service-specific metadata. For example the available capacity at the given
		///location.
		/// </summary>
		public object metadata { get; set; }

	}
}