using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class JobConfigurationTableCopy { 
 /// <summary>
/// [Optional] Specifies whether the job is allowed to create new tables. The following values are supported: CREATE_IF_NEEDED: If the table does not exist, BigQuery creates the table. CREATE_NEVER: The table must already exist. If it does not, a 'notFound' error is returned in the job result. The default value is CREATE_IF_NEEDED. Creation, truncation and append actions occur as one atomic update upon job completion.
/// </summary>
public string createDisposition { get; set; }
/// <summary>
/// Custom encryption configuration (e.g., Cloud KMS keys).
/// </summary>
public object destinationEncryptionConfiguration { get; set; }
/// <summary>
/// [Required] The destination table
/// </summary>
public object destinationTable { get; set; }
/// <summary>
/// [Pick one] Source table to copy.
/// </summary>
public object sourceTable { get; set; }
/// <summary>
/// [Pick one] Source tables to copy.
/// </summary>
public IEnumerable<object> sourceTables { get; set; }
/// <summary>
/// [Optional] Specifies the action that occurs if the destination table already exists. The following values are supported: WRITE_TRUNCATE: If the table already exists, BigQuery overwrites the table data. WRITE_APPEND: If the table already exists, BigQuery appends the data to the table. WRITE_EMPTY: If the table already exists and contains data, a 'duplicate' error is returned in the job result. The default value is WRITE_EMPTY. Each action is atomic and only occurs if BigQuery is able to complete the job successfully. Creation, truncation and append actions occur as one atomic update upon job completion.
/// </summary>
public string writeDisposition { get; set; }

} 
}
