using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class History { 

		/// <summary>
		/// The mailbox sequence ID.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// Labels added to messages in this history record.
		/// </summary>
		public IEnumerable<HistoryLabelAdded> labelsAdded { get; set; }

		/// <summary>
		/// Labels removed from messages in this history record.
		/// </summary>
		public IEnumerable<HistoryLabelRemoved> labelsRemoved { get; set; }

		/// <summary>
		/// List of messages changed in this history record. The fields for specific change types, such as messagesAdded may duplicate messages in this field. We recommend using the specific change-type fields instead of this.
		/// </summary>
		public IEnumerable<Message> messages { get; set; }

		/// <summary>
		/// Messages added to the mailbox in this history record.
		/// </summary>
		public IEnumerable<HistoryMessageAdded> messagesAdded { get; set; }

		/// <summary>
		/// Messages deleted (not Trashed) from the mailbox in this history record.
		/// </summary>
		public IEnumerable<HistoryMessageDeleted> messagesDeleted { get; set; }

	}
}