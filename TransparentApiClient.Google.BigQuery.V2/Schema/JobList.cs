using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class JobList { 

		/// <summary>
		/// A hash of this page of results.
		/// </summary>
		public string etag { get; set; }

		/// <summary>
		/// List of jobs that were requested.
		/// </summary>
		public IEnumerable<Job> jobs { get; set; }

		/// <summary>
		/// The resource type of the response.
		/// </summary>
		public string kind { get; set; } = "bigquery#jobList";

		/// <summary>
		/// A token to request the next page of results.
		/// </summary>
		public string nextPageToken { get; set; }

	public class Job { 

		/// <summary>
		/// [Full-projection-only] Specifies the job configuration.
		/// </summary>
		public JobConfiguration configuration { get; set; }

		/// <summary>
		/// A result object that will be present only if the job has failed.
		/// </summary>
		public ErrorProto errorResult { get; set; }

		/// <summary>
		/// Unique opaque ID of the job.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Job reference uniquely identifying the job.
		/// </summary>
		public JobReference jobReference { get; set; }

		/// <summary>
		/// The resource type.
		/// </summary>
		public string kind { get; set; } = "bigquery#job";

		/// <summary>
		/// Running state of the job. When the state is DONE, errorResult can be checked to determine whether the job succeeded or failed.
		/// </summary>
		public string state { get; set; }

		/// <summary>
		/// [Output-only] Information about the job, including starting time and ending time of the job.
		/// </summary>
		public JobStatistics statistics { get; set; }

		/// <summary>
		/// [Full-projection-only] Describes the state of the job.
		/// </summary>
		public JobStatus status { get; set; }

		/// <summary>
		/// [Full-projection-only] Email address of the user who ran the job.
		/// </summary>
		public string user_email { get; set; }

	}
	}
}