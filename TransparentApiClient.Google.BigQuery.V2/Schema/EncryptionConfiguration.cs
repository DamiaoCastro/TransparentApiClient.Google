using System.Collections.Generic;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
public class EncryptionConfiguration { 
 /// <summary>
/// [Optional] Describes the Cloud KMS encryption key that will be used to protect destination BigQuery table. The BigQuery Service Account associated with your project requires access to this encryption key.
/// </summary>
public string kmsKeyName { get; set; }

} 
}
