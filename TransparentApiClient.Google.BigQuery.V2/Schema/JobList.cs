using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class JobList { 
 /// <summary>
/// A hash of this page of results.
/// </summary>
public string etag { get; set; }
/// <summary>
/// List of jobs that were requested.
/// </summary>
public IEnumerable<object> jobs { get; set; }
/// <summary>
/// The resource type of the response.
/// </summary>
public string kind { get; set; }
/// <summary>
/// A token to request the next page of results.
/// </summary>
public string nextPageToken { get; set; }

} 
}
