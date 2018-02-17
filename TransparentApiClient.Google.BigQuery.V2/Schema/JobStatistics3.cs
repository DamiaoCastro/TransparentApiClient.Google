using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class JobStatistics3 { 
 /// <summary>
/// [Output-only] The number of bad records encountered. Note that if the job has failed because of more bad records encountered than the maximum allowed in the load job configuration, then this number can be less than the total number of bad records present in the input data.
/// </summary>
public string badRecords { get; set; }
/// <summary>
/// [Output-only] Number of bytes of source data in a load job.
/// </summary>
public string inputFileBytes { get; set; }
/// <summary>
/// [Output-only] Number of source files in a load job.
/// </summary>
public string inputFiles { get; set; }
/// <summary>
/// [Output-only] Size of the loaded data in bytes. Note that while a load job is in the running state, this value may change.
/// </summary>
public string outputBytes { get; set; }
/// <summary>
/// [Output-only] Number of rows imported in a load job. Note that while an import job is in the running state, this value may change.
/// </summary>
public string outputRows { get; set; }

} 
}
