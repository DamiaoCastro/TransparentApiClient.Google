using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class PullRequest { 

		/// <summary>
		/// If this field set to true, the system will respond immediately even if
it there are no messages available to return in the `Pull` response.
Otherwise, the system may wait (for a bounded amount of time) until at
least one message is available, rather than returning no messages. The
client may cancel the request if it does not wish to wait any longer for
the response.
		/// </summary>
		public bool returnImmediately { get; set; }

		/// <summary>
		/// The maximum number of messages returned for this request. The Pub/Sub
system may return fewer than the number specified.
		/// </summary>
		public int maxMessages { get; set; }

	}
}