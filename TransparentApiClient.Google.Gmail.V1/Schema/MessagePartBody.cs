using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class MessagePartBody { 

		/// <summary>
		/// When present, contains the ID of an external attachment that can be retrieved in a separate messages.attachments.get request. When not present, the entire content of the message part body is contained in the data field.
		/// </summary>
		public string attachmentId { get; set; }

		/// <summary>
		/// The body data of a MIME message part as a base64url encoded string. May be empty for MIME container types that have no message body or when the body data is sent as a separate attachment. An attachment ID is present if the body data is contained in a separate attachment.
		/// </summary>
		public string data { get; set; }

		/// <summary>
		/// Number of bytes for the message part data (encoding notwithstanding).
		/// </summary>
		public int size { get; set; }

	}
}