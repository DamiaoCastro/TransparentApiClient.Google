using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class JobStatus { 

		/// <summary>
		/// [Output-only] Final error result of the job. If present, indicates that the job has completed and was unsuccessful.
		/// </summary>
		public ErrorProto errorResult { get; set; }

		/// <summary>
		/// [Output-only] The first errors encountered during the running of the job. The final message includes the number of errors that caused the process to stop. Errors here do not necessarily mean that the job has completed or was unsuccessful.
		/// </summary>
		public IEnumerable<ErrorProto> errors { get; set; }

		/// <summary>
		/// [Output-only] Running state of the job.
		/// </summary>
		public string state { get; set; }

	}
}