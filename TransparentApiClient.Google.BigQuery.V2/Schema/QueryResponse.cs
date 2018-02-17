using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class QueryResponse { 
 /// <summary>
/// Whether the query result was fetched from the query cache.
/// </summary>
public bool cacheHit { get; set; }
/// <summary>
/// [Output-only] The first errors or warnings encountered during the running of the job. The final message includes the number of errors that caused the process to stop. Errors here do not necessarily mean that the job has completed or was unsuccessful.
/// </summary>
public IEnumerable<object> errors { get; set; }
/// <summary>
/// Whether the query has completed or not. If rows or totalRows are present, this will always be true. If this is false, totalRows will not be available.
/// </summary>
public bool jobComplete { get; set; }
/// <summary>
/// Reference to the Job that was created to run the query. This field will be present even if the original request timed out, in which case GetQueryResults can be used to read the results once the query has completed. Since this API only returns the first page of results, subsequent pages can be fetched via the same mechanism (GetQueryResults).
/// </summary>
public object jobReference { get; set; }
/// <summary>
/// The resource type.
/// </summary>
public string kind { get; set; }
/// <summary>
/// [Output-only] The number of rows affected by a DML statement. Present only for DML statements INSERT, UPDATE or DELETE.
/// </summary>
public string numDmlAffectedRows { get; set; }
/// <summary>
/// A token used for paging results.
/// </summary>
public string pageToken { get; set; }
/// <summary>
/// An object with as many results as can be contained within the maximum permitted reply size. To get any additional rows, you can call GetQueryResults and specify the jobReference returned above.
/// </summary>
public IEnumerable<object> rows { get; set; }
/// <summary>
/// The schema of the results. Present only when the query completes successfully.
/// </summary>
public object schema { get; set; }
/// <summary>
/// The total number of bytes processed for this query. If this query was a dry run, this is the number of bytes that would be processed if the query were run.
/// </summary>
public string totalBytesProcessed { get; set; }
/// <summary>
/// The total number of rows in the complete query result set, which can be more than the number of rows in this single page of results.
/// </summary>
public string totalRows { get; set; }

} 
}
