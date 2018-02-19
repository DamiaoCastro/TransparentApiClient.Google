using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class QueryParameterType { 

		/// <summary>
		/// [Optional] The type of the array's elements, if this is an array.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public QueryParameterType arrayType { get; set; }

		/// <summary>
		/// [Optional] The types of the fields of this struct, in order, if this is a struct.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<StructType> structTypes { get; set; }

		/// <summary>
		/// [Required] The top level type of this field.
		/// </summary>
		public string type { get; set; }

	public class StructType { 

		/// <summary>
		/// [Optional] Human-oriented description of the field.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string description { get; set; }

		/// <summary>
		/// [Optional] The name of this field.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string name { get; set; }

		/// <summary>
		/// [Required] The type of this field.
		/// </summary>
		public QueryParameterType type { get; set; }

	}
	}
}