using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class QueryParameterValue { 
 /// <summary>
/// [Optional] The array values, if this is an array type.
/// </summary>
public IEnumerable<object> arrayValues { get; set; }
/// <summary>
/// [Optional] The struct field values, in order of the struct type's declaration.
/// </summary>
public object structValues { get; set; }
/// <summary>
/// [Optional] The value of this value, if a simple scalar type.
/// </summary>
public string value { get; set; }

} 
}
