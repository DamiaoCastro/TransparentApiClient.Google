using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class QueryParameterType { 
 /// <summary>
/// [Optional] The type of the array's elements, if this is an array.
/// </summary>
public object arrayType { get; set; }
/// <summary>
/// [Optional] The types of the fields of this struct, in order, if this is a struct.
/// </summary>
public IEnumerable<object> structTypes { get; set; }
/// <summary>
/// [Required] The top level type of this field.
/// </summary>
public string type { get; set; }

} 
}
