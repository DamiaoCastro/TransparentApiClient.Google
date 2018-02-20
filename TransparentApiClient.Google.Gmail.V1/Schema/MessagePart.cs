using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class MessagePart { 

		/// <summary>
		/// The message part body for this part, which may be empty for container MIME message parts.
		/// </summary>
		public MessagePartBody body { get; set; }

		/// <summary>
		/// The filename of the attachment. Only present if this message part represents an attachment.
		/// </summary>
		public string filename { get; set; }

		/// <summary>
		/// List of headers on this message part. For the top-level message part, representing the entire message payload, it will contain the standard RFC 2822 email headers such as To, From, and Subject.
		/// </summary>
		public IEnumerable<MessagePartHeader> headers { get; set; }

		/// <summary>
		/// The MIME type of the message part.
		/// </summary>
		public string mimeType { get; set; }

		/// <summary>
		/// The immutable ID of the message part.
		/// </summary>
		public string partId { get; set; }

		/// <summary>
		/// The child MIME message parts of this part. This only applies to container MIME message parts, for example multipart/*. For non- container MIME message part types, such as text/plain, this field is empty. For more information, see RFC 1521.
		/// </summary>
		public IEnumerable<MessagePart> parts { get; set; }

	}
}