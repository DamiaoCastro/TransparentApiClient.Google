using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class WatchResponse { 

		/// <summary>
		/// When Gmail will stop sending notifications for mailbox updates (epoch millis). Call watch again before this time to renew the watch.
		/// </summary>
		public string expiration { get; set; }

		/// <summary>
		/// The ID of the mailbox's current history record.
		/// </summary>
		public string historyId { get; set; }

	}
}