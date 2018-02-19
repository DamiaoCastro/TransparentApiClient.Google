using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class ExternalDataConfiguration { 

		/// <summary>
		/// Try to detect schema and format options automatically. Any option specified explicitly will be honored.
		/// </summary>
		public bool autodetect { get; set; }

		/// <summary>
		/// [Optional] Additional options if sourceFormat is set to BIGTABLE.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public BigtableOptions bigtableOptions { get; set; }

		/// <summary>
		/// [Optional] The compression type of the data source. Possible values include GZIP and NONE. The default value is NONE. This setting is ignored for Google Cloud Bigtable, Google Cloud Datastore backups and Avro formats.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string compression { get; set; }

		/// <summary>
		/// Additional properties to set if sourceFormat is set to CSV.
		/// </summary>
		public CsvOptions csvOptions { get; set; }

		/// <summary>
		/// [Optional] Additional options if sourceFormat is set to GOOGLE_SHEETS.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public GoogleSheetsOptions googleSheetsOptions { get; set; }

		/// <summary>
		/// [Optional] Indicates if BigQuery should allow extra values that are not represented in the table schema. If true, the extra values are ignored. If false, records with extra columns are treated as bad records, and if there are too many bad records, an invalid error is returned in the job result. The default value is false. The sourceFormat property determines what BigQuery treats as an extra value: CSV: Trailing columns JSON: Named values that don't match any column names Google Cloud Bigtable: This setting is ignored. Google Cloud Datastore backups: This setting is ignored. Avro: This setting is ignored.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool? ignoreUnknownValues { get; set; }

		/// <summary>
		/// [Optional] The maximum number of bad records that BigQuery can ignore when reading data. If the number of bad records exceeds this value, an invalid error is returned in the job result. The default value is 0, which requires that all records are valid. This setting is ignored for Google Cloud Bigtable, Google Cloud Datastore backups and Avro formats.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? maxBadRecords { get; set; }

		/// <summary>
		/// [Optional] The schema for the data. Schema is required for CSV and JSON formats. Schema is disallowed for Google Cloud Bigtable, Cloud Datastore backups, and Avro formats.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public TableSchema schema { get; set; }

		/// <summary>
		/// [Required] The data format. For CSV files, specify "CSV". For Google sheets, specify "GOOGLE_SHEETS". For newline-delimited JSON, specify "NEWLINE_DELIMITED_JSON". For Avro files, specify "AVRO". For Google Cloud Datastore backups, specify "DATASTORE_BACKUP". [Beta] For Google Cloud Bigtable, specify "BIGTABLE".
		/// </summary>
		public string sourceFormat { get; set; }

		/// <summary>
		/// [Required] The fully-qualified URIs that point to your data in Google Cloud. For Google Cloud Storage URIs: Each URI can contain one '*' wildcard character and it must come after the 'bucket' name. Size limits related to load jobs apply to external data sources. For Google Cloud Bigtable URIs: Exactly one URI can be specified and it has be a fully specified and valid HTTPS URL for a Google Cloud Bigtable table. For Google Cloud Datastore backups, exactly one URI can be specified. Also, the '*' wildcard character is not allowed.
		/// </summary>
		public IEnumerable<object> sourceUris { get; set; }

	}
}