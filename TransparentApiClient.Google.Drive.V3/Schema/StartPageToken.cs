using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Drive.V3.Schema { 
	public class StartPageToken { 

		/// <summary>
		/// Identifies what kind of resource this is. Value: the fixed string "drive#startPageToken".
		/// </summary>
		public string kind { get; set; } = "drive#startPageToken";

		/// <summary>
		/// The starting page token for listing changes.
		/// </summary>
		public string startPageToken { get; set; }

	}
}