using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class JobReference { 

		/// <summary>
		/// [Required] The ID of the job. The ID must contain only letters (a-z, A-Z), numbers (0-9), underscores (_), or dashes (-). The maximum length is 1,024 characters.
		/// </summary>
		public string jobId { get; set; }

		/// <summary>
		/// [Experimental] The geographic location of the job. Required except for US and EU.
		/// </summary>
		public string location { get; set; }

		/// <summary>
		/// [Required] The ID of the project containing this job.
		/// </summary>
		public string projectId { get; set; }

	}
}