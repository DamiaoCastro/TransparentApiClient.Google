using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class TableDataInsertAllRequest { 
 /// <summary>
/// [Optional] Accept rows that contain values that do not match the schema. The unknown values are ignored. Default is false, which treats unknown values as errors.
/// </summary>
public bool ignoreUnknownValues { get; set; }
/// <summary>
/// The resource type of the response.
/// </summary>
public string kind { get; set; }
/// <summary>
/// The rows to insert.
/// </summary>
public IEnumerable<object> rows { get; set; }
/// <summary>
/// [Optional] Insert all valid rows of a request, even if invalid rows exist. The default value is false, which causes the entire request to fail if any invalid rows exist.
/// </summary>
public bool skipInvalidRows { get; set; }
/// <summary>
/// [Experimental] If specified, treats the destination table as a base template, and inserts the rows into an instance table named "{destination}{templateSuffix}". BigQuery will manage creation of the instance table, using the schema of the base template table. See https://cloud.google.com/bigquery/streaming-data-into-bigquery#template-tables for considerations when working with templates tables.
/// </summary>
public string templateSuffix { get; set; }

} 
}
