using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class TableFieldSchema { 

		/// <summary>
		/// [Optional] The field description. The maximum length is 1,024 characters.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string description { get; set; }

		/// <summary>
		/// [Optional] Describes the nested schema fields if the type property is set to RECORD.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<TableFieldSchema> fields { get; set; }

		/// <summary>
		/// [Optional] The field mode. Possible values include NULLABLE, REQUIRED and REPEATED. The default value is NULLABLE.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string mode { get; set; }

		/// <summary>
		/// [Required] The field name. The name must contain only letters (a-z, A-Z), numbers (0-9), or underscores (_), and must start with a letter or underscore. The maximum length is 128 characters.
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// [Required] The field data type. Possible values include STRING, BYTES, INTEGER, INT64 (same as INTEGER), FLOAT, FLOAT64 (same as FLOAT), BOOLEAN, BOOL (same as BOOLEAN), TIMESTAMP, DATE, TIME, DATETIME, RECORD (where RECORD indicates that the field contains a nested schema) or STRUCT (same as RECORD).
		/// </summary>
		public string type { get; set; }

	}
}