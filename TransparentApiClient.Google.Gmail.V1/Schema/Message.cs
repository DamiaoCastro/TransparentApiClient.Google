using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class Message { 

		/// <summary>
		/// The ID of the last history record that modified this message.
		/// </summary>
		public string historyId { get; set; }

		/// <summary>
		/// The immutable ID of the message.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The internal message creation timestamp (epoch ms), which determines ordering in the inbox. For normal SMTP-received email, this represents the time the message was originally accepted by Google, which is more reliable than the Date header. However, for API-migrated mail, it can be configured by client to be based on the Date header.
		/// </summary>
		public string internalDate { get; set; }

		/// <summary>
		/// List of IDs of labels applied to this message.
		/// </summary>
		public IEnumerable<object> labelIds { get; set; }

		/// <summary>
		/// The parsed email structure in the message parts.
		/// </summary>
		public MessagePart payload { get; set; }

		/// <summary>
		/// The entire email message in an RFC 2822 formatted and base64url encoded string. Returned in messages.get and drafts.get responses when the format=RAW parameter is supplied.
		/// </summary>
		public string raw { get; set; }

		/// <summary>
		/// Estimated size in bytes of the message.
		/// </summary>
		public int sizeEstimate { get; set; }

		/// <summary>
		/// A short part of the message text.
		/// </summary>
		public string snippet { get; set; }

		/// <summary>
		/// The ID of the thread the message belongs to. To add a message or draft to a thread, the following criteria must be met: 
		///- The requested threadId must be specified on the Message or Draft.Message you supply with your request. 
		///- The References and In-Reply-To headers must be set in compliance with the RFC 2822 standard. 
		///- The Subject headers must match.
		/// </summary>
		public string threadId { get; set; }

	}
}