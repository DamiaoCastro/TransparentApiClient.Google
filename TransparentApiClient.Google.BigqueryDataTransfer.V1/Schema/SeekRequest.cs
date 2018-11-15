using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigqueryDataTransfer.V1.Schema { 
	public class SeekRequest { 

		/// <summary>
		/// The time to seek to.
		///Messages retained in the subscription that were published before this
		///time are marked as acknowledged, and messages retained in the
		///subscription that were published after this time are marked as
		///unacknowledged. Note that this operation affects only those messages
		///retained in the subscription (configured by the combination of
		///`message_retention_duration` and `retain_acked_messages`). For example,
		///if `time` corresponds to a point before the message retention
		///window (or to a point before the system's notion of the subscription
		///creation time), only retained messages will be marked as unacknowledged,
		///and already-expunged messages will not be restored.
		/// </summary>
		public string time { get; set; }

		/// <summary>
		/// The snapshot to seek to. The snapshot's topic must be the same as that of
		///the provided subscription.
		///Format is `projects/{project}/snapshots/{snap}`.
		/// </summary>
		public string snapshot { get; set; }

	}
}