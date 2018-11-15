using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigqueryDataTransfer.V1.Schema { 
	public class Snapshot { 

		/// <summary>
		/// The snapshot is guaranteed to exist up until this time.
		///A newly-created snapshot expires no later than 7 days from the time of its
		///creation. Its exact lifetime is determined at creation by the existing
		///backlog in the source subscription. Specifically, the lifetime of the
		///snapshot is `7 days - (age of oldest unacked message in the subscription)`.
		///For example, consider a subscription whose oldest unacked message is 3 days
		///old. If a snapshot is created from this subscription, the snapshot -- which
		///will always capture this 3-day-old backlog as long as the snapshot
		///exists -- will expire in 4 days. The service will refuse to create a
		///snapshot that would expire in less than 1 hour after creation.
		/// </summary>
		public string expireTime { get; set; }

		/// <summary>
		/// The name of the snapshot.
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The name of the topic from which this snapshot is retaining messages.
		/// </summary>
		public string topic { get; set; }

	}
}