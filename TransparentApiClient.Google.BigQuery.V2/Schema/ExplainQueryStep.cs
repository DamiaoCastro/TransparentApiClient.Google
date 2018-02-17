using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class ExplainQueryStep { 
 /// <summary>
/// Machine-readable operation type.
/// </summary>
public string kind { get; set; }
/// <summary>
/// Human-readable stage descriptions.
/// </summary>
public IEnumerable<object> substeps { get; set; }

} 
}
