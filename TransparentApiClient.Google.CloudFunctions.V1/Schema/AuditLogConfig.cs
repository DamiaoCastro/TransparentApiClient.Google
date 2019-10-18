using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class AuditLogConfig { 

		/// <summary>
		/// Specifies the identities that do not cause logging for this type of
		///permission.
		///Follows the same format of Binding.members.
		/// </summary>
		public IEnumerable<object> exemptedMembers { get; set; }

		/// <summary>
		/// The log type that this config enables.
		/// </summary>
		public string logType { get; set; }

	}
}