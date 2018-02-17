using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class TableDataList { 
 /// <summary>
/// A hash of this page of results.
/// </summary>
public string etag { get; set; }
/// <summary>
/// The resource type of the response.
/// </summary>
public string kind { get; set; }
/// <summary>
/// A token used for paging results. Providing this token instead of the startIndex parameter can help you retrieve stable results when an underlying table is changing.
/// </summary>
public string pageToken { get; set; }
/// <summary>
/// Rows of results.
/// </summary>
public IEnumerable<object> rows { get; set; }
/// <summary>
/// The total number of rows in the complete table.
/// </summary>
public string totalRows { get; set; }

} 
}
