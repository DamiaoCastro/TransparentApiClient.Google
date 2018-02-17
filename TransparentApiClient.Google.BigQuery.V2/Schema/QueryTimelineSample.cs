using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class QueryTimelineSample { 
 /// <summary>
/// Total number of active workers. This does not correspond directly to slot usage. This is the largest value observed since the last sample.
/// </summary>
public string activeInputs { get; set; }
/// <summary>
/// Total parallel units of work completed by this query.
/// </summary>
public string completedInputs { get; set; }
/// <summary>
/// Milliseconds elapsed since the start of query execution.
/// </summary>
public string elapsedMs { get; set; }
/// <summary>
/// Total parallel units of work remaining for the active stages.
/// </summary>
public string pendingInputs { get; set; }
/// <summary>
/// Cumulative slot-ms consumed by the query.
/// </summary>
public string totalSlotMs { get; set; }

} 
}
