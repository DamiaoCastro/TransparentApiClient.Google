using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class Label { 

		/// <summary>
		/// The color to assign to the label. Color is only available for labels that have their type set to user.
		/// </summary>
		public LabelColor color { get; set; }

		/// <summary>
		/// The immutable ID of the label.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The visibility of the label in the label list in the Gmail web interface.
		/// </summary>
		public string labelListVisibility { get; set; }

		/// <summary>
		/// The visibility of the label in the message list in the Gmail web interface.
		/// </summary>
		public string messageListVisibility { get; set; }

		/// <summary>
		/// The total number of messages with the label.
		/// </summary>
		public int messagesTotal { get; set; }

		/// <summary>
		/// The number of unread messages with the label.
		/// </summary>
		public int messagesUnread { get; set; }

		/// <summary>
		/// The display name of the label.
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// The total number of threads with the label.
		/// </summary>
		public int threadsTotal { get; set; }

		/// <summary>
		/// The number of unread threads with the label.
		/// </summary>
		public int threadsUnread { get; set; }

		/// <summary>
		/// The owner type for the label. User labels are created by the user and can be modified and deleted by the user and can be applied to any message or thread. System labels are internally created and cannot be added, modified, or deleted. System labels may be able to be applied to or removed from messages and threads under some circumstances but this is not guaranteed. For example, users can apply and remove the INBOX and UNREAD labels from messages and threads, but cannot apply or remove the DRAFTS or SENT labels from messages or threads.
		/// </summary>
		public string type { get; set; }

	}
}