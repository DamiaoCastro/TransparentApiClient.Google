using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class QueryRequest { 

		/// <summary>
		/// [Optional] Specifies the default datasetId and projectId to assume for any unqualified table names in the query. If not set, all table names in the query string must be qualified in the format 'datasetId.tableId'.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public object defaultDataset { get; set; }

		/// <summary>
		/// [Optional] If set to true, BigQuery doesn't run the job. Instead, if the query is valid, BigQuery returns statistics about the job such as how many bytes would be processed. If the query is invalid, an error returns. The default value is false.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool? dryRun { get; set; }

		/// <summary>
		/// The resource type of the request.
		/// </summary>
		public string kind { get; set; } = "bigquery#queryRequest";

		/// <summary>
		/// [Experimental] The geographic location where the job should run. Required except for US and EU.
		/// </summary>
		public string location { get; set; }

		/// <summary>
		/// [Optional] The maximum number of rows of data to return per page of results. Setting this flag to a small value such as 1000 and then paging through results might improve reliability when the query result set is large. In addition to this limit, responses are also limited to 10 MB. By default, there is no maximum row count, and only the byte limit applies.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? maxResults { get; set; }

		/// <summary>
		/// Standard SQL only. Set to POSITIONAL to use positional (?) query parameters or to NAMED to use named (@myparam) query parameters in this query.
		/// </summary>
		public string parameterMode { get; set; }

		/// <summary>
		/// [Deprecated] This property is deprecated.
		/// </summary>
		public bool preserveNulls { get; set; }

		/// <summary>
		/// [Required] A query string, following the BigQuery query syntax, of the query to execute. Example: "SELECT count(f1) FROM [myProjectId:myDatasetId.myTableId]".
		/// </summary>
		public string query { get; set; }

		/// <summary>
		/// Query parameters for Standard SQL queries.
		/// </summary>
		public IEnumerable<QueryParameter> queryParameters { get; set; }

		/// <summary>
		/// [Optional] How long to wait for the query to complete, in milliseconds, before the request times out and returns. Note that this is only a timeout for the request, not the query. If the query takes longer to run than the timeout value, the call returns without any results and with the 'jobComplete' flag set to false. You can call GetQueryResults() to wait for the query to complete and read the results. The default value is 10000 milliseconds (10 seconds).
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? timeoutMs { get; set; }

		/// <summary>
		/// Specifies whether to use BigQuery's legacy SQL dialect for this query. The default value is true. If set to false, the query will use BigQuery's standard SQL: https://cloud.google.com/bigquery/sql-reference/ When useLegacySql is set to false, the value of flattenResults is ignored; query will be run as if flattenResults is false.
		/// </summary>
		public bool useLegacySql { get; set; } = true;

		/// <summary>
		/// [Optional] Whether to look for the result in the query cache. The query cache is a best-effort cache that will be flushed whenever tables in the query are modified. The default value is true.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public bool? useQueryCache { get; set; } = true;

	}
}