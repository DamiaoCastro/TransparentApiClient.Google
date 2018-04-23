using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class GeneratedIds { 

		/// <summary>
		/// The IDs generated for the requesting user in the specified space.
		/// </summary>
		public IEnumerable<object> ids { get; set; }

		/// <summary>
		/// Identifies what kind of resource this is. Value: the fixed string "drive#generatedIds".
		/// </summary>
		public string kind { get; set; } = "drive#generatedIds";

		/// <summary>
		/// The type of file that can be created with these IDs.
		/// </summary>
		public string space { get; set; }

	}
}