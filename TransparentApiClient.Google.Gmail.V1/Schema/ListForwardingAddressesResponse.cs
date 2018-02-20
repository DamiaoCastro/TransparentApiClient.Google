using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class ListForwardingAddressesResponse { 

		/// <summary>
		/// List of addresses that may be used for forwarding.
		/// </summary>
		public IEnumerable<ForwardingAddress> forwardingAddresses { get; set; }

	}
}