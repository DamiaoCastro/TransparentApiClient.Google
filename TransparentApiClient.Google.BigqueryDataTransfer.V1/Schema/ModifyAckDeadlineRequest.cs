using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.BigqueryDataTransfer.V1.Schema { 
	public class ModifyAckDeadlineRequest { 

		/// <summary>
		/// The new ack deadline with respect to the time this request was sent to
		///the Pub/Sub system. For example, if the value is 10, the new
		///ack deadline will expire 10 seconds after the `ModifyAckDeadline` call
		///was made. Specifying zero may immediately make the message available for
		///another pull request.
		///The minimum deadline you can specify is 0 seconds.
		///The maximum deadline you can specify is 600 seconds (10 minutes).
		/// </summary>
		public int ackDeadlineSeconds { get; set; }

		/// <summary>
		/// List of acknowledgment IDs.
		/// </summary>
		public IEnumerable<object> ackIds { get; set; }

	}
}