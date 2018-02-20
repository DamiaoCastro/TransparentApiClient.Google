using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class SmtpMsa { 

		/// <summary>
		/// The hostname of the SMTP service. Required.
		/// </summary>
		public string host { get; set; }

		/// <summary>
		/// The password that will be used for authentication with the SMTP service. This is a write-only field that can be specified in requests to create or update SendAs settings; it is never populated in responses.
		/// </summary>
		public string password { get; set; }

		/// <summary>
		/// The port of the SMTP service. Required.
		/// </summary>
		public int port { get; set; }

		/// <summary>
		/// The protocol that will be used to secure communication with the SMTP service. Required.
		/// </summary>
		public string securityMode { get; set; }

		/// <summary>
		/// The username that will be used for authentication with the SMTP service. This is a write-only field that can be specified in requests to create or update SendAs settings; it is never populated in responses.
		/// </summary>
		public string username { get; set; }

	}
}