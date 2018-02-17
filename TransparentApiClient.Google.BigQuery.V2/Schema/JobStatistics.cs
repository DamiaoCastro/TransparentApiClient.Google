using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class JobStatistics { 
 /// <summary>
/// [Experimental] [Output-only] Job progress (0.0 -> 1.0) for LOAD and EXTRACT jobs.
/// </summary>
public double completionRatio { get; set; }
/// <summary>
/// [Output-only] Creation time of this job, in milliseconds since the epoch. This field will be present on all jobs.
/// </summary>
public string creationTime { get; set; }
/// <summary>
/// [Output-only] End time of this job, in milliseconds since the epoch. This field will be present whenever a job is in the DONE state.
/// </summary>
public string endTime { get; set; }
/// <summary>
/// [Output-only] Statistics for an extract job.
/// </summary>
public object extract { get; set; }
/// <summary>
/// [Output-only] Statistics for a load job.
/// </summary>
public object load { get; set; }
/// <summary>
/// [Output-only] Statistics for a query job.
/// </summary>
public object query { get; set; }
/// <summary>
/// [Output-only] Start time of this job, in milliseconds since the epoch. This field will be present when the job transitions from the PENDING state to either RUNNING or DONE.
/// </summary>
public string startTime { get; set; }
/// <summary>
/// [Output-only] [Deprecated] Use the bytes processed in the query statistics instead.
/// </summary>
public string totalBytesProcessed { get; set; }

} 
}
