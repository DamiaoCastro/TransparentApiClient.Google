using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class FilterCriteria { 

		/// <summary>
		/// Whether the response should exclude chats.
		/// </summary>
		public bool excludeChats { get; set; }

		/// <summary>
		/// The sender's display name or email address.
		/// </summary>
		public string from { get; set; }

		/// <summary>
		/// Whether the message has any attachment.
		/// </summary>
		public bool hasAttachment { get; set; }

		/// <summary>
		/// Only return messages not matching the specified query. Supports the same query format as the Gmail search box. For example, "from:someuser@example.com rfc822msgid: is:unread".
		/// </summary>
		public string negatedQuery { get; set; }

		/// <summary>
		/// Only return messages matching the specified query. Supports the same query format as the Gmail search box. For example, "from:someuser@example.com rfc822msgid: is:unread".
		/// </summary>
		public string query { get; set; }

		/// <summary>
		/// The size of the entire RFC822 message in bytes, including all headers and attachments.
		/// </summary>
		public int size { get; set; }

		/// <summary>
		/// How the message size in bytes should be in relation to the size field.
		/// </summary>
		public string sizeComparison { get; set; }

		/// <summary>
		/// Case-insensitive phrase found in the message's subject. Trailing and leading whitespace are be trimmed and adjacent spaces are collapsed.
		/// </summary>
		public string subject { get; set; }

		/// <summary>
		/// The recipient's display name or email address. Includes recipients in the "to", "cc", and "bcc" header fields. You can use simply the local part of the email address. For example, "example" and "example@" both match "example@gmail.com". This field is case-insensitive.
		/// </summary>
		public string to { get; set; }

	}
}