using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class TableReference { 
 /// <summary>
/// [Required] The ID of the dataset containing this table.
/// </summary>
public string datasetId { get; set; }
/// <summary>
/// [Required] The ID of the project containing this table.
/// </summary>
public string projectId { get; set; }
/// <summary>
/// [Required] The ID of the table. The ID must contain only letters (a-z, A-Z), numbers (0-9), or underscores (_). The maximum length is 1,024 characters.
/// </summary>
public string tableId { get; set; }

} 
}
