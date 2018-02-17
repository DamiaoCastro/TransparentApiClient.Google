using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class JobConfiguration { 
 /// <summary>
/// [Pick one] Copies a table.
/// </summary>
public object copy { get; set; }
/// <summary>
/// [Optional] If set, don't actually run this job. A valid query will return a mostly empty response with some processing statistics, while an invalid query will return the same error it would if it wasn't a dry run. Behavior of non-query jobs is undefined.
/// </summary>
public bool dryRun { get; set; }
/// <summary>
/// [Pick one] Configures an extract job.
/// </summary>
public object extract { get; set; }
/// <summary>
/// [Optional] Job timeout in milliseconds. If this time limit is exceeded, BigQuery may attempt to terminate the job.
/// </summary>
public string jobTimeoutMs { get; set; }
/// <summary>
/// The labels associated with this job. You can use these to organize and group your jobs. Label keys and values can be no longer than 63 characters, can only contain lowercase letters, numeric characters, underscores and dashes. International characters are allowed. Label values are optional. Label keys must start with a letter and each label in the list must have a different key.
/// </summary>
public object labels { get; set; }
/// <summary>
/// [Pick one] Configures a load job.
/// </summary>
public object load { get; set; }
/// <summary>
/// [Pick one] Configures a query job.
/// </summary>
public object query { get; set; }

} 
}
