using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class ErrorProto { 
 /// <summary>
/// Debugging information. This property is internal to Google and should not be used.
/// </summary>
public string debugInfo { get; set; }
/// <summary>
/// Specifies where the error occurred, if present.
/// </summary>
public string location { get; set; }
/// <summary>
/// A human-readable description of the error.
/// </summary>
public string message { get; set; }
/// <summary>
/// A short error code that summarizes the error.
/// </summary>
public string reason { get; set; }

} 
}
