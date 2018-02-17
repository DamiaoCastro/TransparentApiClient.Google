using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class DatasetList { 
 /// <summary>
/// An array of the dataset resources in the project. Each resource contains basic information. For full information about a particular dataset resource, use the Datasets: get method. This property is omitted when there are no datasets in the project.
/// </summary>
public IEnumerable<object> datasets { get; set; }
/// <summary>
/// A hash value of the results page. You can use this property to determine if the page has changed since the last request.
/// </summary>
public string etag { get; set; }
/// <summary>
/// The list type. This property always returns the value "bigquery#datasetList".
/// </summary>
public string kind { get; set; }
/// <summary>
/// A token that can be used to request the next results page. This property is omitted on the final results page.
/// </summary>
public string nextPageToken { get; set; }

} 
}
