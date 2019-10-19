using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.CloudFunctions.V1.Schema { 
	public class OperationMetadataV1 { 

		/// <summary>
		/// The last update timestamp of the operation.
		/// </summary>
		public string updateTime { get; set; }

		/// <summary>
		/// Target of the operation - for example
		///projects/project-1/locations/region-1/functions/function-1
		/// </summary>
		public string target { get; set; }

		/// <summary>
		/// The original request that started the operation.
		/// </summary>
		public object request { get; set; }

		/// <summary>
		/// Version id of the function created or updated by an API call.
		///This field is only populated for Create and Update operations.
		/// </summary>
		public string versionId { get; set; }

		/// <summary>
		/// Type of operation.
		/// </summary>
		public string type { get; set; }

	}
}