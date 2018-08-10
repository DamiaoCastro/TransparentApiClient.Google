using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class JobStatistics4 { 

		/// <summary>
		/// [Output-only] Number of files per destination URI or URI pattern specified in the extract configuration. These values will be in the same order as the URIs specified in the 'destinationUris' field.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<object> destinationUriFileCounts { get; set; }

	}
}