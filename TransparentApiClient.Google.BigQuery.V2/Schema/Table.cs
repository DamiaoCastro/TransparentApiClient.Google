using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class Table { 

		/// <summary>
		/// [Output-only] The time when this table was created, in milliseconds since the epoch.
		/// </summary>
		public string creationTime { get; set; }

		/// <summary>
		/// [Optional] A user-friendly description of this table.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string description { get; set; }

		/// <summary>
		/// Custom encryption configuration (e.g., Cloud KMS keys).
		/// </summary>
		public object encryptionConfiguration { get; set; }

		/// <summary>
		/// [Output-only] A hash of this resource.
		/// </summary>
		public string etag { get; set; }

		/// <summary>
		/// [Optional] The time when this table expires, in milliseconds since the epoch. If not present, the table will persist indefinitely. Expired tables will be deleted and their storage reclaimed. The defaultTableExpirationMs property of the encapsulating dataset can be used to set a default expirationTime on newly created tables.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string expirationTime { get; set; }

		/// <summary>
		/// [Optional] Describes the data format, location, and other properties of a table stored outside of BigQuery. By defining these properties, the data source can then be queried as if it were a standard BigQuery table.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public object externalDataConfiguration { get; set; }

		/// <summary>
		/// [Optional] A descriptive name for this table.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string friendlyName { get; set; }

		/// <summary>
		/// [Output-only] An opaque ID uniquely identifying the table.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// [Output-only] The type of the resource.
		/// </summary>
		public string kind { get; set; } = "bigquery#table";

		/// <summary>
		/// The labels associated with this table. You can use these to organize and group your tables. Label keys and values can be no longer than 63 characters, can only contain lowercase letters, numeric characters, underscores and dashes. International characters are allowed. Label values are optional. Label keys must start with a letter and each label in the list must have a different key.
		/// </summary>
		public object labels { get; set; }

		/// <summary>
		/// [Output-only] The time when this table was last modified, in milliseconds since the epoch.
		/// </summary>
		public string lastModifiedTime { get; set; }

		/// <summary>
		/// [Output-only] The geographic location where the table resides. This value is inherited from the dataset.
		/// </summary>
		public string location { get; set; }

		/// <summary>
		/// [Output-only] The size of this table in bytes, excluding any data in the streaming buffer.
		/// </summary>
		public string numBytes { get; set; }

		/// <summary>
		/// [Output-only] The number of bytes in the table that are considered "long-term storage".
		/// </summary>
		public string numLongTermBytes { get; set; }

		/// <summary>
		/// [Output-only] The number of rows of data in this table, excluding any data in the streaming buffer.
		/// </summary>
		public string numRows { get; set; }

		/// <summary>
		/// [Optional] Describes the schema of this table.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public object schema { get; set; }

		/// <summary>
		/// [Output-only] A URL that can be used to access this resource again.
		/// </summary>
		public string selfLink { get; set; }

		/// <summary>
		/// [Output-only] Contains information regarding this table's streaming buffer, if one is present. This field will be absent if the table is not being streamed to or if there is no data in the streaming buffer.
		/// </summary>
		public object streamingBuffer { get; set; }

		/// <summary>
		/// [Required] Reference describing the ID of this table.
		/// </summary>
		public object tableReference { get; set; }

		/// <summary>
		/// If specified, configures time-based partitioning for this table.
		/// </summary>
		public object timePartitioning { get; set; }

		/// <summary>
		/// [Output-only] Describes the table type. The following values are supported: TABLE: A normal BigQuery table. VIEW: A virtual table defined by a SQL query. EXTERNAL: A table that references data stored in an external storage system, such as Google Cloud Storage. The default value is TABLE.
		/// </summary>
		public string type { get; set; }

		/// <summary>
		/// [Optional] The view definition.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public object view { get; set; }

	}
}