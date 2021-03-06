using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class GetQueryResultsResponse { 

		/// <summary>
		/// Whether the query result was fetched from the query cache.
		/// </summary>
		public bool cacheHit { get; set; }

		/// <summary>
		/// [Output-only] The first errors or warnings encountered during the running of the job. The final message includes the number of errors that caused the process to stop. Errors here do not necessarily mean that the job has completed or was unsuccessful.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public IEnumerable<ErrorProto> errors { get; set; }

		/// <summary>
		/// A hash of this response.
		/// </summary>
		public string etag { get; set; }

		/// <summary>
		/// Whether the query has completed or not. If rows or totalRows are present, this will always be true. If this is false, totalRows will not be available.
		/// </summary>
		public bool jobComplete { get; set; }

		/// <summary>
		/// Reference to the BigQuery Job that was created to run the query. This field will be present even if the original request timed out, in which case GetQueryResults can be used to read the results once the query has completed. Since this API only returns the first page of results, subsequent pages can be fetched via the same mechanism (GetQueryResults).
		/// </summary>
		public JobReference jobReference { get; set; }

		/// <summary>
		/// The resource type of the response.
		/// </summary>
		public string kind { get; set; } = "bigquery#getQueryResultsResponse";

		/// <summary>
		/// [Output-only] The number of rows affected by a DML statement. Present only for DML statements INSERT, UPDATE or DELETE.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string numDmlAffectedRows { get; set; }

		/// <summary>
		/// A token used for paging results.
		/// </summary>
		public string pageToken { get; set; }

		/// <summary>
		/// An object with as many results as can be contained within the maximum permitted reply size. To get any additional rows, you can call GetQueryResults and specify the jobReference returned above. Present only when the query completes successfully.
		/// </summary>
		public IEnumerable<TableRow> rows { get; set; }

		/// <summary>
		/// The schema of the results. Present only when the query completes successfully.
		/// </summary>
		public TableSchema schema { get; set; }

		/// <summary>
		/// The total number of bytes processed for this query.
		/// </summary>
		public string totalBytesProcessed { get; set; }

		/// <summary>
		/// The total number of rows in the complete query result set, which can be more than the number of rows in this single page of results. Present only when the query completes successfully.
		/// </summary>
		public string totalRows { get; set; }

	}
}