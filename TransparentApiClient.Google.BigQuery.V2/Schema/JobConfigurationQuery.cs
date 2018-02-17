using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class JobConfigurationQuery { 

		/// <summary>
		/// [Optional] If true and query uses legacy SQL dialect, allows the query to produce arbitrarily large result tables at a slight cost in performance. Requires destinationTable to be set. For standard SQL queries, this flag is ignored and large results are always allowed. However, you must still set destinationTable when result size exceeds the allowed maximum response size.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool? allowLargeResults { get; set; } = false;

		/// <summary>
		/// [Optional] Specifies whether the job is allowed to create new tables. The following values are supported: CREATE_IF_NEEDED: If the table does not exist, BigQuery creates the table. CREATE_NEVER: The table must already exist. If it does not, a 'notFound' error is returned in the job result. The default value is CREATE_IF_NEEDED. Creation, truncation and append actions occur as one atomic update upon job completion.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string createDisposition { get; set; }

		/// <summary>
		/// [Optional] Specifies the default dataset to use for unqualified table names in the query.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public object defaultDataset { get; set; }

		/// <summary>
		/// Custom encryption configuration (e.g., Cloud KMS keys).
		/// </summary>
		public object destinationEncryptionConfiguration { get; set; }

		/// <summary>
		/// [Optional] Describes the table where the query results should be stored. If not present, a new table will be created to store the results. This property must be set for large results that exceed the maximum response size.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public object destinationTable { get; set; }

		/// <summary>
		/// [Optional] If true and query uses legacy SQL dialect, flattens all nested and repeated fields in the query results. allowLargeResults must be true if this is set to false. For standard SQL queries, this flag is ignored and results are never flattened.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool? flattenResults { get; set; } = true;

		/// <summary>
		/// [Optional] Limits the billing tier for this job. Queries that have resource usage beyond this tier will fail (without incurring a charge). If unspecified, this will be set to your project default.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? maximumBillingTier { get; set; } = 1;

		/// <summary>
		/// [Optional] Limits the bytes billed for this job. Queries that will have bytes billed beyond this limit will fail (without incurring a charge). If unspecified, this will be set to your project default.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string maximumBytesBilled { get; set; }

		/// <summary>
		/// Standard SQL only. Set to POSITIONAL to use positional (?) query parameters or to NAMED to use named (@myparam) query parameters in this query.
		/// </summary>
		public string parameterMode { get; set; }

		/// <summary>
		/// [Deprecated] This property is deprecated.
		/// </summary>
		public bool preserveNulls { get; set; }

		/// <summary>
		/// [Optional] Specifies a priority for the query. Possible values include INTERACTIVE and BATCH. The default value is INTERACTIVE.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string priority { get; set; }

		/// <summary>
		/// [Required] SQL query text to execute. The useLegacySql field can be used to indicate whether the query uses legacy SQL or standard SQL.
		/// </summary>
		public string query { get; set; }

		/// <summary>
		/// Query parameters for standard SQL queries.
		/// </summary>
		public IEnumerable<QueryParameter> queryParameters { get; set; }

		/// <summary>
		/// Allows the schema of the destination table to be updated as a side effect of the query job. Schema update options are supported in two cases: when writeDisposition is WRITE_APPEND; when writeDisposition is WRITE_TRUNCATE and the destination table is a partition of a table, specified by partition decorators. For normal tables, WRITE_TRUNCATE will always overwrite the schema. One or more of the following values are specified: ALLOW_FIELD_ADDITION: allow adding a nullable field to the schema. ALLOW_FIELD_RELAXATION: allow relaxing a required field in the original schema to nullable.
		/// </summary>
		public IEnumerable<object> schemaUpdateOptions { get; set; }

		/// <summary>
		/// [Optional] If querying an external data source outside of BigQuery, describes the data format, location and other properties of the data source. By defining these properties, the data source can then be queried as if it were a standard BigQuery table.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public object tableDefinitions { get; set; }

		/// <summary>
		/// If specified, configures time-based partitioning for the destination table.
		/// </summary>
		public object timePartitioning { get; set; }

		/// <summary>
		/// Specifies whether to use BigQuery's legacy SQL dialect for this query. The default value is true. If set to false, the query will use BigQuery's standard SQL: https://cloud.google.com/bigquery/sql-reference/ When useLegacySql is set to false, the value of flattenResults is ignored; query will be run as if flattenResults is false.
		/// </summary>
		public bool useLegacySql { get; set; }

		/// <summary>
		/// [Optional] Whether to look for the result in the query cache. The query cache is a best-effort cache that will be flushed whenever tables in the query are modified. Moreover, the query cache is only available when a query does not have a destination table specified. The default value is true.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool? useQueryCache { get; set; } = true;

		/// <summary>
		/// Describes user-defined function resources used in the query.
		/// </summary>
		public IEnumerable<UserDefinedFunctionResource> userDefinedFunctionResources { get; set; }

		/// <summary>
		/// [Optional] Specifies the action that occurs if the destination table already exists. The following values are supported: WRITE_TRUNCATE: If the table already exists, BigQuery overwrites the table data and uses the schema from the query result. WRITE_APPEND: If the table already exists, BigQuery appends the data to the table. WRITE_EMPTY: If the table already exists and contains data, a 'duplicate' error is returned in the job result. The default value is WRITE_EMPTY. Each action is atomic and only occurs if BigQuery is able to complete the job successfully. Creation, truncation and append actions occur as one atomic update upon job completion.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string writeDisposition { get; set; }

	}
}