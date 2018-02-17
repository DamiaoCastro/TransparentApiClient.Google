using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class ProjectList { 
 /// <summary>
/// A hash of the page of results
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
/// Projects to which you have at least READ access.
/// </summary>
public IEnumerable<object> projects { get; set; }
/// <summary>
/// The total number of projects in the list.
/// </summary>
public int totalItems { get; set; }

} 
}
