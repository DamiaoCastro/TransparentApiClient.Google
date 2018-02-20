using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class ForwardingAddress { 

		/// <summary>
		/// An email address to which messages can be forwarded.
		/// </summary>
		public string forwardingEmail { get; set; }

		/// <summary>
		/// Indicates whether this address has been verified and is usable for forwarding. Read-only.
		/// </summary>
		public string verificationStatus { get; set; }

	}
}