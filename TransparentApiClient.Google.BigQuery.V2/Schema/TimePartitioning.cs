using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class TimePartitioning { 
 /// <summary>
/// [Optional] Number of milliseconds for which to keep the storage for a partition.
/// </summary>
public string expirationMs { get; set; }
/// <summary>
/// [Experimental] [Optional] If not set, the table is partitioned by pseudo column '_PARTITIONTIME'; if set, the table is partitioned by this field. The field must be a top-level TIMESTAMP or DATE field. Its mode must be NULLABLE or REQUIRED.
/// </summary>
public string field { get; set; }
/// <summary>
/// [Experimental] [Optional] If set to true, queries over this table require a partition filter that can be used for partition elimination to be specified.
/// </summary>
public bool requirePartitionFilter { get; set; }
/// <summary>
/// [Required] The only type supported is DAY, which will generate one partition per day.
/// </summary>
public string type { get; set; }

} 
}
