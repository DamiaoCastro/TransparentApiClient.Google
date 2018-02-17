using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class JobConfigurationExtract { 
 /// <summary>
/// [Optional] The compression type to use for exported files. Possible values include GZIP, DEFLATE, SNAPPY, and NONE. The default value is NONE. DEFLATE and SNAPPY are only supported for Avro.
/// </summary>
public string compression { get; set; }
/// <summary>
/// [Optional] The exported file format. Possible values include CSV, NEWLINE_DELIMITED_JSON and AVRO. The default value is CSV. Tables with nested or repeated fields cannot be exported as CSV.
/// </summary>
public string destinationFormat { get; set; }
/// <summary>
/// [Pick one] DEPRECATED: Use destinationUris instead, passing only one URI as necessary. The fully-qualified Google Cloud Storage URI where the extracted table should be written.
/// </summary>
public string destinationUri { get; set; }
/// <summary>
/// [Pick one] A list of fully-qualified Google Cloud Storage URIs where the extracted table should be written.
/// </summary>
public IEnumerable<object> destinationUris { get; set; }
/// <summary>
/// [Optional] Delimiter to use between fields in the exported data. Default is ','
/// </summary>
public string fieldDelimiter { get; set; }
/// <summary>
/// [Optional] Whether to print out a header row in the results. Default is true.
/// </summary>
public bool printHeader { get; set; }
/// <summary>
/// [Required] A reference to the table being exported.
/// </summary>
public object sourceTable { get; set; }

} 
}
