using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class TableDataInsertAllRequest { 

		/// <summary>
		/// [Optional] Accept rows that contain values that do not match the schema. The unknown values are ignored. Default is false, which treats unknown values as errors.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool? ignoreUnknownValues { get; set; }

		/// <summary>
		/// The resource type of the response.
		/// </summary>
		public string kind { get; set; } = "bigquery#tableDataInsertAllRequest";

		/// <summary>
		/// The rows to insert.
		/// </summary>
		public IEnumerable<Row> rows { get; set; }

		/// <summary>
		/// [Optional] Insert all valid rows of a request, even if invalid rows exist. The default value is false, which causes the entire request to fail if any invalid rows exist.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool? skipInvalidRows { get; set; }

		/// <summary>
		/// [Experimental] If specified, treats the destination table as a base template, and inserts the rows into an instance table named "{destination}{templateSuffix}". BigQuery will manage creation of the instance table, using the schema of the base template table. See https://cloud.google.com/bigquery/streaming-data-into-bigquery#template-tables for considerations when working with templates tables.
		/// </summary>
		public string templateSuffix { get; set; }

	public class Row { 

		/// <summary>
		/// [Optional] A unique ID for each row. BigQuery uses this property to detect duplicate insertion requests on a best-effort basis.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string insertId { get; set; }

		/// <summary>
		/// [Required] A JSON object that contains a row of data. The object's properties and values must match the destination table's schema.
		/// </summary>
		public object json { get; set; }

	}
	}
}