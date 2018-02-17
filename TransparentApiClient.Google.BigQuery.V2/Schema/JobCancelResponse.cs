using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class JobCancelResponse { 

		/// <summary>
		/// The final state of the job.
		/// </summary>
		public object job { get; set; }

		/// <summary>
		/// The resource type of the response.
		/// </summary>
		public string kind { get; set; } = "bigquery#jobCancelResponse";

	}
}