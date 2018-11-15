using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigqueryDataTransfer.V1.Schema { 
	public class CreateSnapshotRequest { 

		/// <summary>
		/// The subscription whose backlog the snapshot retains.
		///Specifically, the created snapshot is guaranteed to retain:
		/// (a) The existing backlog on the subscription. More precisely, this is
		///     defined as the messages in the subscription's backlog that are
		///     unacknowledged upon the successful completion of the
		///     `CreateSnapshot` request; as well as:
		/// (b) Any messages published to the subscription's topic following the
		///     successful completion of the CreateSnapshot request.
		///Format is `projects/{project}/subscriptions/{sub}`.
		/// </summary>
		public string subscription { get; set; }

	}
}