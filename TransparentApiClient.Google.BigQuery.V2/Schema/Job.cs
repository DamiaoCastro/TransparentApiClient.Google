using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class Job { 

		/// <summary>
		/// [Required] Describes the job configuration.
		/// </summary>
		public object configuration { get; set; }

		/// <summary>
		/// [Output-only] A hash of this resource.
		/// </summary>
		public string etag { get; set; }

		/// <summary>
		/// [Output-only] Opaque ID field of the job
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// [Optional] Reference describing the unique-per-user name of the job.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public object jobReference { get; set; }

		/// <summary>
		/// [Output-only] The type of the resource.
		/// </summary>
		public string kind { get; set; } = "bigquery#job";

		/// <summary>
		/// [Output-only] A URL that can be used to access this resource again.
		/// </summary>
		public string selfLink { get; set; }

		/// <summary>
		/// [Output-only] Information about the job, including starting time and ending time of the job.
		/// </summary>
		public object statistics { get; set; }

		/// <summary>
		/// [Output-only] The status of this job. Examine this value when polling an asynchronous job to see if the job is complete.
		/// </summary>
		public object status { get; set; }

		/// <summary>
		/// [Output-only] Email address of the user who ran the job.
		/// </summary>
		public string user_email { get; set; }

	}
}