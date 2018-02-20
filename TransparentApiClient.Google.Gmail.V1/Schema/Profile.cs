using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class Profile { 

		/// <summary>
		/// The user's email address.
		/// </summary>
		public string emailAddress { get; set; }

		/// <summary>
		/// The ID of the mailbox's current history record.
		/// </summary>
		public string historyId { get; set; }

		/// <summary>
		/// The total number of messages in the mailbox.
		/// </summary>
		public int messagesTotal { get; set; }

		/// <summary>
		/// The total number of threads in the mailbox.
		/// </summary>
		public int threadsTotal { get; set; }

	}
}