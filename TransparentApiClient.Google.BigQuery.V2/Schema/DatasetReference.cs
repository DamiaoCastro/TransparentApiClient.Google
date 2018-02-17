using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class DatasetReference { 
 /// <summary>
/// [Required] A unique ID for this dataset, without the project name. The ID must contain only letters (a-z, A-Z), numbers (0-9), or underscores (_). The maximum length is 1,024 characters.
/// </summary>
public string datasetId { get; set; }
/// <summary>
/// [Optional] The ID of the project containing this dataset.
/// </summary>
public string projectId { get; set; }

} 
}
