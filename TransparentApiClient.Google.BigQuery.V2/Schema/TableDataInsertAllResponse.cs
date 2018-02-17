using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class TableDataInsertAllResponse { 
 /// <summary>
/// An array of errors for rows that were not inserted.
/// </summary>
public IEnumerable<object> insertErrors { get; set; }
/// <summary>
/// The resource type of the response.
/// </summary>
public string kind { get; set; }

} 
}
