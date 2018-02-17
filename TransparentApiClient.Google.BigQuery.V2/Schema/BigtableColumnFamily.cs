using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class BigtableColumnFamily { 

		/// <summary>
		/// [Optional] Lists of columns that should be exposed as individual fields as opposed to a list of (column name, value) pairs. All columns whose qualifier matches a qualifier in this list can be accessed as .. Other columns can be accessed as a list through .Column field.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<BigtableColumn> columns { get; set; }

		/// <summary>
		/// [Optional] The encoding of the values when the type is not STRING. Acceptable encoding values are: TEXT - indicates values are alphanumeric text strings. BINARY - indicates values are encoded using HBase Bytes.toBytes family of functions. This can be overridden for a specific column by listing that column in 'columns' and specifying an encoding for it.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string encoding { get; set; }

		/// <summary>
		/// Identifier of the column family.
		/// </summary>
		public string familyId { get; set; }

		/// <summary>
		/// [Optional] If this is set only the latest version of value are exposed for all columns in this column family. This can be overridden for a specific column by listing that column in 'columns' and specifying a different setting for that column.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool? onlyReadLatest { get; set; }

		/// <summary>
		/// [Optional] The type to convert the value in cells of this column family. The values are expected to be encoded using HBase Bytes.toBytes function when using the BINARY encoding value. Following BigQuery types are allowed (case-sensitive) - BYTES STRING INTEGER FLOAT BOOLEAN Default type is BYTES. This can be overridden for a specific column by listing that column in 'columns' and specifying a type for it.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string type { get; set; }

	}
}