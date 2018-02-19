using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class QueryParameterValue { 

		/// <summary>
		/// [Optional] The array values, if this is an array type.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<QueryParameterValue> arrayValues { get; set; }

		/// <summary>
		/// [Optional] The struct field values, in order of the struct type's declaration.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public QueryParameterValue structValues { get; set; }

		/// <summary>
		/// [Optional] The value of this value, if a simple scalar type.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string value { get; set; }

	}
}