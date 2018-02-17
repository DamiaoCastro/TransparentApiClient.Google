using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class GetServiceAccountResponse { 

		/// <summary>
		/// The service account email address.
		/// </summary>
		public string email { get; set; }

		/// <summary>
		/// The resource type of the response.
		/// </summary>
		public string kind { get; set; } = "bigquery#getServiceAccountResponse";

	}
}