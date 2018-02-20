using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class AutoForwarding { 

		/// <summary>
		/// The state that a message should be left in after it has been forwarded.
		/// </summary>
		public string disposition { get; set; }

		/// <summary>
		/// Email address to which all incoming messages are forwarded. This email address must be a verified member of the forwarding addresses.
		/// </summary>
		public string emailAddress { get; set; }

		/// <summary>
		/// Whether all incoming mail is automatically forwarded to another address.
		/// </summary>
		public bool enabled { get; set; }

	}
}