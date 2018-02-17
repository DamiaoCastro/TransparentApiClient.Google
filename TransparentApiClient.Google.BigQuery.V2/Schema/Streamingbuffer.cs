using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigQuery.V2.Schema { 
	public class Streamingbuffer { 

		/// <summary>
		/// [Output-only] A lower-bound estimate of the number of bytes currently in the streaming buffer.
		/// </summary>
		public string estimatedBytes { get; set; }

		/// <summary>
		/// [Output-only] A lower-bound estimate of the number of rows currently in the streaming buffer.
		/// </summary>
		public string estimatedRows { get; set; }

		/// <summary>
		/// [Output-only] Contains the timestamp of the oldest entry in the streaming buffer, in milliseconds since the epoch, if the streaming buffer is available.
		/// </summary>
		public string oldestEntryTime { get; set; }

	}
}