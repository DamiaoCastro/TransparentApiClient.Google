using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransparentApiClient.Google.Gmail.V1.Schema { 
	public class Thread { 

		/// <summary>
		/// The ID of the last history record that modified this thread.
		/// </summary>
		public string historyId { get; set; }

		/// <summary>
		/// The unique ID of the thread.
		/// </summary>
		public string id { get; set; }

		/// <summary>
		/// The list of messages in the thread.
		/// </summary>
		public IEnumerable<Message> messages { get; set; }

		/// <summary>
		/// A short part of the message text.
		/// </summary>
		public string snippet { get; set; }

	}
}