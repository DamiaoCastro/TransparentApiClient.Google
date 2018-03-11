using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.PubSub.V1.Schema { 
	public class ModifyPushConfigRequest { 

		/// <summary>
		/// The push configuration for future deliveries.
		///
		///An empty `pushConfig` indicates that the Pub/Sub system should
		///stop pushing messages from the given subscription and allow
		///messages to be pulled and acknowledged - effectively pausing
		///the subscription if `Pull` or `StreamingPull` is not called.
		/// </summary>
		public PushConfig pushConfig { get; set; }

	}
}