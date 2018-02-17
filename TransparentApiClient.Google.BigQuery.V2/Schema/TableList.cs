using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class TableList { 
 /// <summary>
/// A hash of this page of results.
/// </summary>
public string etag { get; set; }
/// <summary>
/// The type of list.
/// </summary>
public string kind { get; set; }
/// <summary>
/// A token to request the next page of results.
/// </summary>
public string nextPageToken { get; set; }
/// <summary>
/// Tables in the requested dataset.
/// </summary>
public IEnumerable<object> tables { get; set; }
/// <summary>
/// The total number of tables in the dataset.
/// </summary>
public int totalItems { get; set; }

} 
}
