using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class AuditConfig { 

		/// <summary>
		/// Specifies a service that will be enabled for audit logging.
		///For example, `storage.googleapis.com`, `cloudsql.googleapis.com`.
		///`allServices` is a special value that covers all services.
		/// </summary>
		public string service { get; set; }

		/// <summary>
		/// The configuration for logging of each type of permission.
		/// </summary>
		public IEnumerable<AuditLogConfig> auditLogConfigs { get; set; }

	}
}