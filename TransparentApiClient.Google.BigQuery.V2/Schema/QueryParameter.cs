using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class QueryParameter { 

		/// <summary>
		/// [Optional] If unset, this is a positional parameter. Otherwise, should be unique within a query.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string name { get; set; }

		/// <summary>
		/// [Required] The type of this parameter.
		/// </summary>
		public object parameterType { get; set; }

		/// <summary>
		/// [Required] The value of this parameter.
		/// </summary>
		public object parameterValue { get; set; }

	}
}