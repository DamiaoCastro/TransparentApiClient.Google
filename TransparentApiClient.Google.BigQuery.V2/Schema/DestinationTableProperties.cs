using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class DestinationTableProperties { 

		/// <summary>
		/// [Optional] The description for the destination table. This will only be used if the destination table is newly created. If the table already exists and a value different than the current description is provided, the job will fail.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string description { get; set; }

		/// <summary>
		/// [Optional] The friendly name for the destination table. This will only be used if the destination table is newly created. If the table already exists and a value different than the current friendly name is provided, the job will fail.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string friendlyName { get; set; }

	}
}